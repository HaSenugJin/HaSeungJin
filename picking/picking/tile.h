#pragma once
#include "Include.h"
#include "object.h"

class tile : object
{
private:
	bool check;
public:
	virtual void Start();
	virtual void Update();
	virtual void Render(HDC hdc);
	virtual void Destroy();
	tile();
	virtual ~tile();
};