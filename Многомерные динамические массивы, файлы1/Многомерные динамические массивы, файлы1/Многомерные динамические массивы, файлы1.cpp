#include <iostream>
#include <fstream>
#include <string>

using namespace std;

int main() {
	ifstream fin("text.txt");
	ofstream fout("new_text.txt");

	string text[20];

	string change_word;
	string new_word;

	int count = 0;

	cout << "Enter word to change: ";
	getline(cin, change_word);

	cout << "Enter your word: ";
	getline(cin, new_word);

	if (fin.is_open())
	{
		string line;
		while (getline(fin, line))
		{
			size_t pos = 0;

			while ((pos = line.find(change_word, pos)) != string::npos) 
			{
				line.replace(pos, change_word.length(), new_word);
				pos += new_word.length(); 
			}
			fout << line << endl;
		}
	}

	fin.close();
	fout.close();
	cout << "Successfully." << endl;
}