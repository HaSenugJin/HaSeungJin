#pragma once
#include "Scene.h"

class GameObject;
class Stage : public Scene
{
private:
	GameObject* m_player;
public:
	virtual void Start()override;
	virtual int Update()override;
	virtual void Render(HDC hdc)override;
	virtual void Destroy()override;
	Stage();
	virtual ~Stage();
};

