#include "RGB.h"

namespace FractalImage
{

RGB::RGB(double r, double g, double b): r(r), g(g), b(b)
{
}

RGB::~RGB()
{
}

double RGB::getR() const
{
	return this->r;
}

double RGB::getG() const
{
	return this->g;
}

double RGB::getB() const
{
	return this->b;
}

RGB operator-(const RGB& first, const RGB& second)
{
	return RGB(first.getR() - second.getR(), first.getG() - second.getG(), first.getB() - second.getB());
}

}
