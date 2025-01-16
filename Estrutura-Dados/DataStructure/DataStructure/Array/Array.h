#ifndef __ARRAY_H__
#define __ARRAY_H__

#include <iostream>

template <class T>
class Array
{
private:
	T* allocated;
	int size;
	int length;
public:
	Array(int size)
	{
		this->size = size;
		allocated = new T[this->size];
		this->length = 0;
	}

	Array(int size, T initialValue)
	{
		this->size = size;
		allocated = new T[this->size]{ initialValue };
		this->length = 0;
	}

	virtual ~Array()
	{
		delete[] allocated;
		allocated = nullptr;
	}

	void Display();
	void Append(T element);
	void Insert(T element, int index);
	int Delete(int index);
	void InsertSort(T element);
	T Get(int index);
	void Set(T value, int index);
	T Max();
	T Min();
	T Sum();
	T Avg();
	void Reverse();
	void ReverseWithSwap();
	void Rearrange();
	int LinearSearch(T element);
	int LinearSearchWithTransposition(T element);
	int LinearSearchWithMoveToHead(T element);
	int BinarySearch(T element);
	int RecursiveBinarySearch(T arr[], int l, int h, int element);
	Array<T>* MergeSorted(Array<T> arr2);
	Array<T>* UnionSorted(Array<T> arr2);
	Array<T>* IntersectionSorted(Array<T> arr2);
	Array<T>* DifferenceSorted(Array<T> arr2);
	Array<T>* FindMissingElementsSortedSequence();
	Array<T>* FindMissingElementsUnsortedSequence();

private:
	void swap(int* first, int* second);
	bool isSorted();
};

template <class T>
void Array<T>::Display()
{
	std::cout << std::endl;
	std::cout << "Length: " << this->length << std::endl;
	std::cout << "Elements are" << std::endl;
	for (int i = 0; i < this->length; i++)
	{
		std::cout << this->allocated[i] << ' ';
	}
	std::cout << std::endl;
}

template<class T>
void Array<T>::Append(T element)
{
	if (this->length < this->size)
	{
		this->allocated[this->length++] = element;
	}
}

template<class T>
void Array<T>::Insert(T element, int index)
{
	if (index >= 0 && index <= this->length)
	{
		for (int i = this->length; i > index; i--)
		{
			this->allocated[i] = this->allocated[i - 1];
		}
		this->allocated[index] = element;
		this->length++;
	}
}

template<class T>
int Array<T>::Delete(int index)
{
	if (index >= 0 && this->length >= index)
	{
		int deleted = this->allocated[index];
		for (int i = index; i < this->length - 1; i++)
		{
			this->allocated[i] = this->allocated[i + 1];
		}
		this->length--;

		return deleted;
	}

	return -1;
}

template<class T>
void Array<T>::InsertSort(T element)
{
	if (this->length == this->size)
	{
		return;
	}

	int index = this->length - 1;
	while (index >= 0 && element < this->allocated[index])
	{
		this->allocated[index + 1] = this->allocated[index];
		index--;
	}
	this->allocated[index + 1] = element;
	this->length++;
}

template<class T>
T Array<T>::Get(int index)
{
	if (index >= 0 && index < this->length)
	{
		return this->allocated[index];
	}

	return nullptr;
}

template<class T>
void Array<T>::Set(T value, int index)
{
	if (index >= 0 && index < this->length)
	{
		this->allocated[index] = value;
	}
}

template<class T>
T Array<T>::Max()
{
	T max = this->allocated[0];
	for (int i = 1; i < this->length; i++)
	{
		if (this->allocated[i] > max)
		{
			max = this->allocated[i];
		}
	}

	return max;
}

template<class T>
T Array<T>::Min()
{
	T min = this->allocated[0];
	for (int i = 1; i < this->length; i++)
	{
		if (this->allocated[i] < min)
		{
			min = this->allocated[i];
		}
	}

	return min;
}

template<class T>
T Array<T>::Sum()
{
	T sum = 0;
	for (int i = 0; i < this->length; i++)
	{
		sum += this->allocated[i];
	}

	return sum;
}

template<class T>
T Array<T>::Avg()
{
	return Sum() / this->length;
}

template<class T>
void Array<T>::Reverse()
{
	Array<T> aux(this->size);

	for (int i = this->length - 1, j = 0; i >= 0; i--, j++)
	{
		aux.allocated[j] = this->allocated[i];
	}

	for (int i = 0; i < this->length; i++)
	{
		this->allocated[i] = aux.allocated[i];
	}
}

template<class T>
void Array<T>::ReverseWithSwap()
{
	for (int i = 0, j = this->length - 1; i < j; i++, j--)
	{
		this->swap(&this->allocated[i], &this->allocated[j]);
	}
}

template<class T>
void Array<T>::Rearrange()
{
	int i = 0;
	int j = this->length - 1;
	while (i < j)
	{
		while (this->allocated[i] < 0)
		{
			i++;
		}

		while (this->allocated[j] >= 0)
		{
			j--;
		}

		if (i < j)
		{
			swap(&this->allocated[j], &this->allocated[i]);
		}
	}
}

template<class T>
int Array<T>::LinearSearch(T element)
{
	for (int i = 0; i < this->length; i++)
	{
		if (this->allocated[i] == element)
		{
			return i;
		}
	}

	return -1;
}

template<class T>
int Array<T>::LinearSearchWithTransposition(T element)
{
	for (int i = 0; i < this->length; i++)
	{
		if (this->allocated[i] == element)
		{
			swap(&this->allocated[i], &this->allocated[i - 1]);
			return i - 1;
		}
	}

	return -1;
}

template<class T>
int Array<T>::LinearSearchWithMoveToHead(T element)
{
	for (int i = 0; i < this->length; i++)
	{
		if (this->allocated[i] == element)
		{
			swap(&this->allocated[0], &this->allocated[i]);
			return 0;
		}
	}

	return -1;
}

template<class T>
int Array<T>::BinarySearch(T element)
{
	int low = 0, mid, high = this->length - 1;

	while (low <= high)
	{
		mid = (low + high) / 2;
		if (this->allocated[mid] == element)
		{
			return mid;
		}
		else if (element < this->allocated[mid])
		{
			high = mid - 1;
		}
		else
		{
			low = mid + 1;
		}
	}

	return -1;
}

template<class T>
inline int Array<T>::RecursiveBinarySearch(T arr[], int l, int h, int element)
{
	int mid;
	if (l <= h)
	{
		mid = (l + h) / 2;
		if (element == arr[mid])
		{
			return mid;
		}
		else if (element < arr[mid])
		{
			return RecursiveBinarySearch(arr, l, mid - 1, element);
		}
		else
		{
			return RecursiveBinarySearch(arr, mid + 1, h, element);
		}
	}

	return -1;
}

template<class T>
Array<T>* Array<T>::MergeSorted(Array<T> arr2)
{
	int i = 0;
	int j = 0;
	int k = 0;

	Array<T>* merged = new Array<T>(this->length + arr2.length);

	while (i < this->length && j < arr2.length)
	{
		if (this->allocated[i] < arr2.allocated[j])
		{
			merged->allocated[k++] = this->allocated[i++];
		}
		else
		{
			merged->allocated[k++] = arr2.allocated[j++];
		}
	}

	for (; i < this->length; i++)
	{
		merged->allocated[k++] = this->allocated[i];
	}

	for (; j < arr2.length; j++)
	{
		merged->allocated[k++] = arr2.allocated[j];
	}

	merged->length = k;
	return merged;
}

template<class T>
inline Array<T>* Array<T>::UnionSorted(Array<T> arr2)
{
	int i = 0;
	int j = 0;
	int k = 0;

	Array<T>* merged = new Array<T>(this->length + arr2.length);

	while (i < this->length && j < arr2.length)
	{
		if (this->allocated[i] < arr2.allocated[j])
		{
			merged->allocated[k++] = this->allocated[i++];
		}
		else if (arr2.allocated[j] < this->allocated[i])
		{
			merged->allocated[k++] = arr2.allocated[j++];
		}
		else
		{
			merged->allocated[k++] = this->allocated[i++];
			j++;
		}
	}

	for (; i < this->length; i++)
	{
		merged->allocated[k++] = this->allocated[i];
	}

	for (; j < arr2.length; j++)
	{
		merged->allocated[k++] = arr2.allocated[j];
	}

	merged->length = k;
	return merged;
}

template<class T>
inline Array<T>* Array<T>::IntersectionSorted(Array<T> arr2)
{
	int i = 0;
	int j = 0;
	int k = 0;

	Array<T>* merged = new Array<T>(this->length + arr2.length);

	while (i < this->length && j < arr2.length)
	{
		if (this->allocated[i] < arr2.allocated[j])
		{
			i++;
		}
		else if (arr2.allocated[j] < this->allocated[i])
		{
			j++;
		}
		else
		{
			merged->allocated[k++] = this->allocated[i++];
		}
	}

	merged->length = k;
	return merged;
}

template<class T>
inline Array<T>* Array<T>::DifferenceSorted(Array<T> arr2)
{
	int i = 0;
	int j = 0;
	int k = 0;

	Array<T>* merged = new Array<T>(this->length + arr2.length);

	while (i < this->length && j < arr2.length)
	{
		if (this->allocated[i] < arr2.allocated[j])
		{
			merged->allocated[k++] = this->allocated[i++];
		}
		else if (arr2.allocated[j] < this->allocated[i])
		{
			j++;
		}
		else
		{
			i++;
			j++;
		}
	}

	for (; i < this->length; i++)
	{
		merged->allocated[k++] = this->allocated[i];
	}

	merged->length = k;
	return merged;
}

// Will find the missing elements on a sorted sequence array -> O(n2)
template<class T>
Array<T>* Array<T>::FindMissingElementsSortedSequence()
{
	// create an array with the Maximum number so it will be greater than any difference in the interval
	auto result = new Array<T>(this->Max());
	int difference = this->allocated[0];

	for (int i = 0; i < this->length; i++)
	{
		// if it's different than the first element diff the element is missing
		// it's sorted so it should be sequential
		// so the diff among the value and the index should be the same
		if (this->allocated[i] - i != difference)
		{
			// we can have sequential missing elements, so we should be validating while the difference does not match
			while (difference < this->allocated[i] - i)
			{
				result->Append(i + difference);
				difference++;
			}
		}
	}

	return result;
}

// Will find the missing elements on an unsorted sequence array -> O(n)
template<class T>
Array<T>* Array<T>::FindMissingElementsUnsortedSequence()
{
	int low = 1;
	int high = this->Max();
	Array<T>* aux = new Array<T>(this->Max() + 1, 0);
	for (int i = 0; i < this->length; i++)
	{
		aux->allocated[this->allocated[i]]++;
		aux->length++;
	}

	Array<T>* result = new Array<T>(this->Max(), 0);
	for (int i = low; i <= high; i++)
	{
		if (aux->allocated[i] == 0)
		{
			result->Append(i);
		}
	}

	delete[] aux;

	return result;
}

template<class T>
void Array<T>::swap(int* first, int* second)
{
	int aux = *first;
	*first = *second;
	*second = aux;
}

template <class T>
bool Array<T>::isSorted()
{
	for (int i = 0; i < this->length - 1; i++)
	{
		if (this->allocated[i] > this->allocated[i + 1])
		{
			return false;
		}
	}

	return true;
}
#endif