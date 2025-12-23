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

    virtual void show() const 
    {
        cout << "Name: " << name << endl;
        cout << "Color: " << color << endl;
        cout << "Time of life: " << timeOfLife << endl;
        cout << "Weight: " << weight << "kg" << endl;
        cout << "Height: " << height << "sm" << endl;
    }

    virtual void Sound() const
    {
        cout << "non"<< endl;
    }

    virtual void show1() const
    {
        cout << "Name: " << name << endl;
    }

    virtual void Type() const
    {
        cout << "unknown"<< endl;
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

    virtual void show() const override
    {
        cout << "Name: " << name << endl;
        cout << "Color: " << color << endl;
        cout << "Time of life: " << timeOfLife << endl;
        cout << "Weight: " << weight << "kg" << endl;
        cout << "Height: " << height << "sm" << endl;
        cout << "Breed: " << breed << endl;
        cout << "Commands: " << commands << endl << endl;
    }

    virtual void Sound() const override
    {
        cout << "gav gav" << endl;
    }

    virtual void show1() const override
    {
        cout << "Name: " << name << endl;
    }

    virtual void Type() const override
    {
        cout << "chordata" << endl;
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

    virtual void show() const override
    {
        cout << "Name: " << name << endl;
        cout << "Color: " << color << endl;
        cout << "Time of life: " << timeOfLife << endl;
        cout << "Weight: " << weight << "kg" << endl;
        cout << "Height: " << height << "sm" << endl;
        cout << "Aggressive: " << aggressive << endl;
        cout << "Playfulness: " << playfulness << endl << endl;
    }

    virtual void Sound() const override
    {
        cout << "may may" << endl;
    }

    virtual void show1() const override
    {
        cout << "Name: " << name << endl;
    }

    virtual void Type() const override
    {
        cout << "chordata" << endl;
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

    virtual void show() const override
    {
        cout << "Name: " << name << endl;
        cout << "Color: " << color << endl;
        cout << "Time of life: " << timeOfLife << endl;
        cout << "Weight: " << weight << "kg" << endl;
        cout << "Height: " << height << "sm" << endl;
        cout << "Can speak: " << canSpeak << endl;
        cout << "Curved break: " << curvedBreak << endl << endl;
    }

    virtual void Sound() const override
    {
        cout << "cvirk?" << endl;
    }

    virtual void show1() const override
    {
        cout << "Name: " << name << endl;
    }

    virtual void Type() const override
    { 
        cout << "unknown" << endl;
    }

    bool getCanSpeak() const { return canSpeak; }
    bool getCurvedBreak() const { return curvedBreak; }
};

class Hamster : public Pet
{
public:
    Hamster(string _name, string _color, size_t _timeOfLife, double _weight, unsigned short _height) :
        Pet(_name, _color, _timeOfLife, _weight, _height) {}
    Hamster(string _name) : Pet(_name, "? ", 0, 0, 0) {}
    Hamster() : Pet("unknown") {}

    virtual void show() const override
    {
        cout << "Name: " << name << endl;
        cout << "Color: " << color << endl;
        cout << "Time of life: " << timeOfLife << endl;
        cout << "Weight: " << weight << "kg" << endl;
        cout << "Height: " << height << "sm" << endl;
    }

    virtual void Sound() const override
    {
        cout << "pisk" << endl;
    }

    virtual void show1() const override
    {
        cout << "Name: " << name << endl;
    }

    virtual void Type() const override
    {
        cout << "hamster family rodent subfamily" << endl;
    }
};

int main()
{
    

    Pet* pets[4]
    {
        new Dog(),
        new Cat(),
        new Parrot(),
        new Hamster()
    };

    for (int i = 0; i < 4; i++)
    {
        pets[i]->Sound();
        pets[i]->show1();
        pets[i]->Type();
        cout << endl;
    }
}

