#ifndef __TEST_H__
#define __TEST_H__

#include <iostream>
using namespace std;

template<class T>
class Test
{
private:
	T obj;

public:
	Test(T obj)
	{
		this->obj = obj;
	}

	void print()
	{
		cout << obj << endl;
	}
};


#endif // !__TEST_H__
