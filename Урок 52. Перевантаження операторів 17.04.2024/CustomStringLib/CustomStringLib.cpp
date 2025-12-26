#define _CRT_SECURE_NO_WARNINGS
#include <iostream>
#include <cstring>

class String {
private:
    char* data;
    size_t length;
    static int objectCount;

public:
    // Конструктор по умолчанию (строка длиной 80 символов)
    String() : String(80) {
        std::cout << "Default constructor called (80 chars)\n";
    }

    // Конструктор для строки произвольного размера
    String(size_t size) {
        length = size;
        data = new char[length + 1];
        data[0] = '\0';
        objectCount++;
        std::cout << "Constructor called (size " << size << ")\n";
    }

    // Конструктор с инициализацией строкой от пользователя
    String(const char* str) {
        length = std::strlen(str);
        data = new char[length + 1];
        strcpy_s(data, length + 1, str);
        objectCount++;
        std::cout << "Constructor called with user string\n";
    }

    // Деструктор
    ~String() {
        delete[] data;
        objectCount--;
        std::cout << "Destructor called\n";
    }

    // Ввод строки с клавиатуры
    void input() {
        char buffer[1024];
        std::cout << "Enter a string: ";
        std::cin.getline(buffer, 1024);
        delete[] data;
        length = std::strlen(buffer);
        data = new char[length + 1];
        strcpy_s(data, length + 1, buffer);
    }

    // Вывод строки на экран
    void display() const {
        std::cout << data << std::endl;
    }

    // Статическая функция-член для подсчёта объектов
    static int getObjectCount() {
        return objectCount;
    }

    // Перегрузка оператора ==
    bool operator==(const String& other) const {
        return strcmp(data, other.data) == 0;
    }

    // Перегрузка оператора !=
    bool operator!=(const String& other) const {
        return !(*this == other);
    }

    // Перегрузка оператора >
    bool operator>(const String& other) const {
        return strcmp(data, other.data) > 0;
    }

    // Перегрузка оператора <
    bool operator<(const String& other) const {
        return strcmp(data, other.data) < 0;
    }

    // Перегрузка оператора +
    String operator+(const String& other) const {
        size_t newLength = length + other.length;
        char* newData = new char[newLength + 1];
        strcpy_s(newData, newLength + 1, data);
        strcat_s(newData, newLength + 1, other.data);
        String result(newData);
        delete[] newData;
        return result;
    }

    // Перегрузка оператора +=
    String& operator+=(const String& other) {
        size_t newLength = length + other.length;
        char* newData = new char[newLength + 1];
        strcpy_s(newData, newLength + 1, data);
        strcat_s(newData, newLength + 1, other.data);
        delete[] data;
        data = newData;
        length = newLength;
        return *this;
    }

    // Перегрузка оператора присваивания =
    String& operator=(const String& other) {
        if (this != &other) {
            delete[] data;
            length = other.length;
            data = new char[length + 1];
            strcpy_s(data, length + 1, other.data);
        }
        return *this;
    }
};

int String::objectCount = 0;

int main() {
    std::cout << "Project: CustomStringLib (Safe Version)\n\n";

    String s1;
    s1.display();

    String s2(20);
    s2.display();

    String s3("Hello");
    s3.display();

    s2.input();
    s2.display();

    String s4 = s3 + s2;
    s4.display();

    s3 += s2;
    s3.display();

    std::cout << "Number of String objects: " << String::getObjectCount() << std::endl;

    return 0;
}
