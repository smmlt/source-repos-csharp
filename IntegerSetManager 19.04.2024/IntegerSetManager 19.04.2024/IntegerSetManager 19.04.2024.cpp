#include <iostream>
#include <vector>
#include <algorithm>

class IntegerSet {
private:
    std::vector<int> elements;

    // Упорядочивание элементов и удаление повторов
    void normalize() {
        std::sort(elements.begin(), elements.end());
        elements.erase(std::unique(elements.begin(), elements.end()), elements.end());
    }

public:
    // Default constructor
    IntegerSet() {
        std::cout << "Default IntegerSet created." << std::endl;
    }

    // Constructor with parameters
    IntegerSet(const std::vector<int>& elems) : elements(elems) {
        normalize();
        std::cout << "IntegerSet created with elements." << std::endl;
    }

    // Copy constructor
    IntegerSet(const IntegerSet& other) : elements(other.elements) {
        std::cout << "IntegerSet copied." << std::endl;
    }

    // Destructor
    ~IntegerSet() {
        std::cout << "IntegerSet destroyed." << std::endl;
    }

    // Check if element exists
    bool contains(int value) const {
        return std::find(elements.begin(), elements.end(), value) != elements.end();
    }

    // Add element (+)
    IntegerSet operator+(int value) const {
        IntegerSet result(*this);
        result += value;
        return result;
    }

    // Add element (+=)
    IntegerSet& operator+=(int value) {
        if (!contains(value)) {
            elements.push_back(value);
            normalize();
            std::cout << "Element " << value << " added." << std::endl;
        }
        else {
            std::cout << "Element " << value << " already exists." << std::endl;
        }
        return *this;
    }

    // Remove element (-)
    IntegerSet operator-(int value) const {
        IntegerSet result(*this);
        result -= value;
        return result;
    }

    // Remove element (-=)
    IntegerSet& operator-=(int value) {
        auto it = std::find(elements.begin(), elements.end(), value);
        if (it != elements.end()) {
            elements.erase(it);
            std::cout << "Element " << value << " removed." << std::endl;
        }
        else {
            std::cout << "Element " << value << " not found." << std::endl;
        }
        return *this;
    }

    // Assignment operator
    IntegerSet& operator=(const IntegerSet& other) {
        if (this != &other) {
            elements = other.elements;
            std::cout << "IntegerSet assigned." << std::endl;
        }
        return *this;
    }

    // Equality operator
    bool operator==(const IntegerSet& other) const {
        return elements == other.elements;
    }

    // Stream output
    friend std::ostream& operator<<(std::ostream& os, const IntegerSet& set) {
        os << "{ ";
        for (size_t i = 0; i < set.elements.size(); ++i) {
            os << set.elements[i];
            if (i != set.elements.size() - 1) os << ", ";
        }
        os << " }";
        return os;
    }

    // Stream input
    friend std::istream& operator>>(std::istream& is, IntegerSet& set) {
        int n, value;
        std::cout << "Enter number of elements: ";
        is >> n;
        std::vector<int> temp;
        std::cout << "Enter elements: ";
        for (int i = 0; i < n; ++i) {
            is >> value;
            temp.push_back(value);
        }
        set = IntegerSet(temp);
        return is;
    }
};

int main() {
    std::cout << "=== IntegerSetManager Project ===" << std::endl;

    IntegerSet A({ 3, 5, 8, 11, 36 });
    IntegerSet B({ -1, 4, 7, 12, 15 });

    std::cout << "Set A: " << A << std::endl;
    std::cout << "Set B: " << B << std::endl;

    A += 4;
    std::cout << "Set A after adding 4: " << A << std::endl;

    A -= 8;
    std::cout << "Set A after removing 8: " << A << std::endl;

    std::cout << "Does A contain 11? " << (A.contains(11) ? "Yes" : "No") << std::endl;

    IntegerSet C = A + 20;
    std::cout << "Set C (A + 20): " << C << std::endl;

    std::cout << "Are A and B equal? " << (A == B ? "Yes" : "No") << std::endl;

    return 0;
}
