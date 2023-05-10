#include <iostream>
#include <list>
#include <string>

using namespace std;

#define function(x) (cout << x << endl)

#define Single(T)                   \
public:                             \
	static T& GetInstance()			\
	{								\
		static T instance;			\
		return instance;			\
	}								\
private:							\
	T(const T&) = delete;			\
	T& operator=(const T&) = delete;

#define GetSingle(T) : (T::GetInstance());

class Singleton
{
public:
	Single(Singleton)
/*
private:
	static Singleton* Instance;
public:
	static Singleton* GetInstance()
	{
		if (Instance == nullptr)
			Instance = new Singleton;
		return Instance;
	}
*/
private:
	int value;
public:
	int GetValue() { return value; }
	void SetValue(int _value) { value = _value; }
private:
	Singleton() : value(0) {};
public:
	~Singleton() {}
};
//Singleton* Singleton::Instance = nullptr;

class object
{
protected:
	string name;
	int age;
public:
	virtual int Update(int x) = 0;
	virtual int Start(int x) { return 0; }
};

class Player : public object
{
public:
	virtual int Start(int x)override { return age = x; }
	virtual int Update(int x)override
	{
		if (age < x)
			return 1;
		return 0;
	}
};

class Bullet : public object
{
public:
	virtual int Start(int x)override
	{
		return age = x;
	}
	virtual int Update(int x)override
	{
		if (age < x)
			return 1;
		return 0;
	}
};

int main(void)
{
	GetSingle(Singleton).SetValue(10);
	cout << GetSingle(Singleton).GetValue() << endl;

	/*
	function(10);
	object* player = new Player;

	int length = 16;
	object* bulletList = new Bullet[length];

	for (int i = 0; i < length; ++i)
	{
		bulletList->Start(i);
		if(bulletList[i].Update(i))
			cout << "bullet age 값이 " << i << "보다 작음" << endl;
		
	}

	int value = 10;

	if (player->Update(value))
		cout << "player age 값이 " << value << "보다 작음" << endl;
	*/

	return 0;
}