#ifndef __RING_H__
#define __RING_H__

#include <iostream>
#include <initializer_list>
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
	Ring(int size) : size(size), values(NULL), position(0)
	{
		values = new T[size];
	}

	Ring(initializer_list<T> l) : size(l.size()), values(NULL), position(0)
	{
		this->values = new T[size];
		for (auto it = l.begin(); it != l.end(); it++)
		{
			this->add(*it);
		}
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

	iterator begin()
	{
		return iterator(0, *this);
	}

	iterator end()
	{
		return iterator(this->size, *this);
	}

	void print(initializer_list<T> l)
	{
		if (this->values)
		{
			delete[] this->values;
			this->values = NULL;
		}
		this->values = new T[size];
		for (auto it = l.begin(); it != l.end(); it++)
		{
			this->add(*it);
			cout << *it << " ";
		}

		
	}
};

template<class T>
class Ring<T>::iterator
{
private:
	int position;
	Ring& ring;
public:
	iterator(int position, Ring& ring) : position(position), ring(ring)
	{

	}

	bool operator!=(const iterator& other) const
	{
		return this->position != other.position;
	}

	iterator& operator++(int)
	{
		this->position++;

		return *this;
	}

	iterator& operator++()
	{
		this->position++;

		return *this;
	}

	T& operator*()
	{
		return this->ring.get(this->position);
	}
};

#endif // !__RING_H__