#include "Stage.h"
#include "Player.h"
#include "Enemy.h"
#include "ObjectManager.h"

Stage::Stage() : m_player(nullptr), EnemyList(nullptr), BulletList(nullptr)
{

}

Stage::~Stage()
{
	Destroy();
}

void Stage::Start()
{
	m_player = (new Player)->Start();
	ObjectManager::GetInstance()->AddObject((new Enemy)->Start());
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