#include <iostream>
#include <map>
#include <list>

using namespace std;

typedef struct Score
{
	int Kor;
	int Eng;
	int Math;

	string name;

	Score() : Kor(0),Eng(0),Math(0) {}
	Score(int _kor,int _eng, int _math)
		: Kor(_kor), Eng(_eng), Math(_math) {}
};

int main()
{
	/*
	map<string, Score> list;

	string key = "ȫ";
	Score score = Score(10, 20, 30);
	score.name = "�浿";

	list.insert(make_pair(score.name, score));

	score = Score(100, 200, 300);
	list[score.name] = score;

	cout << list[score.name].Kor << endl;
	cout << list[score.name].Eng << endl;
	cout << list[score.name].Math << endl;

	multimap<string, Score> multilist;

	multilist.insert(make_pair(score.name, score));
	multilist.insert(make_pair(score.name, score));

	for (multimap<string, Score>::iterator iter = multilist.begin(); iter != multilist.end(); ++iter)
	{
		cout << "[" << score.name << "]" << endl;
		cout <<"��������" << " : " << iter->second.Kor << endl;
		cout <<"��������" << " : " << iter->second.Eng << endl;
		cout <<"��������" << " : " << iter->second.Math << endl;
	}
	*/
	
	map<string, list<Score>> StudenList;

	string key = "ȫ";
	Score score = Score(10, 20, 30);
	score.name = "�浿";



	return 0;
}