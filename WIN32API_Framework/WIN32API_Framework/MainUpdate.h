#pragma once
#include "include.h"

class MainUpdate
{
private:
	HDC m_hdc;
	int StartX, StartY;
	int EndX, EndY;
	RECT rcPoint;

public:
	void Strat();
	void Update();
	void Render();
	void Destroy();
public:
	MainUpdate();
	~MainUpdate();
};

