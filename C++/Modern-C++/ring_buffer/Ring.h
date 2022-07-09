#ifndef __RING_H__
#define __RING_H__

#include <iostream>
using namespace std;

template<typename T>
class Ring
{
private:
	T* values;
	int size;
	int position;

public:
	class iterator;

public:
	Ring(int size) : size(size), values(nullptr), position(0)
	{
		values = new T[size];
	}

	virtual ~Ring()
	{
		if (values)
		{
			delete[] values;
			values = nullptr;
		}
	}

	int count()
	{
		return this->size;
	}

	void add(T value)
	{
		this->values[position++] = value;

		if (this->position == this->size)
		{
			this->position = 0;
		}
	}

	T& get(int pos)
	{
		return this->values[pos];
	}
};

template<class T>
class Ring<T>::iterator
{
public:
	void print()
	{
		cout << "Hello from iterator: " << T() << endl;
	}
};

#endif // !__RING_H__