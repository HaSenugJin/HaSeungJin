#pragma once
#include "include.h"

class GameObject;
class MainUpdate
{
private:
	HDC m_hdc;

public:
	void Strat();
	void Update();
	void Render();
	void Destroy();
public:
	MainUpdate();
	~MainUpdate();
};

