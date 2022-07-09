#ifndef __ZOOM_H__
#define __ZOOM_H__

namespace FractalImage
{

class Zoom
{
private:
	int x{ 0 };
	int y{ 0 };
	double scale{ 0.0 };
public:
	Zoom(int x, int y, double scale);
	Zoom(const Zoom& other);
	virtual ~Zoom();

	int getX() const;
	int getY() const;
	double getScale() const;
};

}

#endif // !__ZOOM_H__


