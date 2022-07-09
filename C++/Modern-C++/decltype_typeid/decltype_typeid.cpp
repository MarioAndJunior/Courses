// decltype_typeid.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
#include <typeinfo>

using namespace std;

int main()
{
    int value;

    cout << typeid(value).name() << endl;
    cout << typeid(value).raw_name() << endl;
    cout << typeid(value).hash_code() << endl;

    string value2;

    cout << typeid(value2).name() << endl;
    cout << typeid(value2).raw_name() << endl;
    cout << typeid(value2).hash_code() << endl;

    decltype(value2) value21;
    
    cout << typeid(value21).name() << endl;
    cout << typeid(value21).raw_name() << endl;
    cout << typeid(value21).hash_code() << endl;

    const char* value3;

    cout << typeid(value3).name() << endl;
    cout << typeid(value3).raw_name() << endl;
    cout << typeid(value3).hash_code() << endl;

    decltype(value3) value31;

    cout << typeid(value31).name() << endl;
    cout << typeid(value31).raw_name() << endl;
    cout << typeid(value31).hash_code() << endl;

}

// Run program: Ctrl + F5 or Debug > Start Without Debugging menu
// Debug program: F5 or Debug > Start Debugging menu

// Tips for Getting Started: 
//   1. Use the Solution Explorer window to add/manage files
//   2. Use the Team Explorer window to connect to source control
//   3. Use the Output window to see build output and other messages
//   4. Use the Error List window to view errors
//   5. Go to Project > Add New Item to create new code files, or Project > Add Existing Item to add existing code files to the project
//   6. In the future, to open this project again, go to File > Open > Project and select the .sln file
