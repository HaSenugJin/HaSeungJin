#include "tile.h"

tile::tile()
{
}

tile::~tile()
{
}

void tile::Start()
{
}

void tile::Update()
{
	if(GetAsyncKeyState(VK_RETURN))
		
}

void tile::Render(HDC hdc)
{
	Rectangle(hdc, 100, 100, 200, 200);
}

void tile::Destroy()
{
}