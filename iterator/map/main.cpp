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

	Score() : name(""), Kor(0), Eng(0), Math(0) {}

	Score(string _name) : name(_name), Kor(0), Eng(0), Math(0) {}

	Score(int _kor, int _eng, int _math)
		: Kor(_kor), Eng(_eng), Math(_math) {}

	Score(string _name, int _kor, int _eng, int _math)
		: name(_name), Kor(_kor), Eng(_eng), Math(_math) {}
}Score;

map<string, list<Score>> StudenList;
Score CreateScore(string _name, int _kor, int _eng, int _math);
bool AddStudent(string _key, Score _score);

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
	

	string key = "홍";
	string name = "길동";

	Score score = CreateScore(name, 10, 20, 30);

	if (AddStudent(key, score))
	{
		cout << "log" << endl;
	}
	
	for (map<string, list<Score>>::iterator iter = StudenList.begin();
		iter != StudenList.end(); ++iter)
	{
		for (list<Score>::iterator iter2 = iter->second.begin();
			iter2 != iter->second.end(); ++iter2)
		{
			cout << iter2->name << endl;
			cout << iter2->Kor << endl;
			cout << iter2->Eng << endl;
			cout << iter2->Math << endl << endl;
		}
	}

	return 0;
}

Score CreateScore(string _name, int _kor, int _eng, int _math)
{
	return Score(_name, _kor, _eng, _math);
}

bool AddStudent(string _key, Score _score)
{
	map<string, list<Score>>::iterator iter = StudenList.find(_key);

	if (iter == StudenList.end())
	{
		list<Score> templist;
		templist.push_back(_score);
		StudenList.insert(make_pair(_key, templist));
	}
	else
		iter->second.push_back(_score);
	
	return true;
}