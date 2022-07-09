#ifndef __BITMAP_H__
#define __BITMAP_H__

#include <string>
#include <cstdint>
#include <memory>
using namespace std;

namespace FractalImage
{

class Bitmap
{
public:
	static const int BITMAP_TRIPLE = 3;
private:
	int width{ 0 };
	int height{ 0 };
	unique_ptr<uint8_t[]> pixels{nullptr};

public:
	Bitmap(int width, int height);
	virtual ~Bitmap();

	bool write(string fileName);
	void setPixel(int x, int y, uint8_t red, uint8_t green, uint8_t blue);
};

}

#endif /*__BITMAP_H__*/
