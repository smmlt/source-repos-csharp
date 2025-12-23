#include <iostream>
#include <string>
using namespace std;

void Pathway(string pathway)
{
    string a = pathway.substr(0, pathway.rfind('/'));
    string b = a.substr(a.rfind('/') + 1);
    string c = pathway.substr(pathway.rfind('/') + 1);
    string d = pathway.substr(pathway.rfind('.'));
    string e = c.substr(0, c.rfind('.'));

    cout << "Pathway: " << pathway << endl;
    cout << a << endl;
    cout << b << endl;
    cout << c << endl;
    cout << d << endl;
    cout << e << endl;
}

int main()
{
    string pathway = "C:/Step/С++lesson_03/Docs/Less03.docx";
    Pathway(pathway);
}
