
// using_sets.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
#include <set>

using namespace std;

class Test
{
private:
    int id;
    string name;

public:
    Test() : id(0), name("")
    {

    }
    Test(int id, string name) : id(id), name(name)
    {
    }

    void print() const
    {
        cout << id << ": " << name << endl;
    }

    bool operator< (const Test& other) const
    {
        return name < other.name;
    }
};

int main()
{
    set<int> numbers;

    numbers.insert(12);
    numbers.insert(1);
    numbers.insert(85);
    numbers.insert(23);
    numbers.insert(101);
    numbers.insert(98);


    for (set<int>::iterator it = numbers.begin(); it != numbers.end(); it++)
    {
        cout << *it << endl;
    }

    set<Test> tests;

    tests.insert(Test(1, "Mario"));
    tests.insert(Test(2, "Maria"));
    tests.insert(Test(3, "Kathy"));
    tests.insert(Test(4, "Kathy"));

    for (set<Test>::iterator it = tests.begin(); it != tests.end(); it++)
    {
        it->print();
    }
    system("pause");
    return 0;
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
