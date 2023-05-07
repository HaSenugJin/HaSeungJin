#pragma once
#include "include.h"
#include "GameObject.h"

class CollisionManager
{
public:
	static bool CircleCollision(GameObject* temp, GameObject* dest)
	{
		float fx = dest->GetPosition().x - temp->GetPosition().x;
		float fy = dest->GetPosition().y - temp->GetPosition().y;

		float sum = dest->GetScale().x + temp->GetScale().x;

		float distance = sqrt((fx * fx) + (fy * fy));

		if (distance < sum)
			return true;

		return false;
	}

	static bool RectCollision(GameObject* temp, GameObject* dest)
	{
		if (temp->GetPosition().x + (temp->GetScale().x * 0.5f) > dest->GetPosition().x - (dest->GetScale().x * 0.5f) &&
			dest->GetPosition().x + (dest->GetScale().x * 0.5f) > dest->GetPosition().x - (dest->GetScale().x * 0.5f) &&
			temp->GetPosition().y + (temp->GetScale().y * 0.5f) > dest->GetPosition().y - (dest->GetScale().y * 0.5f) &&
			dest->GetPosition().y + (dest->GetScale().y * 0.5f) > dest->GetPosition().y - (dest->GetScale().y * 0.5f))
			return true;
		return false;
	}
};

