#pragma once
#include "Include.h"

class object
{
public:
	virtual void Start()PURE;
	virtual void Update()PURE;
	virtual void Render()PURE;
	virtual void Destroy()PURE;
	object();
	virtual ~object();
};

