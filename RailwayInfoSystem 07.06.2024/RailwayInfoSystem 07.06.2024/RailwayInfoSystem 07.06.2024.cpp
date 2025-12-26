#include <iostream>
#include <vector>
#include <algorithm> 
#include <string>

using namespace std;

struct Train {
    int number;
    string departureTime;
    string destination;
};

void addTrain(vector<Train>& trains) {
    Train t;
    cout << "Enter train number: ";
    cin >> t.number;
    cin.ignore(); 
    cout << "Enter departure time (HH:MM): ";
    getline(cin, t.departureTime);
    cout << "Enter destination station: ";
    getline(cin, t.destination);
    trains.push_back(t);
    cout << "Train added successfully.\n";
}

void showAllTrains(const vector<Train>& trains) {
    cout << "\nAll trains:\n";
    for (const auto& t : trains) {
        cout << "Number: " << t.number
            << ", Departure: " << t.departureTime
            << ", Destination: " << t.destination << "\n";
    }
}

void showTrain(const vector<Train>& trains) {
    int num;
    cout << "Enter train number to search: ";
    cin >> num;
    for (const auto& t : trains) {
        if (t.number == num) {
            cout << "Number: " << t.number
                << ", Departure: " << t.departureTime
                << ", Destination: " << t.destination << "\n";
            return;
        }
    }
    cout << "Train not found.\n";
}

void searchByDestination(const vector<Train>& trains) {
    cin.ignore();
    string dest;
    cout << "Enter destination station to search: ";
    getline(cin, dest);
    bool found = false;
    for (const auto& t : trains) {
        if (t.destination == dest) {
            cout << "Number: " << t.number
                << ", Departure: " << t.departureTime
                << ", Destination: " << t.destination << "\n";
            found = true;
        }
    }
    if (!found) {
        cout << "No trains found to " << dest << ".\n";
    }
}

void sortByDepartureTime(vector<Train>& trains) {
    sort(trains.begin(), trains.end(), [](const Train& a, const Train& b) {
        return a.departureTime < b.departureTime;
        });
    cout << "Trains sorted by departure time.\n";
}

int main() {
    vector<Train> trains;
    int choice;
    do {
        cout << "\n--- Railway Info System ---\n";
        cout << "1. Add train\n";
        cout << "2. Show all trains\n";
        cout << "3. Show train by number\n";
        cout << "4. Search train by destination\n";
        cout << "5. Sort trains by departure time\n";
        cout << "0. Exit\n";
        cout << "Enter your choice: ";
        cin >> choice;

        switch (choice) {
        case 1: addTrain(trains); break;
        case 2: showAllTrains(trains); break;
        case 3: showTrain(trains); break;
        case 4: searchByDestination(trains); break;
        case 5: sortByDepartureTime(trains); break;
        case 0: cout << "Exiting system.\n"; break;
        default: cout << "Invalid choice. Try again.\n";
        }
    } while (choice != 0);

    return 0;
}
