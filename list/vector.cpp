#include <iostream>
#include <vector>
#include <list>

using namespace std;

int* numbers = nullptr;
int length = 0;
void push(int n)
{
	if (numbers == nullptr)
	{
		numbers = new int;
		*numbers = n;
		++length;
		return;
	}
	int* Temp = new int[length + 1];
	
	for (int i = 0; i < length; ++i)
		Temp[i] = numbers[i];

	Temp[length] = n;
	numbers = Temp;
	++length;
}

int main(void)
{
	push(10);
	push(20);
	push(30);
	push(40);
	for (int i = 0; i < length; ++i)
	{
		cout << numbers[i] << endl;
	}

	return 0;
}