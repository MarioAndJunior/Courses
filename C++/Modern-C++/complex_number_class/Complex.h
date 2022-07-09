#ifndef __COMPLEX_H__
#define __COMPLEX_H__

#include<iostream>

using namespace std;

namespace ComplexNumber
{

class Complex
{
private:
	double real;
	double imaginary;

public:
	Complex();
	Complex(double real, double imaginary);
	~Complex();
	Complex(const Complex& other);
	const Complex& operator=(const Complex& other);

	double getReal() const;
	double getImaginary() const;
};

ostream& operator<<(ostream& out, const Complex& obj);
}
#endif /*__COMPLEX_H__*/
