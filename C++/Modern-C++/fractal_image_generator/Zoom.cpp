#include "Zoom.h"

namespace FractalImage
{

Zoom::Zoom(int x, int y, double scale) : x(x), y(y), scale(scale)
{
}
Zoom::Zoom(const Zoom& other)
{
	this->x = other.x;
	this->y = other.y;
	this->scale = other.scale;
}
Zoom::~Zoom()
{
}
int Zoom::getX() const
{
	return this->x;
}
int Zoom::getY() const
{
	return this->y;
}
double Zoom::getScale() const
{
	return this->scale;
}
}
