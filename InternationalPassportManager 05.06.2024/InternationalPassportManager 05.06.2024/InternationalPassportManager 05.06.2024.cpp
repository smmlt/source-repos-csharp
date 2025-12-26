#include <iostream>
#include <string>
#include <stdexcept>
#include <regex>

class ForeignPassport {
private:
    std::string passportNumber;
    std::string fullName;
    std::string issueDate;

public:
    ForeignPassport(const std::string& number, const std::string& name, const std::string& date) {
        setPassportNumber(number);
        setFullName(name);
        setIssueDate(date);
    }

    void setPassportNumber(const std::string& number) {
        if (!std::regex_match(number, std::regex("\\d{9}"))) {
            throw std::invalid_argument("Invalid passport number! It must be 9 digits.");
        }
        passportNumber = number;
    }

    void setFullName(const std::string& name) {
        if (name.empty()) {
            throw std::invalid_argument("Full name cannot be empty!");
        }
        fullName = name;
    }

    void setIssueDate(const std::string& date) {
        if (!std::regex_match(date, std::regex("\\d{4}-\\d{2}-\\d{2}"))) {
            throw std::invalid_argument("Invalid date format! Use YYYY-MM-DD.");
        }
        issueDate = date;
    }

    void displayInfo() const {
        std::cout << "Passport Information:" << std::endl;
        std::cout << "Passport Number: " << passportNumber << std::endl;
        std::cout << "Full Name: " << fullName << std::endl;
        std::cout << "Issue Date: " << issueDate << std::endl;
    }
};

int main() {
    try {
        ForeignPassport passport("123456789", "John Doe", "2022-05-15");
        passport.displayInfo();
    }
    catch (const std::exception& ex) {
        std::cerr << "Error: " << ex.what() << std::endl;
    }

    try {
        ForeignPassport badPassport("ABC123", "", "15-05-2022");
    }
    catch (const std::exception& ex) {
        std::cerr << "Error: " << ex.what() << std::endl;
    }

    return 0;
}
