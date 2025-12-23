// ConsoleApplication2.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
using namespace std;
int main()
{
	try {
		throw 1;
	}
	catch (...)
	{
		cout << "Error" << endl;
	}
   
}

