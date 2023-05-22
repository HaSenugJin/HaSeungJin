#pragma once
#include "include.h"

class GameObject;
class Protoptype
{
public:
	Single(Protoptype);
private:
	map<string, GameObject*> PrototypeObject;
public:
	void Start();

	GameObject* GetGameObject(string _key);
private:
	Protoptype();
public:
	~Protoptype();
};

