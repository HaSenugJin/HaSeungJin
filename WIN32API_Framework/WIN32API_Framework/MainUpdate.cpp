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
	m_hdc2 = GetDC(g_hWnd);
	m_hdc3 = GetDC(g_hWnd);

	rcPoint.left = 100;
	rcPoint.top = 100;
	
	rcPoint.bottom = 200;
	rcPoint.right = 150;

	rcPoint2.left = 300;
	rcPoint2.top = 50;

	rcPoint2.bottom = 100;
	rcPoint2.right = 100;

	rcPoint3.left = 300;
	rcPoint3.top = 50;

	rcPoint3.bottom = 100;
	rcPoint3.right = 100;
}

void MainUpdate::Update()
{
	
	/*
	if (GetAsyncKeyState(VK_UP))
	{
		rcPoint.top-=1;
		rcPoint.bottom += -1;
	}

	if (GetAsyncKeyState(VK_DOWN))
	{
		rcPoint.bottom += 1;
		rcPoint.top += 1;
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
	*/

	//스페이스바 입력시 총알발사
	if (GetAsyncKeyState(VK_SPACE))
	{
		rcPoint3.right += 1;
		rcPoint3.left += 1;
	}

}

void MainUpdate::Render()
{
	//Rectangle(m_hdc, 0, 0, 1280, 720);

	Rectangle(m_hdc, rcPoint.left, rcPoint.top, rcPoint.right, rcPoint.bottom);
	Rectangle(m_hdc2, rcPoint2.left, rcPoint2.top, rcPoint2.right, rcPoint2.bottom);
	Rectangle(m_hdc3, rcPoint3.left, rcPoint3.top, rcPoint3.right, rcPoint3.bottom);
}

void MainUpdate::Destroy()
{
}