#include <iostream>
#include <string>
using namespace std;

string comp(string str)
{
	int text = str.find_first_not_of(' ');
	for (int i = text; i < str.size(); i++)
	{
		if (str[i] == ' ' && str[i + 1] == ' ')
		{
			str.erase(i, 1);
			i--;
		}
	}
	if (!str.empty() && str.back() == ' ') 
	{
		str.pop_back();
	}

	return str;
}

int main()
{
	string str = "     dffdd   sd dfsdf         fdsds   .";
	cout << comp(str) << endl;
}