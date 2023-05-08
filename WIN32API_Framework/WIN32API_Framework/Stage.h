#pragma once
#include "Scene.h"

class GameObject;
class Stage : public Scene
{
private:
	GameObject* m_player;
	list<GameObject*>* EnemyList;
	list<GameObject*>* BulletList;
public:
	virtual void Start()override;
	virtual int Update()override;
	virtual void Render(HDC hdc)override;
	virtual void Destroy()override;
	Stage();
	virtual ~Stage();
};

