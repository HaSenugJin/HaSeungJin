#pragma once
#include "include.h"

class GameObject
{
protected:
	Tranform transform;
	int Speed;
public:
	virtual void Strat() = 0;
	virtual void Update() = 0;
	virtual void Render(HDC hdc) = 0;
	virtual void Destroy() = 0;
public:
	GameObject();
	~GameObject();
};