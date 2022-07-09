#ifndef _BITMAPFILE_H__
#define _BITMAPFILE_H__

#include <cstdint>
namespace FractalImage
{

#pragma pack(2)

struct BitmapFile
{
	char header[2]{'B', 'M'};
	std::int32_t fileSize;
	std::int32_t reserved{ 0 };
	std::int32_t dataOffset;
};

}
#endif // !_BITMAPFILE_H__

