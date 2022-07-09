// functors.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
using namespace std;

struct Test
{
    virtual bool operator()(string text) = 0;
    virtual ~Test() {};
};

struct MatchTest : public Test
{
    // Inherited via Test
    virtual bool operator()(string text) override
    {
        return text == "lion";
    }
};

void check(string text, Test& test)
{
    if (test(text))
    {
        cout << "match case" << endl;
    }
    else
    {
        cout << "Not a match" << endl;
    }
}

int main()
{
    string text = "lion";

    MatchTest match;

    check(text, match);
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
