#include <iostream>
#include <string>
#include <sstream>
#include <algorithm>
using namespace std;

class DynamicArray {
private:
    int* data;
    int size;

public:
    // Default constructor
    DynamicArray() : data(nullptr), size(0) {}

    // Constructor with size parameter
    DynamicArray(int n) : size(n) {
        data = new int[size];
        for (int i = 0; i < size; ++i)
            data[i] = 0;
    }

    // Copy constructor
    DynamicArray(const DynamicArray& other) : size(other.size) {
        data = new int[size];
        for (int i = 0; i < size; ++i)
            data[i] = other.data[i];
    }

    // Destructor
    ~DynamicArray() {
        delete[] data;
    }

    // Assignment operator
    DynamicArray& operator=(const DynamicArray& other) {
        if (this == &other)
            return *this;
        delete[] data;
        size = other.size;
        data = new int[size];
        for (int i = 0; i < size; ++i)
            data[i] = other.data[i];
        return *this;
    }

    // Subscript operator for getting/setting
    int& operator[](int index) {
        if (index < 0 || index >= size) {
            cout << "Index out of bounds!" << endl;
            exit(1);
        }
        return data[index];
    }

    // Operator () to increase all elements by a value
    void operator()(int value) {
        for (int i = 0; i < size; ++i)
            data[i] += value;
    }

    // Operator () to print statistics (average, min, max)
    void operator()() const {
        if (size == 0) {
            cout << "Array is empty." << endl;
            return;
        }
        int minVal = data[0];
        int maxVal = data[0];
        int sum = 0;
        for (int i = 0; i < size; ++i) {
            sum += data[i];
            if (data[i] < minVal) minVal = data[i];
            if (data[i] > maxVal) maxVal = data[i];
        }
        double avg = static_cast<double>(sum) / size;
        cout << "Array statistics: Average = " << avg
            << ", Min = " << minVal
            << ", Max = " << maxVal << endl;
    }

    // Overload << operator for output
    friend ostream& operator<<(ostream& os, const DynamicArray& arr) {
        os << "[";
        for (int i = 0; i < arr.size; ++i) {
            os << arr.data[i];
            if (i != arr.size - 1)
                os << ", ";
        }
        os << "]";
        return os;
    }

    // Operator + for array + array
    DynamicArray operator+(const DynamicArray& other) const {
        DynamicArray result(size + other.size);
        for (int i = 0; i < size; ++i)
            result[i] = data[i];
        for (int i = 0; i < other.size; ++i)
            result[i + size] = other.data[i];
        return result;
    }

    // Operator += for array += array
    DynamicArray& operator+=(const DynamicArray& other) {
        *this = *this + other;
        return *this;
    }

    // Operator + for array + number
    DynamicArray operator+(int value) const {
        DynamicArray result(size);
        for (int i = 0; i < size; ++i)
            result[i] = data[i] + value;
        return result;
    }

    // Operator += for array += number
    DynamicArray& operator+=(int value) {
        for (int i = 0; i < size; ++i)
            data[i] += value;
        return *this;
    }

    // Comparison operators by array equality
    bool operator==(const DynamicArray& other) const {
        if (size != other.size) return false;
        for (int i = 0; i < size; ++i)
            if (data[i] != other.data[i])
                return false;
        return true;
    }

    bool operator!=(const DynamicArray& other) const {
        return !(*this == other);
    }

    // Comparison operators by size
    bool operator>(const DynamicArray& other) const {
        return size > other.size;
    }

    bool operator<(const DynamicArray& other) const {
        return size < other.size;
    }

    // Type conversion operators
    operator int() const { return size; }

    operator double() const {
        if (size == 0) return 0.0;
        double sum = 0;
        for (int i = 0; i < size; ++i)
            sum += data[i];
        return sum / size;
    }

    operator string() const {
        ostringstream oss;
        oss << "[";
        for (int i = 0; i < size; ++i) {
            oss << data[i];
            if (i != size - 1) oss << ", ";
        }
        oss << "]";
        return oss.str();
    }
};

int main() {
    DynamicArray arr1(5);
    for (int i = 0; i < 5; ++i)
        arr1[i] = i + 1;

    cout << "Array 1: " << arr1 << endl;

    DynamicArray arr2 = arr1;
    arr2 += 5;
    cout << "Array 2 after adding 5 to each element: " << arr2 << endl;

    DynamicArray arr3 = arr1 + arr2;
    cout << "Array 3 (arr1 + arr2): " << arr3 << endl;

    arr1(2); // increase all elements by 2
    cout << "Array 1 after incrementing each element by 2: " << arr1 << endl;

    arr1(); // print statistics of arr1

    cout << "Size of arr3 (int): " << int(arr3) << endl;
    cout << "Average of arr3 (double): " << double(arr3) << endl;
    cout << "Array 3 as string: " << string(arr3) << endl;

    cout << "Are arr1 and arr2 equal? " << (arr1 == arr2 ? "Yes" : "No") << endl;
    cout << "Is arr1 bigger than arr2? " << (arr1 > arr2 ? "Yes" : "No") << endl;

    return 0;
}
