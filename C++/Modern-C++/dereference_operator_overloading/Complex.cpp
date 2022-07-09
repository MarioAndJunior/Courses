#include "Complex.h"

namespace ComplexNumber
{

Complex::Complex() : real(0), imaginary(0)
{
}

Complex::Complex(double real, double imaginary) : real(real), imaginary(imaginary)
{
}

Complex::~Complex()
{
}

Complex::Complex(const Complex& other)
{
	this->real = other.real;
	this->imaginary = other.imaginary;
}

double Complex::getReal() const
{
	return this->real;
}

double Complex::getImaginary() const
{
	return this->imaginary;
}

const Complex& Complex::operator=(const Complex& other)
{
	this->real = other.real;
	this->imaginary = other.imaginary;

	return *this;
}

bool Complex::operator==(const Complex& other)
{
	return (this->real == other.real) && (this->imaginary == other.imaginary);
}

bool Complex::operator!=(const Complex& other)
{
	return !(*this == other);
}

Complex Complex::operator*()
{
	return Complex(real, -imaginary);
}

ostream& operator<<(ostream& out, const Complex& obj)
{
	out << "real: " << obj.getReal() << " imaginary: " << obj.getImaginary();

	return out;
}

Complex operator+(const Complex obj1, const Complex obj2)
{
	return Complex(obj1.getReal() + obj2.getReal(), obj1.getImaginary() + obj2.getImaginary());
}

Complex operator+(const Complex obj1, double num)
{
	return Complex(obj1.getReal() + num, obj1.getImaginary());
}

Complex operator+(double num, const Complex obj1)
{
	return Complex(obj1.getReal() + num, obj1.getImaginary());
}

}
