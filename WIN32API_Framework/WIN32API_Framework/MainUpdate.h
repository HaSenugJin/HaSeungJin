#pragma once
#include "include.h"

class GameObject;
class MainUpdate
{
private:
	HDC m_hdc;

	RECT rcPoint;
	GameObject* m_pPlayer;

public:
	void Strat();
	void Update();
	void Render();
	void Destroy();
public:
	MainUpdate();
	~MainUpdate();
};

