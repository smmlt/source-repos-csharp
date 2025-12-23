#include <iostream>
using namespace std;

class Pet
{
protected:
    string name;
    string color;
    size_t timeOfLife;
    double weight;
    unsigned short height;

public:
    Pet(string _name, string _color, size_t _timeOfLife, double _weight, unsigned short _height) :
        name{ _name }, color{_color}, timeOfLife{_timeOfLife}, weight{_weight}, height{_height} {}
    Pet(string _name) : Pet(_name, "? ", 0, 0, 0) {}
    Pet() : Pet("unknown") {}

    void show() const
    {
        cout << "Name: " << name << endl;
        cout << "Color: " << color << endl;
        cout << "Time of life: " << timeOfLife << endl;
        cout << "Weight: " << weight << "kg" << endl;
        cout << "Height: " << height << "sm" << endl;
    }

    size_t getYears() const { return timeOfLife; }
    double getWeight() const { return weight; }
    unsigned short getHeight() const { return height; }
};

class Dog : public Pet
{
    string breed;
    string commands;

public:
    Dog(string _name, string _color, size_t _timeOfLife, double _weight, unsigned short _height, string _breed, string _commands) :
        Pet(_name, _color, _timeOfLife, _weight, _height), breed{_breed}, commands{_commands} {}
    Dog(string _name) : Pet(_name, "? ", 0, 0, 0), breed{ "unknown" }, commands{"unknown"} {}
    Dog() : Pet("unknown"){}

    void show() const
    {
        cout << "Name: " << name << endl;
        cout << "Color: " << color << endl;
        cout << "Time of life: " << timeOfLife << endl;
        cout << "Weight: " << weight << "kg" << endl;
        cout << "Height: " << height << "sm" << endl;
        cout << "Breed: " << breed << endl;
        cout << "Commands: " << commands << endl << endl;
    }

    string getBreed() const { return breed; }
};

class Cat : public Pet
{
    bool aggressive;
    bool playfulness;

public:
    Cat(string _name, string _color, size_t _timeOfLife, double _weight, unsigned short _height, bool _aggressive, bool _playfulness) :
        Pet(_name, _color, _timeOfLife, _weight, _height), aggressive{ _aggressive }, playfulness{_playfulness } {}
    Cat(string _name) : Pet(_name, "? ", 0, 0, 0), aggressive{ false }, playfulness{ true }{}
    Cat() : Pet("unknown") {}

    void show() const
    {
        cout << "Name: " << name << endl;
        cout << "Color: " << color << endl;
        cout << "Time of life: " << timeOfLife << endl;
        cout << "Weight: " << weight << "kg" << endl;
        cout << "Height: " << height << "sm" << endl;
        cout << "Aggressive: " << aggressive << endl;
        cout << "Playfulness: " << playfulness << endl << endl;
    }

    bool getAggressive() const { return aggressive; }
    bool getPlayfulness() const { return playfulness; }

};

class Parrot : public Pet
{
    bool canSpeak;
    bool curvedBreak;

public:
    Parrot(string _name, string _color, size_t _timeOfLife, double _weight, unsigned short _height, bool _canSpeak, bool _curvedBreak) :
        Pet(_name, _color, _timeOfLife, _weight, _height), canSpeak{ _canSpeak }, curvedBreak{ _curvedBreak } {}
    Parrot(string _name) : Pet(_name, "? ", 0, 0, 0), canSpeak{ true }, curvedBreak{ true } {}
    Parrot() : Pet("unknown") {}

    void show() const
    {
        cout << "Name: " << name << endl;
        cout << "Color: " << color << endl;
        cout << "Time of life: " << timeOfLife << endl;
        cout << "Weight: " << weight << "kg" << endl;
        cout << "Height: " << height << "sm" << endl;
        cout << "Can speak: " << canSpeak << endl;
        cout << "Curved break: " << curvedBreak << endl << endl;
    }

    bool getCanSpeak() const { return canSpeak; }
    bool getCurvedBreak() const { return curvedBreak; }
};

int main()
{
    Dog dog1("Max", "Black", 5, 15, 40, "Mongrel", "Sit, Stay, Lie");
    Cat cat1("Leopard", "yellowy-reddish with a golden tinge", 7, 5, 24, false, true);
    Parrot parrot1("Kesha", "green-yellow", 11, 0.100, 9, true, true);

    dog1.show();
    cat1.show();
    parrot1.show();
}

