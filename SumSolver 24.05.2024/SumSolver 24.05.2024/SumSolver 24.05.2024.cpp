#include <iostream>
#include <string>
#include <regex>

using namespace std;

string replace_sums(const string& text) {
    string result = text;
    regex pattern(R"((\d+)([+-])(\d+))");
    smatch match;

    string::const_iterator searchStart(result.cbegin());
    while (regex_search(searchStart, result.cend(), match, pattern)) {
        int n1 = stoi(match[1].str());
        char op = match[2].str()[0];
        int n2 = stoi(match[3].str());
        int value = (op == '+') ? n1 + n2 : n1 - n2;

        result.replace(match.position(0) + (searchStart - result.cbegin()), match.length(0), to_string(value));

        searchStart = result.cbegin() + match.position(0) + (searchStart - result.cbegin()) + to_string(value).length();
    }

    return result;
}

int main() {
    string text = "alpha 5+26 beta 72-35 gamma 32+45 etc";

    cout << "Original text: " << text << endl;

    string new_text = replace_sums(text);
    cout << "Processed text: " << new_text << endl;

    return 0;
}
