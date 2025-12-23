#include <iostream>
#include <map>
#include <fstream>
#include <string>

using namespace std;

class Dictionary
{
private:
    map<string, string> dictionary;

public:
    Dictionary()
    {
        dictionary = {
            {"One", "Two"},
            {"Three", "Four"},
            {"Five", "Six"}
        };
    }

    void find_word(const string& word) const
    {
        auto it = dictionary.find(word);
        if (it != dictionary.end())
        {
            cout << it->first << " | " << it->second << endl;
        }
        else
        {
            cout << "Word not found" << endl;
        }
    }

    void insert_new_word(const string& word, const string& value)
    {
        auto it = dictionary.find(word);
        if (it != dictionary.end())
        {
            cout << "Such a word already exists!" << endl;
        }
        else
        {
            dictionary.insert({ word, value });
        }
    }

    void erase_word(const string& word)
    {
        auto it = dictionary.find(word);
        if (it != dictionary.end())
        {
            dictionary.erase(it);
            cout << "Erase +" << endl;
        }
        else
        {
            cout << "Word not found" << endl;
        }
    }

    void write_to_file(const string& filename) const
    {
        ofstream fout(filename);
        for (auto el : dictionary)
        {
            fout << el.first << " | " << el.second << endl;
        }
    }

    void show() const
    {
        for (auto el : dictionary)
        {
            cout << el.first << " | " << el.second << endl;
        }
    }
};

int main()
{
    Dictionary dictionary;
    dictionary.show();
    cout << endl;

    dictionary.find_word("Three");
    dictionary.insert_new_word("Seven", "Eight");
    dictionary.show();
    cout << endl;

    dictionary.insert_new_word("Three", "Nine");
    cout << endl;

    dictionary.show();
    cout << endl ;

    dictionary.erase_word("Three");
    dictionary.show();
    cout << endl;

    cout << "Writing dictionary to 'test.txt':" << endl;
    dictionary.write_to_file("test.txt");
}
