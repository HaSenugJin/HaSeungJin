#include "ObjectManager.h"
#include "GameObject.h"

ObjectManager* ObjectManager::Instance = nullptr;

ObjectManager::ObjectManager()
{
}

ObjectManager::~ObjectManager()
{
}

void ObjectManager::AddObject(GameObject* _Object)
{
	//�Ķ���Ͱ� ����Ű�� �ִ� Ű ���� ���� map�� ���ԵǾ��ִ��� Ȯ��.
	map<string, list<GameObject*>>::iterator iter = ObjectList.find(_Object->Getkey());

	//���� Ű�� ���ٸ�
	if (iter == ObjectList.end())
	{
		//map�� ���Խ�ų list�� ��������
		list<GameObject*> tempList;

		//����Ʈ�� ������Ʈ�� �߰�
		tempList.push_back(_Object);

		//������Ʈ�� �߰��� ����Ʈ�� map�� �߰�
		ObjectList.insert(make_pair(_Object->Getkey(), tempList));
	}
	//�̹� Ű�� �����Ѵٸ�
	else
		//�ش� ����Ʈ�� ������Ʈ�� �߰�
		iter->second.push_back(_Object);
}

list<GameObject*>* ObjectManager::GetObjectList(const string& key)
{
	//Ű ���� ���� map�� ���ԵǾ��ִ��� Ȯ��.
	map<string, list<GameObject*>>::iterator iter = ObjectList.find(key);

	//���� Ű�� ���ٸ�
	if (iter == ObjectList.end())
		//nullptr�� ��ȯ
		return nullptr;
	//�̹� Ű�� �����Ѵٸ�
	else
		//second = value = list<GameObject*>�� ��ȯ.
		return &iter->second;
}