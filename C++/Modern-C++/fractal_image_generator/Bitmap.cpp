#include "Bitmap.h"
#include "BitmapInfo.h"
#include "BitmapFile.h"
#include <fstream>

namespace FractalImage
{

Bitmap::Bitmap(int width, int height) : width(width), height(height), pixels(new uint8_t[width * height * BITMAP_TRIPLE]{})
{
}

Bitmap::~Bitmap()
{
}

bool Bitmap::write(string fileName)
{
	BitmapFile bitmapFile;
	BitmapInfo bitmapInfo;

	bitmapFile.fileSize = sizeof(BitmapFile) + sizeof(BitmapInfo) + this->width * this->height * BITMAP_TRIPLE;
	bitmapFile.dataOffset = sizeof(BitmapFile) + sizeof(BitmapInfo);
	
	bitmapInfo.width = this->width;
	bitmapInfo.height = this->height;

	fstream file;

	file.open(fileName, ios::out|ios_base::binary);

	if (!file)
	{
		return false;
	}

	file.write(reinterpret_cast<char*>(&bitmapFile), sizeof(bitmapFile));
	file.write(reinterpret_cast<char*>(&bitmapInfo), sizeof(bitmapInfo));
	file.write(reinterpret_cast<char*>(this->pixels.get()), this->width * this->height * BITMAP_TRIPLE);

	file.close();
	if (!file)
	{
		return false;
	}

	return true;
}

void Bitmap::setPixel(int x, int y, uint8_t red, uint8_t green, uint8_t blue)
{
	uint8_t* pixel = this->pixels.get();
	pixel += (y*3) * this->width + (x*3);
	
	pixel[0] = blue;
	pixel[1] = green;
	pixel[2] = red;
}

}
