// cpp_98_initialization.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
#include <vector>
using namespace std;

int main()
{
    const char* words[] = { "one", "two", "three" };

    cout << words[0] << endl;

    class C
    {
    public:
        string name;
        int age;
    };

    C c1 = { "Mario", 35 };

    cout << c1.name << endl;

    struct S
    {
        string name;
        int age;
    };

    S s1 = { "Maria", 6 };

    cout << s1.name << endl;

    struct
    {
        string text;
        int age;
    } r1 = { "Kathy", 37 }, r2 = { "Bete", 60 };

    cout << r1.text << endl;
    cout << r2.age << endl;

    vector<string> strings;
    strings.push_back("one");
    strings.push_back("two");
    strings.push_back("three");
    cout << strings[0] << endl;
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
