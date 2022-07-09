#pragma once
class Map
{
public:
	Map();
	~Map();

	void renderMap(int sizeX, int sizeY, char character, char** matrix);
};

