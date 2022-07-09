#include "Map.h"

Map::Map()
{

}

Map::~Map()
{

}

void Map::renderMap(int sizeX, int sizeY, char character, char** matrix)
{
	for (int i = 0; i < sizeY; i++)
	{
		for (int j = 0; j < sizeX; j++)
		{
			if (i == 0)
			{
				matrix[i][j] = '#';
			}
			else if (j == 0)
			{
				matrix[i][j] = '#';
			}
			else if (j == sizeX - 2)
			{
				matrix[i][j] = '#';
			}
			else if (i == sizeY - 1)
			{
				matrix[i][j] = '#';
			}
			else
			{
				matrix[i][j] = ' ';
			}
		}
		matrix[i][sizeX - 1] = '\n';
	}
}
