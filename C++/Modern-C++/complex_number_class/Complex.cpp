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

const Complex& Complex::operator=(const Complex& other)
{
	this->real = other.real;
	this->imaginary = other.imaginary;

	return *this;
}

double Complex::getReal() const
{
	return this->real;
}

double Complex::getImaginary() const
{
	return this->imaginary;
}

ostream& operator<<(ostream& out, const Complex& obj)
{
	out << "real: " << obj.getReal() << " imaginary: " << obj.getImaginary();

	return out;
}

}
