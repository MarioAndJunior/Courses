// shared_pointers.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
#include <memory>
using namespace std;

class Test
{
private:
    int size{ 0 };
public:
    Test()
    {
        cout << "construida" << endl;
    }

    void greet()
    {
        cout << "Hello" << endl;
    }

    virtual ~Test()
    {
        cout << "destruida" << endl;
    }
};

int main()
{

    shared_ptr<Test> pTest2{nullptr};

    {
        shared_ptr<Test> pTest1 = make_shared<Test>();
        pTest2 = pTest1;
        auto pTest3 = pTest1;
    }

    []() {cout << "Oi lambda" << endl; }();

    cout << "terminando" << endl;
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
