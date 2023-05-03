#include "MainUpdate.h"
#include "Player.h"
#include "Enemy.h"

MainUpdate::MainUpdate() : m_pPlayer(NULL), enemy(NULL) {}

MainUpdate::~MainUpdate()
{
	Destroy();
}

void MainUpdate::Strat()
{
	m_hdc = GetDC(g_hWnd);

	m_pPlayer = new Player();
	enemy = new Enemy();
	m_pPlayer->Strat();
	enemy->Strat();
}

int MainUpdate::Update()
{
	if(m_pPlayer)
		m_pPlayer->Update();

	if (enemy)
		enemy->Update();
	return 0;
}

void MainUpdate::Render()
{
	Rectangle(m_hdc,0, 0, WIDTH, HEIGET);

	if (m_pPlayer)
		m_pPlayer->Render(m_hdc);

	if (enemy)
		enemy->Render(m_hdc);
}

void MainUpdate::Destroy()
{
	if (m_pPlayer)
	{
		delete m_pPlayer;
		m_pPlayer = NULL;
	}

	if (enemy)
	{
		delete enemy;
		enemy = NULL;
	}
}