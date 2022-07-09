#include "Hero.h"
#include <stdio.h>

Hero::Hero()
{
	this->lastXpos = 0;
	this->lastYPos = 0;
}

Hero::~Hero()
{

}

void Hero::renderHero(int posX, int posY, char character, char** matrixBoard)
{
	this->lastXpos = posX;
	this->lastYPos = posY;
	matrixBoard[posY][posX] = character;
}

void Hero::clearLastRender(char** matrixBoard)
{
	matrixBoard[this->lastYPos][this->lastXpos] = ' ';
}

void Hero::updateHeroPosition(int& posX, int& posY, char** matrixBoard)
{
	this->clearLastRender(matrixBoard);

	char userInput = '0';
	scanf("%c", &userInput);

	switch (userInput)
	{
		case 'a':
		case 'A':
			posX--;
			break;
		case 's':
		case 'S':
			posY++; 
			break;
		case 'd':
		case 'D':
			posX++;
			break;
		case 'w':
		case 'W':
			posY--;
			break;
	default:
		break;
	}
}
