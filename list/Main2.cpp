#include <iostream>
#include <list>

using namespace std;

typedef struct tagNode
{
	tagNode* next;
	int value;
}NODE;

NODE* List;
NODE* End;
int Length;

void Push(int value)
{
	/*
	NODE* nextNode = List;

	while (nextNode->next != nullptr)
		nextNode = nextNode->next;
	*/
	//create
	End = new NODE;

	//initialize
	End->next = nullptr;
	End->value = value;

	End = End->next;

	++Length;
}

void insert(int count, int value)
{
	//리스트에 담긴 총 원소의 개수보다 count의 값이 크다면
	//값을 추가할 수 없으므로 종료.
	if (Length < count)
		return;

	//리스트를 들고옴
	NODE* nextNode = List;

	//카운트의 값만큼 다음 노드로 이동
	while (0 < count)
	{
		--count;

		//다음노드로 이동
		nextNode = nextNode->next;
	}

	//이동이 끝났다면 새로운 노드를 추가.

	//새로운 노드 생성
	NODE* newNode = new NODE;
	newNode->next = nullptr;
	newNode->value = value;

	//다음 노드를 임시의 저장소에 보관.
	NODE* tempNode = nextNode->next;

	//다음노드를 저장하는 저장소에 새로운 노드를 배치.
	nextNode->next = newNode;

	//새로운 노드가 가르키는 다음노드를 임시공간에 있던 노드로 배치.
	newNode->next = tempNode;
}

int main()
{
	//첫번째 노드
	//create
	List = new NODE;

	//initialize
	End = List->next = nullptr;
	List->value = 0;
	End = List->next;
	Push(10);
	Push(20);
	Push(30);
	Push(40);

	insert(2, 25);
	
	//두번째 노드를 nextNode에 넘겨준다
	NODE* nextNode = List->next;

	//nextNode가 nullptr이 아니라면 반복.
	while (nextNode != nullptr)
	{
		//출력
		cout << nextNode->value << endl;

		//다음노드로 이동
		nextNode = nextNode->next;
	}

	return 0;
}