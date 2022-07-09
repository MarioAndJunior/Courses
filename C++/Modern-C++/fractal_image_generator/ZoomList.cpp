#include "ZoomList.h"
//#include <iostream>

namespace FractalImage
{

ZoomList::ZoomList(int width, int height): width(width), height(height)
{
}

ZoomList::~ZoomList()
{
}

void ZoomList::add(const Zoom& zoom)
{
	this->zooms.push_back(zoom);

	this->xCenter += (zoom.getX() - this->width / 2.0) * this->scale;
	this->yCenter += -(zoom.getY() - this->height / 2.0) * this->scale;
	this->scale *= zoom.getScale();

	//std::cout << this->xCenter << ", " << this->yCenter << ", " << this->scale << std::endl;

}

std::pair<double, double> ZoomList::doZoom(int x, int y)
{
	double xFractal = (x - this->width / 2.0) * this->scale + this->xCenter;
	double yFractal = (y - this->height / 2.0) * this->scale + this->yCenter;

	//std::cout << xFractal << ", " << yFractal << std::endl;
	return std::pair<double, double>(xFractal, yFractal);
}

}
