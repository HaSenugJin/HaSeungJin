#include <iostream>
#include <list>

using namespace std;

typedef struct tagNode
{
	tagNode* next;
	int value;
}NODE;

NODE* List;
int Length;

void Push(int value)
{
	NODE* nextNode = List;

	while (nextNode->next != nullptr)
		nextNode = nextNode->next;

	//create
	nextNode->next = new NODE;

	//initialize
	nextNode->next->next = nullptr;
	nextNode->next->value = value;

	++Length;
}

void insert(int count, int value)
{
	//����Ʈ�� ��� �� ������ �������� count�� ���� ũ�ٸ�
	//���� �߰��� �� �����Ƿ� ����.
	if (Length < count)
		return;

	//����Ʈ�� �����
	NODE* nextNode = List;

	//ī��Ʈ�� ����ŭ ���� ���� �̵�
	while (0 < count)
	{
		--count;

		//�������� �̵�
		nextNode = nextNode->next;
	}

	//�̵��� �����ٸ� ���ο� ��带 �߰�.

	//���ο� ��� ����
	NODE* newNode = new NODE;
	newNode->next = nullptr;
	newNode->value = value;

	//���� ��带 �ӽ��� ����ҿ� ����.
	NODE* tempNode = nextNode->next;

	//������带 �����ϴ� ����ҿ� ���ο� ��带 ��ġ.
	nextNode->next = newNode;

	//���ο� ��尡 ����Ű�� ������带 �ӽð����� �ִ� ���� ��ġ.
	newNode->next = tempNode;
}

int main()
{
	//ù��° ���
	//create
	List = new NODE;

	//initialize
	List->next = nullptr;
	List->value = 0;

	Push(10);
	Push(20);
	Push(30);
	Push(40);

	insert(0, 25);
	
	//�ι�° ��带 nextNode�� �Ѱ��ش�
	NODE* nextNode = List->next;

	//nextNode�� nullptr�� �ƴ϶�� �ݺ�.
	while (nextNode != nullptr)
	{
		//���
		cout << nextNode->value << endl;

		//�������� �̵�
		nextNode = nextNode->next;
	}

	return 0;
}