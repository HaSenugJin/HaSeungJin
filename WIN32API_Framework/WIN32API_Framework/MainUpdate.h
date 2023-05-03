#pragma once
#include "include.h"

class GameObject;
class MainUpdate
{
private:
	HDC m_hdc;
	GameObject* m_pPlayer;
	GameObject* enemy;

	RECT rcPoint;

public:
	void Strat();
	int Update();
	void Render();
	void Destroy();
public:
	MainUpdate();
	~MainUpdate();
};

