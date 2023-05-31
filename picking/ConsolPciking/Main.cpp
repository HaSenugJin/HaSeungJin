#define _CRT_SECURE_NO_WARNINGS
#include <iostream>
#include <Windows.h>

using namespace std;

//타일 가로, 세로 최대 개수
#define CNT_X 7
#define CNT_Y 4

#define BLACK		0
#define DARKBLUE	1
#define DARKGREEN	2
#define DARKSKYBLUE 3
#define DARKRED		4
#define DARKPURPLE	5
#define DARKYELLOW	6
#define GRAY		7
#define DARKGRAY	8
#define BLUE		9
#define GREEN		10
#define SKYBLUE		11
#define RED			12
#define PURPLE		13
#define YELLOW		14
#define WHITE		15


typedef struct tagVector3
{
	float x, y;

	tagVector3() : x(0), y(0) {}
	tagVector3(float _x, float _y) : x(_x), y(_y) {}
}Vector3;

void SetCorsorPosition(const float& x, const float& y);
void SetColor(int color);
void Tile(const float& _x, const float& _y, const string& _str);

int main()
{
	//타일 위치
	Vector3 Position;
	Position.x = 3;
	Position.y = 2;

	//타일 크기
	Vector3 scale;
	scale.x = 6;
	scale.y = 3;

	ULONGLONG time = GetTickCount64();

	while (true)
	{
		if (time + 100 < GetTickCount64())
		{
			time = GetTickCount64();
			system("cls");

			for (int y = 0; y < CNT_Y; ++y)
			{
				for (int x = 0; x < CNT_X; ++x)
				{
					SetColor(7);
					//타일 출력
					Tile(Position.x - (scale.x * 0.5f) + scale.x * x,
						Position.y - (scale.y * 0.5f) + scale.y * y,
						"┌─┐");

					Tile(Position.x - (scale.x * 0.5f) + scale.x * x,
						Position.y - (scale.y * 0.5f) + scale.y * y + 1,
						"│  │");

					Tile(Position.x - (scale.x * 0.5f) + scale.x * x,
						Position.y - (scale.y * 0.5f) + scale.y * y + 2,
						"└─┘");

					//index 확인
					int index = y * CNT_X + x;

					char* buffer = new char[4];
					_itoa(index, buffer, 10);

					SetColor(12);

					Tile(Position.x - 1 + scale.x * x,
						Position.y - (scale.y * 0.5f) + scale.y * y + 1,
						string(buffer));
				}
			}
			//CPU가 연산하지 않는 상태.
			Sleep(50);
		}
	}

	SetColor(7);
	return 0;
}

void SetCorsorPosition(const float& _x, const float& _y)
{
	COORD pos = { _x, _y };

	SetConsoleCursorPosition(GetStdHandle(STD_OUTPUT_HANDLE), pos);
}

void SetColor(int _color)
{
	HANDLE hendle = GetStdHandle(STD_OUTPUT_HANDLE);

	SetConsoleTextAttribute(
		hendle, _color);
}

void Tile(const float& _x, const float& _y, const string& _str)
{
	SetCorsorPosition(_x, _y);
	cout << _str << endl;
}