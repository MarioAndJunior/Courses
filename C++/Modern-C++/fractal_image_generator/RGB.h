#ifndef __RGB_H__
#define __RGB_H__

namespace FractalImage
{

class RGB
{
private:
	double r{ 0.0 };
	double g{ 0.0 };
	double b{ 0.0 };

public:
	RGB(double r, double g, double b);
	virtual ~RGB();
	
	double getR() const;
	double getG() const;
	double getB() const;
};

RGB operator-(const RGB& first, const RGB& second);
}

#endif // !__RGB_H__


