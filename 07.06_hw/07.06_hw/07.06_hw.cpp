#include <iostream>
#include <fstream>
using namespace std;

class OpenFile
{
protected:
    char sumbol;
public:
    virtual void Display(const char* path)
    {
        ifstream fin(path);

        if (fin.is_open())
        {
            while (fin.get(sumbol))
            {
                cout << sumbol;
            }
            cout << endl;
        }
        fin.close();
    }
};

class OpenFile_ASCII : public OpenFile
{
public:
    virtual void Display(const char* path) override
    {
        ifstream fin(path);

        if (fin.is_open())
        {
            while (fin.get(sumbol))
            {
                cout << (int)sumbol << " | ";
            }
            cout << endl;
        }
        fin.close();
    }
};

class OpenFile_Append : public OpenFile
{
public:
    virtual void Display(const char* path) override
    {
        char text[10];
        ofstream fout(path, ios_base::app);
        cin.getline(text, 10);
        fout << text;
        fout.close();
    }
};

int main()
{
    OpenFile* file = new OpenFile;
    file->Display("text.txt");
    delete file;

    OpenFile* file1 = new OpenFile_ASCII;
    file1->Display("text.txt");
    delete file1;


    OpenFile* file2 = new OpenFile_Append;
    file2->Display("text.txt");
    delete file2;
}
