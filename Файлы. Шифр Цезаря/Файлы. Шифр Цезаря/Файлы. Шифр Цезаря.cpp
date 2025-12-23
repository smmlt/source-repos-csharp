#include <iostream>
#include <fstream>

using namespace std;

int main() {
    ifstream fin("text.txt");
    ofstream fout("new_text.txt");

    const int alphabet_letters_num = 26;

    int key;
    do 
    {
        cout << "Enter key (1 - 25): ";
        cin >> key;
    } while (key < 1 || key > 25);

    if (fin.is_open()) 
    {
        char sumb;

        while (fin.get(sumb)) 
        {
            if (isalpha(sumb))
            {
                if (sumb >= 'A' && sumb <= 'Z')
                {
                    if (sumb + key <= 'Z') 
                    {
                        sumb += key;
                    }
                    else 
                    {
                        sumb = 'A' + (sumb + key - 'Z' - 1);
                    }
                }
                else if (sumb >= 'a' && sumb <= 'z') 
                {
                    if (sumb + key <= 'z') 
                    {
                        sumb += key;
                    }
                    else
                    {
                        sumb = 'a' + (sumb + key - 'z' - 1);
                    }
                }
            }
            fout << sumb;
        }
    }

    fin.close();
    fout.close();
    cout << "Encryption completed successfully." << endl;
}
