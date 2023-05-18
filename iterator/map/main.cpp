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

	string key = "홍";
	Score score = Score(10, 20, 30);
	score.name = "길동";

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
		cout <<"국어점수" << " : " << iter->second.Kor << endl;
		cout <<"영어점수" << " : " << iter->second.Eng << endl;
		cout <<"수학점수" << " : " << iter->second.Math << endl;
	}
	*/
	
	map<string, list<Score>> StudenList;

	string key = "홍";
	Score score = Score(10, 20, 30);
	score.name = "길동";



	return 0;
}