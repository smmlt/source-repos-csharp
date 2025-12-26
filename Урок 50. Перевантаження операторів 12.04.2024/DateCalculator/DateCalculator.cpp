#include <iostream>
using namespace std;

class Date {
private:
    int day, month, year;

    bool isLeap(int y) const {
        return (y % 4 == 0 && y % 100 != 0) || (y % 400 == 0);
    }

    int daysInMonth(int m, int y) const {
        int days[] = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
        if (m == 2 && isLeap(y)) return 29;
        return days[m - 1];
    }

    int toDays() const {
        int d = day;
        for (int y = 0; y < year; ++y)
            d += isLeap(y) ? 366 : 365;
        for (int m = 1; m < month; ++m)
            d += daysInMonth(m, year);
        return d;
    }

public:
    Date(int d = 1, int m = 1, int y = 0) : day(d), month(m), year(y) {}

    int operator-(const Date& other) const {
        return this->toDays() - other.toDays();
    }

    Date operator+(int n) const {
        Date temp = *this;
        temp.day += n;
        while (temp.day > temp.daysInMonth(temp.month, temp.year)) {
            temp.day -= temp.daysInMonth(temp.month, temp.year);
            temp.month++;
            if (temp.month > 12) {
                temp.month = 1;
                temp.year++;
            }
        }
        return temp;
    }

    Date& operator++() {
        *this = *this + 1;
        return *this;
    }

    Date operator++(int) {
        Date temp = *this;
        *this = *this + 1;
        return temp;
    }

    Date& operator--() {
        *this = *this + (-1);
        return *this;
    }

    Date operator--(int) {
        Date temp = *this;
        *this = *this + (-1);
        return temp;
    }

    void print() const {
        cout << day << "/" << month << "/" << year << endl;
    }
};

int main() {
    Date d1(25, 12, 2025);
    Date d2(1, 1, 2025);

    cout << "Difference in days: " << d1 - d2 << endl;

    Date d3 = d2 + 100;
    cout << "Date after 100 days: ";
    d3.print();

    ++d3;
    cout << "After prefix ++: ";
    d3.print();

    d3++;
    cout << "After postfix ++: ";
    d3.print();

    --d3;
    cout << "After prefix --: ";
    d3.print();

    d3--;
    cout << "After postfix --: ";
    d3.print();

    return 0;
}
