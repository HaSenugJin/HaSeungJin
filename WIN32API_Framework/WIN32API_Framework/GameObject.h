#pragma once
#include "include.h"

class GameObject
{
protected:
	Tranform transform;
	float Speed;
public:
	virtual void Strat()PURE;
	virtual void Strat(Vector3 _position)PURE;
	virtual int Update()PURE;
	virtual void Render(HDC hdc)PURE;
	virtual void Destroy()PURE;
public:
	Tranform GetTransform()
	{
		return transform;
	}
	Vector3 GetPosition() { return transform.position; }
	void SetPosition(Vector3 _position) { transform.position = _position; }
public:
	GameObject();
	virtual ~GameObject();
};