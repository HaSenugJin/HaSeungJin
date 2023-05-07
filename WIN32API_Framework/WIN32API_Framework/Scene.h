#pragma once
#include "include.h"

class Scene
{
public:
	virtual void Start()PURE;
	virtual int Update()PURE;
	virtual void Render(HDC hdc)PURE;
	virtual void Destroy()PURE;
	Scene();
	virtual ~Scene();
};

