#pragma once
#include "GameObject.h"

class Player : public GameObject
{
private:
	GameObject* BulletList[BULLETCOUNT];
public:
	virtual GameObject* Start()override;
	virtual int Update()override;
	virtual void Render(HDC hdc)override;
	virtual void Destroy()override;
public:
	GameObject* CreateBullet();
public:
	Player();
	virtual ~Player();
};