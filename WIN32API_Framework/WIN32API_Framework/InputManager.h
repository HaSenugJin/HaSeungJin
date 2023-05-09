#pragma once
#include "include.h"

class InputManager
{
private:
	static InputManager* Instance;
public:
	static InputManager* GetInstance()
	{
		if (Instance == nullptr)
			Instance = new InputManager;
		return Instance;
	}
private:
	DWORD inputKey;
public:
	DWORD GeyKey() { return inputKey; }
	void CheckKey();
private:
	InputManager();
public:
	~InputManager();
};