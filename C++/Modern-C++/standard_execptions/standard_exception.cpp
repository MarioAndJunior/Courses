#include "standard_exception.h"

standard_exception::standard_exception()
{
	char* pMemory = new char[99999999999999999];
	char* pMemory2 = new char[99999999999999999];
	delete[] pMemory;
	delete[] pMemory2;
}
