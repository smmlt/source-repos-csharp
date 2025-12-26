#include <iostream>
#include <fstream>

#include "Header.h"
#include "Map.h"

using namespace std;

/* 1. Check if number is positive, negative or zero */
#define IS_POSITIVE(x) ((x) > 0 ? "Positive" : ((x) < 0 ? "Negative" : "Zero"))

/* 2. Check if number is even or odd */
#define IS_EVEN(x) ((x) % 2 == 0 ? "Even" : "Odd")

/* 3. Cube of a number */
#define CUBE(x) ((x) * (x) * (x))

/* 4. Check leap year */
#define IS_LEAP_YEAR(y) (((y) % 400 == 0) || ((y) % 4 == 0 && (y) % 100 != 0))

/* 5. Power without pow() */
#define POWER(base, exp) ([](int b, int e){ \
    int result = 1; \
    for (int i = 0; i < e; i++) result *= b; \
    return result; \
}(base, exp))

/* 6. Triangle semiperimeter */
#define SEMI_PERIMETER(a, b, c) (((a) + (b) + (c)) / 2.0)

/* 7. Can triangle be formed */
#define IS_TRIANGLE(a, b, c) (((a)+(b) > (c)) && ((a)+(c) > (b)) && ((b)+(c) > (a)))

/* 8. Print line */
#define PRINT_LINE(size, symbol) \
    { for (int i = 0; i < (size); i++) cout << (symbol); cout << endl; }

int main()
{
    int x = -5;
    int y = 4;

    cout << "Number x is: " << IS_POSITIVE(x) << endl;
    cout << "Number y is: " << IS_EVEN(y) << endl;

    cout << "Cube of y: " << CUBE(y) << endl;

    int year = 2024;
    cout << "Year " << year
        << (IS_LEAP_YEAR(year) ? " is a leap year" : " is not a leap year")
        << endl;

    cout << "2 to the power of 5 = " << POWER(2, 5) << endl;

    double a = 3, b = 4, c = 5;
    cout << "Triangle semiperimeter: " << SEMI_PERIMETER(a, b, c) << endl;

    cout << "Can a triangle be formed: "
        << (IS_TRIANGLE(a, b, c) ? "Yes" : "No") << endl;

    PRINT_LINE(10, '*');

    ofstream out("log.txt");
    if (!out.is_open())
    {
        cout << "Error opening file!" << endl;
        return 1;
    }

    out << "file:\n" << __FILE__ << endl;
    out << "line\n" << __LINE__ << endl;
    out << "function:\n" << __FUNCTION__ << endl;

    Hello(out);
    GoodBye(out);

    out << "....done" << endl;
    out.close();

    return 0;
}
