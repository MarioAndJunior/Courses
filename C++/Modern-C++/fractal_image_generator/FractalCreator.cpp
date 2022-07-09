#include "FractalCreator.h"
#include <iostream>

namespace FractalImage
{

FractalCreator::FractalCreator(int width, int height): width(width), height(height), histogram(std::make_unique<int[]>(Mandelbrot::MAX_ITERATIONS)),
														fractal(std::make_unique<int[]>(this->width * this->height)), bitmap(width, height), 
														zoomList(width, height)
{
	this->zoomList.add(Zoom(width / 2, height / 2, 4.0 / width));
}

FractalCreator::~FractalCreator()
{
}

void FractalCreator::calculateIteration()
{
    //bitmap.setPixel(WIDTH/2, HEIGHT/2, 255, 255, 255);
    for (int y = 0; y < this->height; y++)
    {
        for (int x = 0; x < this->width; x++)
        {
            //double xFractal = (x - WIDTH / 2.0 - 200) * 2.0 / HEIGHT;
            //double yFractal = (y - HEIGHT / 2.0) * 2.0 / HEIGHT;

            pair<double, double> coords = zoomList.doZoom(x, y);

            int iterations = Mandelbrot::getIterations(coords.first, coords.second);

            this->fractal[y * width + x] = iterations;

            if (iterations != Mandelbrot::MAX_ITERATIONS)
            {
                this->histogram[iterations]++;
            }
        }
    }
}

void FractalCreator::calculateRangeTotals()
{
    int rangeIndex{ 0 };

    for (int i = 0; i < Mandelbrot::MAX_ITERATIONS; i++)
    {
        if (i >= this->ranges[rangeIndex + 1])
        {
            rangeIndex++;
        }

        int pixels = this->histogram[i];
        this->rangeTotals[rangeIndex] += pixels;
    }

    //int overallTotal{ 0 };
    //for (auto range : this->rangeTotals)
    //{
    //    std::cout << "range total: " << range << endl;
    //    overallTotal += range;
    //}

    //std::cout << __func__ << " " << "Overall total: " << this->totalIterations << endl;
}

void FractalCreator::calculateTotalIterations()
{
    for (int i = 0; i < Mandelbrot::MAX_ITERATIONS; i++)
    {
        this->totalIterations += this->histogram[i];
    }

    //std::cout << __func__ << " " << "Overall total: " << this->totalIterations << endl;
}

void FractalCreator::drawFractal()
{

    for (int y = 0; y < this->height; y++)
    {
        for (int x = 0; x < this->width; x++)
        {
            int iterations = fractal[y * this->width + x];
            int range = getRange(iterations);
            int rangeTotal = this->rangeTotals[range];
            int rangeStart = this->ranges[range];

            RGB& startColor = this->colors[range];
            RGB& endColor = this->colors[range + 1];
            RGB colorDiff = endColor - startColor;
            
            uint8_t red{ 0 };
            uint8_t green{ 0 };
            uint8_t blue{ 0 };


            if (iterations != Mandelbrot::MAX_ITERATIONS)
            {
                int totalPixels{ 0 };
                for (int i = rangeStart; i <= iterations; i++)
                {
                    totalPixels += this->histogram[i];
                }

                //green = pow(255, hue);
                red = startColor.getR() + colorDiff.getR() * (double)totalPixels / rangeTotal;
                blue = startColor.getB() + colorDiff.getB() * (double)totalPixels / rangeTotal;
                green = startColor.getG() + colorDiff.getG() * (double)totalPixels / rangeTotal;

                bitmap.setPixel(x, y, red, green, blue);
            }
        }
    }
}

void FractalCreator::addRange(double rangeEnd, const RGB& rgb)
{
    this->ranges.push_back(rangeEnd * Mandelbrot::MAX_ITERATIONS);
    this->colors.push_back(rgb);

    if (this->gotFirstRange)
    {
        this->rangeTotals.push_back(0);
    }

    this->gotFirstRange = true;

}

void FractalCreator::addZoom(const Zoom& zoom)
{
	this->zoomList.add(zoom);
}

void FractalCreator::writeBitmap(std::string fileName)
{
    this->bitmap.write(fileName);
}

int FractalCreator::getRange(int iterations) const
{
    int range{ 0 };
    for (int i = 1; i < this->ranges.size(); i++)
    {
        range = i;
        if (this->ranges[i] > iterations)
        {
            break;
        }
    }

    range--;

    assert(range > -1);
    assert(range < this->ranges.size());

    return range;
}

void FractalCreator::run(string fileName)
{
    this->calculateIteration();
    this->calculateTotalIterations();
    this->calculateRangeTotals();
    this->drawFractal();
    this->writeBitmap(fileName);
}

}
