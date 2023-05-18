#include <iostream>
#include <list>
#include <map>

using namespace std;

// iterator = ¹İº¹ÀÚ


int main()
{
	list<int> numbers;
	numbers.push_back(100);
	numbers.push_back(200);


	numbers.begin();
	numbers.end();

	numbers.insert(numbers.begin(), 50);
	numbers.insert(numbers.end(), 300);

	list<int>::iterator iter = numbers.begin();

	numbers.insert(iter, 25);

	++iter;
	++iter;
	++iter;

	numbers.insert(iter, 250);

	for (list<int>::iterator iter = numbers.begin(); iter != numbers.end(); ++iter)
	{
		cout << (*iter) << endl;
	}

	map<string, int> list;

	list["AAA"] = 10;
	list["BBB"] = 20;
	list["CCC"] = 30;

	/*
	for (int i = 0; i < list.size(); ++i)
	{
		cout << list[i] << endl;
	}
	*/
	cout << endl;
	cout << endl;
	for (map<string, int>::iterator iter = list.begin(); iter != list.end(); ++iter)
		cout << iter->first << " : " << (*iter).second << endl;

	const int size = 16;

	int Array[size] = { 1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16 };

	
	for (int i = 0; i < size; ++i)
		cout << Array[i] << ", ";

	cout << endl;
	cout << endl;

	int* iter2 = &Array[0];
	cout << (*iter2) << endl;
	cout << (*iter2 + 5) << endl;

	return 0;
}