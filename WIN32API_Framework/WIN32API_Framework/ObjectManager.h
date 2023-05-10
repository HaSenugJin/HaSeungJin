#pragma once
#include "include.h"

class GameObject;
class ObjectManager
{
public:
	Single(ObjectManager)
private:
	int value;
public:
	int GetValue() { return value; }
	void SetValue(int _value) { value = _value; }
/*
private:
	static ObjectManager* Instance;
public:
	static ObjectManager* GetInstance()
	{
		if (Instance == nullptr)
			Instance = new ObjectManager;
		return Instance;
	}
*/
private:
	map<string, list<GameObject*>> ObjectList;
public:
	void AddObject(GameObject* _Object);

	list<GameObject*>* GetObjectList(const string& key);
private:
	ObjectManager();
public:
	~ObjectManager();
};

