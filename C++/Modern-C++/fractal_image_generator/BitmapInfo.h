#ifndef _BITMAPINFO_H__
#define _BITMAPINFO_H__

#include <cstdint>
using namespace std;

namespace FractalImage
{

#pragma pack(2)

struct BitmapInfo
{
	int32_t headerSize{ 40 };
	int32_t width;
	int32_t height;
	int16_t planes{ 1 };
	int16_t bitsPerPixel{ 24 };
	int32_t compression{ 0 };
	int32_t dataSize{ 0 };
	int32_t hortizontalResolution{ 2400 };
	int32_t verticalResolution{ 2400 };
	int32_t colors{ 0 };
	int32_t importantColors{ 0 };
};

}

#endif // !_BITMAPINFO_H__

