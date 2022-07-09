#ifndef __RING_H__
#define __RING_H__

#include <iostream>
using namespace std;

template<typename T>
class Ring
{
public:
	class iterator;
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