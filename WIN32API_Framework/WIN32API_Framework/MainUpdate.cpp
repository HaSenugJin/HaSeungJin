#include "MainUpdate.h"

MainUpdate::MainUpdate()
{
}

MainUpdate::~MainUpdate()
{
}

void MainUpdate::Strat()
{
	m_hdc = GetDC(g_hWnd);

	rcPoint.left = 100;
	rcPoint.top = 100;
	
	rcPoint.bottom = 200;
	rcPoint.right = 200;
}

void MainUpdate::Update()
{
	
	if (GetAsyncKeyState(VK_UP))
	{
		rcPoint.top-=1;
	}

	if (GetAsyncKeyState(VK_DOWN))
	{
		rcPoint.bottom += 1;
	}

	if (GetAsyncKeyState(VK_LEFT))
	{
		rcPoint.left -= 1;
		rcPoint.right += -1;
	}

	if (GetAsyncKeyState(VK_RIGHT))
	{
		rcPoint.right += 1;
		rcPoint.left += 1;
	}

	//스페이스바 입력시 총알발사
}

void MainUpdate::Render()
{
	//Rectangle(m_hdc, 0, 0, 1280, 720);

	Rectangle(m_hdc, rcPoint.left, rcPoint.top, rcPoint.right, rcPoint.bottom);
}

void MainUpdate::Destroy()
{
}