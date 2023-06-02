#pragma once
#include "Include.h"

class object;
class Stage
{
private:
	object* obj;
public:
	void Start();
	void Update();
	void Render();
	void Destroy();
	Stage();
	~Stage();
};

