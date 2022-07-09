#ifndef __MANDELBROT_H__
#define __MANDELBROT_H__
#include "Fractal.h"

namespace FractalImage
{

class Mandelbrot :
    public Fractal
{
public:
    static const int MAX_ITERATIONS = 1000;

public:
    Mandelbrot();
    virtual ~Mandelbrot();

    static int getIterations(double x, double y);
};

}

#endif /*__MANDELBROT_H__*/
