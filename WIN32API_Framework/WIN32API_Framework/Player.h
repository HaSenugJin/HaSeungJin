#pragma once
#include "GameObject.h"

class Player : public GameObject
{
public:
	void Strat();
	void Update();
	void Render(HDC hdc);
	void Destroy();
public:
	Player();
	~Player();
};