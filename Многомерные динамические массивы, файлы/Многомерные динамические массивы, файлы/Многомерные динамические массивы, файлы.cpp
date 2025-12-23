#include <iostream>
#include <fstream>
#include <string>

using namespace std;

int main() 
{
	ifstream fin("text.txt");
	ofstream fout("new_text.txt");

	string text[20];
	int count = 0;

	if (fin.is_open()) 
	{
		string line;

		while (getline(fin, line)) 
		{
			text[count] = line;
			count++;
		}
	}

	for (int i = 0; i < count - 1; i++) 
	{
		fout << text[i] << endl;
	}

	fin.close();
	fout.close();
}