#pragma once
#include "include.h"

class MainUpdate
{
private:
	HDC m_hdc;
	HDC m_hdc2;
	HDC m_hdc3;
	int StartX, StartY;
	int EndX, EndY;
	RECT rcPoint;
	RECT rcPoint2;
	RECT rcPoint3;

public:
	void Strat();
	void Update();
	void Render();
	void Destroy();
public:
	MainUpdate();
	~MainUpdate();
};

