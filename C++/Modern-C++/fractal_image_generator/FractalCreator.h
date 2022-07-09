#ifndef __FRACTALCREATOR_H__
#define __FRACTALCREATOR_H__

#include <string>
#include <memory>
#include <assert.h>
#include "Zoom.h"
#include "Bitmap.h"
#include "ZoomList.h"
#include "Mandelbrot.h"
#include "RGB.h"

namespace FractalImage
{

class FractalCreator
{
private:
	int width{ 0 };
	int height{ 0 };
	int totalIterations{ 0 };
	std::unique_ptr<int[]> histogram{nullptr};
	std::unique_ptr<int[]> fractal{nullptr};
	Bitmap bitmap;
	ZoomList zoomList;
	std::vector<int> ranges;
	std::vector<int> rangeTotals;
	std::vector<RGB> colors;
	bool gotFirstRange{ false };

public:
	FractalCreator(int width, int height);
	virtual ~FractalCreator();

	void addRange(double rangeEnd, const RGB& rgb);
	void addZoom(const Zoom& zoom);
	void run(string fileName);

private:
	void calculateIteration();
	void calculateRangeTotals();
	void calculateTotalIterations();
	void drawFractal();
	void writeBitmap(std::string fileName);
	int getRange(int iterations) const;
};

}

#endif // !__FRACTALCREATOR_H__


