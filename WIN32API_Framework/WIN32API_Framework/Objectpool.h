#pragma once
#include "include.h"

class GameObject;
class Objectpool
{
public:
	Single(Objectpool);
	void ReturnObject(GameObject* _Object);
	GameObject* GetPoolObject();
	list< GameObject*>* GetList() { return &PoolList; }
private:
	list<GameObject*> PoolList;
private:
	Objectpool();
public:
	~Objectpool();
};