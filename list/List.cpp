#include <iostream>

using namespace std;

typedef struct tagNode
{
	tagNode* next;
	int value;
}NODE;

NODE* List;
NODE* End;
int Length;

void push(int value)
{
	//** create
	NODE* node = new NODE;

	//** initialize
	node->next = nullptr;
	node->value = value;

	End->next = node;
	End = node;
	++Length;
}

void insert(int count, int value)
{
	// ** ����Ʈ�� ��� �� ������ �������� count�� ���� ũ�ٸ�
	// ** ���� �߰��� �� �����Ƿ� ����.
	if (Length < count)
		return;

	// ** ����Ʈ�� ����.
	NODE* nextNode = List;

	// ** ī��Ʈ�� �� ��ŭ ���� ���� �̵�.
	while (0 < count)
	{
		--count;

		// ** �������� �̵�
		nextNode = nextNode->next;
	}
	// ** �̵��� �����ٸ� ���ο� ��带 �߰�.

	// ** ���ο� ��� ����
	NODE* newNode = new NODE;
	newNode->next = nullptr;
	newNode->value = value;

	// ** ���� ��带 �ӽ��� ����ҿ� ����.
	NODE* tempNode = nextNode->next;

	// ** ������带 �����ϴ� ����ҿ� ���ο� ��带 ��ġ.
	nextNode->next = newNode;

	// ** ���ο� ��尡 ����Ű�� ������带 �ӽð����� �ִ� ���� ��ġ
	newNode->next = tempNode;
	++Length;
}

void remove(int count)
{
	// ** ����Ʈ�� ��� �� ������ �������� count�� ���� ũ�ٸ�
	// ** ���� �߰��� �� �����Ƿ� ����.
	if (Length < count)
		return;

	// ** ����Ʈ�� ����.
	NODE* nextNode = List;

	// ** ī��Ʈ�� �� ��ŭ ���� ���� �̵�.
	while (0 < count)
	{
		--count;

		// ** �������� �̵�
		nextNode = nextNode->next;
	}

	// ** �� ���� ��带 �ӽ��� ����ҿ� ����.
	NODE* tempNode = nextNode->next->next;

	// ** ���� ��带 ����.
	delete nextNode->next;
	nextNode->next = nullptr;

	// ** ������ ������ �ӽ������ߴ� ��带 ����.
	nextNode->next = tempNode;
}

void pop()
{
	if (Length < 1)
		return;
	else if(Length < 2)
	{
		delete List->next;
		List->next = nullptr;
		End = List;
	}
	else
	{
		NODE* nextNode = List;
		while (nextNode->next->next != nullptr)
		{
			nextNode = nextNode->next;
		}

		End = nextNode;
		delete nextNode->next;
		nextNode->next = nullptr;
	}
	--Length;
}

void back(int count)
{
	if (Length == Length)
	{
		NODE* node = new NODE;

		//** initialize
		node->next = nullptr;
		node->value = count;

		End->next = node;
		End = node;
		++Length;
	}
}

int main(void)
{
	/*
	int i = 10;
	int* n = &i;

	cout << i << endl;
	cout << *n << endl;

	cout << &i << endl;
	cout << n << endl;

	*n = 20;

	cout << i << endl;
	*/



	/*
	{
		{
			NODE* node = nullptr;

			{
				NODE* tempNode = new NODE;

				tempNode->next = nullptr;
				tempNode->value = 10;

				node = tempNode;

				cout << tempNode << endl;
			}
			cout << node << endl;
			//cout << node->value << endl;
		}
	}
	*/



	// ** ù��° ���
	// create
	List = new NODE;

	// initialize
	List->next = nullptr;
	List->value = 0;

	End = List;
	//===========================================

	push(10);
	push(20);
	push(30);
	push(40);

	// ** �ι�° ��带 nextNode �� �Ѱ��ش�.
	NODE* nextNode = List->next;

	// ** nextNode�� nullptr�� �ƴ϶�� �ݺ�.
	while (nextNode != nullptr)
	{
		// ** ���
		cout << nextNode->value << endl;

		// ** �������� �̵�
		nextNode = nextNode->next;
	}

	return 0;
}