#include "Stage.h"
#include "Player.h"
#include "Enemy.h"
#include "ObjectManager.h"
#include"Protoptype.h"
//#include "CollisionManager.h"

Stage::Stage() : m_player(nullptr), EnemyList(nullptr), BulletList(nullptr)
{

}

Stage::~Stage()
{
	Destroy();
}

void Stage::Start()
{
	GetSingle(Protoptype)->Start();

	{
		GameObject* ProtoObj = GetSingle(Protoptype)->GetGameObject("Player");

		if (ProtoObj != nullptr)
		{
			m_player = ProtoObj->Clone();
			m_player->Start();
		}
	}


	{
		GameObject* ProtoObj = GetSingle(Protoptype)->GetGameObject("Enemy");

		if (ProtoObj != nullptr)
		{
			GameObject* Object = ProtoObj->Clone();
			ObjectManager::GetInstance()->AddObject(Object->Start());
		}
	}

	EnemyList = ObjectManager::GetInstance()->GetObjectList("Enemy");
}

int Stage::Update()
{
	if (m_player)
		m_player->Update();

	if (EnemyList != nullptr && !EnemyList->empty())
	{
		for (list<GameObject*>::iterator iter = EnemyList->begin(); iter != EnemyList->end(); ++iter)
		{
			(*iter)->Update();
		}
	}

	if (BulletList != nullptr && !BulletList->empty())
	{
		for (list<GameObject*>::iterator iter = BulletList->begin(); iter != BulletList->end(); ++iter)
		{
			(*iter)->Update();
		}
	}
	else
		BulletList = ObjectManager::GetInstance()->GetObjectList("Bullet");

	//Ãæµ¹
	/*
	CollisionManager c;

	if (c.CircleCollision(GetSingle(Protoptype)->GetGameObject("Enemy"), GetSingle(Protoptype)->GetGameObject("Bullet")))
	{

	}
	*/
	

	return 0;
}

void Stage::Render(HDC hdc)
{
	if (m_player)
		m_player->Render(hdc);

	if (EnemyList != nullptr && !EnemyList->empty())
	{
		for (list<GameObject*>::iterator iter = EnemyList->begin(); iter != EnemyList->end(); ++iter)
		{
			(*iter)->Render(hdc);
		}
	}

	if (BulletList != nullptr && !BulletList->empty())
	{
		for (list<GameObject*>::iterator iter = BulletList->begin(); iter != BulletList->end(); ++iter)
		{
			(*iter)->Render(hdc);
		}
	}
}

void Stage::Destroy()
{
	if (m_player)
	{
		delete m_player;
		m_player = NULL;
	}

	if (EnemyList != nullptr && !EnemyList->empty())
	{
		for (list<GameObject*>::iterator iter = EnemyList->begin(); iter != EnemyList->end(); ++iter)
		{
			delete (*iter);
			(*iter) = nullptr;
		}
		EnemyList->clear();
	}

	if (BulletList != nullptr && !BulletList->empty())
	{
		for (list<GameObject*>::iterator iter = BulletList->begin(); iter != BulletList->end(); ++iter)
		{
			delete (*iter);
			(*iter) = nullptr;
		}
		BulletList->clear();
	}
}