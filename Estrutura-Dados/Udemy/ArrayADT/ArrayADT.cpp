// ArrayADT.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>

struct Array
{
    int* A;
    int size;
    int length;
};

void swap(int* first, int* second)
{
    int aux = *first;
    *first = *second;
    *second = aux;
}

bool isSorted(Array arr, int numberOfElements)
{
    for (int i = 0; i < numberOfElements - 1; i++)
    {
        if (arr.A[i] > arr.A[i + 1])
        {
            return false;
        }
    }

    return true;
}

void Display(struct Array arr)
{
    std::cout << "Length: " << arr.length << std::endl;
    std::cout << "Elements are" << std::endl;
    for (int i = 0; i < arr.length; i++)
    {
        std::cout << arr.A[i] << ' ';
    }
    std::cout << std::endl;
}

void Append(struct Array* arr, int element)
{
    if (arr->length < arr->size)
    {
        arr->A[arr->length++] = element;
    }
}

void InsertSort(Array* arr, int element)
{
    if (arr->length == arr->size)
    {
        return;
    }

    int index = arr->length - 1;
    while (index >=0 && element < arr->A[index])
    {
        arr->A[index + 1] = arr->A[index];
        index--;
    }
    arr->A[index + 1] = element;
    arr->length++;
}

void Insert(struct Array* arr, int index, int element)
{
    if (index >= 0 && index <= arr->length)
    {
        for (int i = arr->length; i > index; i--)
        {
            arr->A[i] = arr->A[i - 1];
        }
        arr->A[index] = element;
        arr->length++;
    }
}

int Delete(struct Array* arr, int index)
{
    if (index >= 0 && arr->length >= index)
    {
        int deleted = arr->A[index];
        for (int i = index; i < arr->length - 1; i++)
        {
            arr->A[i] = arr->A[i + 1];
        }
        arr->length--;

        return deleted;
    }

    return -1;
}

int Get(Array a, int index)
{
    if (index >= 0 && index < a.length)
    {
        return a.A[index];
    }

    return -1;
}

void Set(Array a, int index, int value)
{
    if (index >= 0 && index < a.length)
    {
        a.A[index] = value;
    }
}

int Max(Array arr)
{
    int max = arr.A[0];
    for (int i = 1; i < arr.length; i++)
    {
        if (arr.A[i] > max)
        {
            max = arr.A[i];
        }
    }

    return max;
}

int Min(Array arr)
{
    int min = arr.A[0];
    for (int i = 1; i < arr.length; i++)
    {
        if (arr.A[i] < min)
        {
            min = arr.A[i];
        }
    }

    return min;
}

int Sum(Array arr)
{
    int sum = 0;
    for (int i = 0; i < arr.length; i++)
    {
        sum += arr.A[i];
    }

    return sum;
}

int Avg(Array arr)
{
    return Sum(arr) / arr.length;
}

void Reverse(Array* arr)
{
    Array aux;
    aux.A = new int[arr->size];

    for (int i = arr->length - 1, j = 0; i >= 0; i--, j++)
    {
        aux.A[j] = arr->A[i];
    }

    for (int i = 0; i < arr->length; i++)
    {
        arr->A[i] = aux.A[i];
    }
}

void ReverseSwap(Array* arr)
{
    for (int i = 0, j = arr->length - 1; i < j; i++, j--)
    {
        swap(&arr->A[i], &arr->A[j]);
    }
}

// Will arranje negative numbers to the left and positive to the right
void Rearrange(Array* arr)
{
    int i = 0;
    int j = arr->length - 1;
    while (i < j)
    {
        while (arr->A[i] < 0)
        {
            i++;
        }

        while (arr->A[j] >= 0)
        {
            j--;
        }

        if (i < j)
        {
            swap(&arr->A[j], &arr->A[i]);
        }
    }
}

int LinearSearch(Array arr, int element)
{
    for (int i = 0; i < arr.length; i++)
    {
        if (arr.A[i] == element)
        {
            return i;
        }
    }

    return -1;
}

int LinearSearchWithTranspositiion(Array* arr, int element)
{
    for (int i = 0; i < arr->length; i++)
    {
        if (arr->A[i] == element)
        {
            swap(&arr->A[i], &arr->A[i - 1]);
            return i - 1;
        }
    }

    return -1;
}

int LinearSearchWithMoveToHead(Array* arr, int element)
{
    for (int i = 0; i < arr->length; i++)
    {
        if (arr->A[i] == element)
        {
            swap(&arr->A[0], &arr->A[i]);
            return 0;
        }
    }

    return -1;
}

int BinarySearch(Array arr, int element)
{
    int low = 0, mid, high = arr.length - 1;

    while (low <= high)
    {
        mid = (low + high) / 2;
        if (arr.A[mid] == element)
        {
            return mid;
        }
        else if (element < arr.A[mid])
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

int RecursiveBinarySearch(int arr[], int l, int h, int element)
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

int main()
{
    std::cout << "Array ADT\n";
    Array arr;
    int n;
    std::cout << "Enter the size of an array" << std::endl;
    std::cin >> arr.size;

    arr.A = new int[arr.size];
    arr.length = 0;

    std::cout << "Enter the number of numbers" << std::endl;
    std::cin >> n;

    std::cout << "Enter all elements" << std::endl;
    for (int i = 0; i < n; i++)
    {
        int input;
        std::cin >> input;
        Append(&arr, input);
    }

    arr.length = n;

    Display(arr);
   /* Append(&arr, 22);
    Display(arr);
    Insert(&arr, 2, 35);
    Display(arr);
    std::cout << Delete(&arr, 0) << std::endl;
    Display(arr);*/
    std::cout << LinearSearch(arr, 7) << std::endl;
    /*std::cout << LinearSearchWithTranspositiion(&arr, 12) << std::endl;
    std::cout << LinearSearchWithMoveToHead(&arr, 12) << std::endl;*/
    //std::cout << BinarySearch(arr, 7) << std::endl;
    //std::cout << RecursiveBinarySearch(arr.A, 0, arr.length -1, 7) << std::endl;
    std::cout << Get(arr, 3) << std::endl;
    //Set(arr, 4, 10);
    Display(arr);
    std::cout << Min(arr) << std::endl;
    std::cout << Max(arr) << std::endl;
    std::cout << Sum(arr) << std::endl;
    std::cout << Avg(arr) << std::endl;

    //Reverse(&arr);
    //Display(arr);

    //ReverseSwap(&arr);
    //Display(arr);

    //InsertSort(&arr, 3);
    Display(arr);
    std::cout << isSorted(arr, arr.length) << std::endl;
    Rearrange(&arr);
    Display(arr);

    //Array arrStack = { {1,2,3,4,5}, 20, 5 }; // if A is fixed size
}

// Run program: Ctrl + F5 or Debug > Start Without Debugging menu
// Debug program: F5 or Debug > Start Debugging menu

// Tips for Getting Started: 
//   1. Use the Solution Explorer window to add/manage files
//   2. Use the Team Explorer window to connect to source control
//   3. Use the Output window to see build output and other messages
//   4. Use the Error List window to view errors
//   5. Go to Project > Add New Item to create new code files, or Project > Add Existing Item to add existing code files to the project
//   6. In the future, to open this project again, go to File > Open > Project and select the .sln file
