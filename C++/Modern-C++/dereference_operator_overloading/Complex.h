#ifndef __COMPLEX_H__
#define __COMPLEX_H__

#include <iostream>

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
	bool operator==(const Complex& other);
	bool operator!=(const Complex& other);
	Complex operator*();

	double getReal() const;
	double getImaginary() const;

	//pode ser funcao friend
	friend ostream& operator<<(ostream& out, const Complex& obj);
	friend Complex operator+(const Complex obj1, const Complex obj2);
	friend Complex operator+(const Complex obj1, double num);
	friend Complex operator+(double num, const Complex obj1);

};

//pode ser no padrao livre aqui
//ostream& operator<<(ostream& out, const Complex& obj);
//Complex operator+(const Complex obj1, const Complex obj2);
//Complex operator+(const Complex obj1, double num);
//Complex operator+(double num, const Complex obj1);
}
#endif /*__COMPLEX_H__*/
