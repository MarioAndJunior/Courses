#pragma once
#include "Map.h"
#include "Hero.h"
class Engine
{
public:
	Engine(int maxXBoard, int maxYBoard);
	~Engine();
	void execute();
	char** getBoard();

private:
	void allocateBoard();
	void deallocateBoard();
	void printBoard();

private:
	int boardXLimit;
	int boardYLimit;
	Map* map;
	Hero* hero;
	char** matrixBoard;
};

