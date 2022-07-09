#pragma once
class Hero
{
public:
	Hero();
	~Hero();
	void renderHero(int posX, int posY, char character, char** matrixBoard);
	void updateHeroPosition(int& posX, int& posY, char** matrixBoard);

private:
	void clearLastRender(char** matrixBoard);

private:
	int lastXpos;
	int lastYPos;
};

