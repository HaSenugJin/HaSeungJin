#include "Objectpool.h"

Objectpool::Objectpool()
{
	
}

Objectpool::~Objectpool()
{

}

void Objectpool::ReturnObject(GameObject* _Object)
{
	PoolList.push_back(_Object);
}

GameObject* Objectpool::GetPoolObject()
{
	GameObject* Obj = PoolList.pop_back();
	return nullptr;
}
