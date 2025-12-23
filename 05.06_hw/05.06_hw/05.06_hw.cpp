#include <iostream>
#include <string>
using namespace std;

template <typename T1, typename T2>
class Division
{
protected:
    T1 role1;
    T2 role2;

public:
    Division(T1 _role1, T2 _role2) : role1{ _role1 }, role2{ _role2 }{}
    
    void show() const
    {
        cout << "Role 1: " << role1 << endl;
        cout << "Role 2: " << role2 << endl;
    }
};

template <typename T1, typename T2, typename T3, typename T4>
class Division1 : public Division<T1, T2>
{
protected:
    T3 role3;
    T4 role4;

public:
    Division1(T1 _role1, T2 _role2, T3 _role3, T4 _role4) : 
        Division<T1, T2>(_role1, _role2), role3{ _role3 }, role4{ _role4 }{}

    void show() const
    {
        Division<T1, T2>::show();
        cout << "Role 3: " << role3 << endl;
        cout << "Role 4: " << role4 << endl;
    }
};

template <typename T1, typename T2, typename T3, typename T4, typename T5, typename T6>
class Division2 : public Division1<T1, T2, T3, T4>
{
protected:
    T5 role5;
    T6 role6;

public:
    Division2(T1 _role1, T2 _role2, T3 _role3, T4 _role4, T5 _role5, T6 _role6 ) :
        Division1<T1, T2, T3, T4>(_role1, _role2, _role3, _role4), role5{ _role5 }, role6{ _role6 }{}

    void show() const
    {
        Division1<T1, T2, T3, T4>::show();
        cout << "Role 5: " << role5 << endl;
        cout << "Role 6: " << role6 << endl;
    }
};

int main()
{
    Division2<int, int, int, string, string, string> dv(1, 2, 3, "one", "two", "three");
    dv.show();
}

