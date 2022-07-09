#ifndef __ZOOMLIST_H__
#define __ZOOMLIST_H__

#include <vector>
#include <utility>
#include "Zoom.h"

namespace FractalImage
{

class ZoomList
{
private:
	double xCenter{ 0 };
	double yCenter{ 0 };
	double scale{ 1.0 };
	int width{ 0 };
	int height{ 0 };

	std::vector<Zoom> zooms;

public:
	ZoomList(int width, int height);
	virtual ~ZoomList();

	void add(const Zoom& zoom);
	std::pair<double, double> doZoom(int x, int y);
};

}

#endif // !__ZOOMLIST_H__


