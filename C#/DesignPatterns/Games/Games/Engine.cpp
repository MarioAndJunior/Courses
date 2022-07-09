#include "Engine.h"
#include <stdio.h>
#include <xutility>

Engine::Engine(int maxXBoard, int maxYBoard)
{
	this->boardXLimit = maxXBoard;
	this->boardYLimit = maxYBoard;
	this->map = new Map();
	this->hero = new Hero();
	this->matrixBoard = 0;
}

Engine::~Engine()
{
	delete map;
	delete hero;
	this->deallocateBoard();
}

void Engine::allocateBoard()
{
	this->matrixBoard = new char* [this->boardYLimit];

	for (int i = 0; i < this->boardYLimit; i++)
	{
		this->matrixBoard[i] = new char[this->boardXLimit];
	}
}

void Engine::deallocateBoard()
{
	for (int i = 0; i < this->boardYLimit; i++)
	{
		delete[] this->matrixBoard[i];
	}
	delete[] this->matrixBoard;
}

void Engine::printBoard()
{
	for (int i = 0; i < this->boardYLimit; i++)
	{
		for (int j = 0; j < this->boardXLimit; j++)
		{
			printf("%c", this->matrixBoard[i][j]);
		}
	}
}

void Engine::execute()
{
	int heroIniPosX = (this->boardXLimit / 2);
	int heroIniPosY = (this->boardYLimit / 2);

	this->allocateBoard();
	this->map->renderMap(this->boardXLimit, this->boardYLimit, '#', this->matrixBoard);
	this->hero->renderHero(heroIniPosX, heroIniPosY, 'C', this->matrixBoard);

	while (true)
	{
		this->printBoard();
		this->hero->updateHeroPosition(heroIniPosX, heroIniPosY, this->matrixBoard);
		this->hero->renderHero(heroIniPosX, heroIniPosY, 'C', this->matrixBoard);
		system("cls");
	}
}

char** Engine::getBoard()
{
	return this->matrixBoard;
}
