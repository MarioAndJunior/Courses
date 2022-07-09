// bind.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
#include <functional>

using namespace std;
using namespace placeholders;

class Test
{
public:
    int add(int a, int b, int c)
    {
        cout << a << ", " << b << ", " << c << endl;
        return a + b + c;
    }
};
int add(int a, int b, int c)
{
    cout << a << ", " << b << ", " << c << endl;
    return a + b + c;
}

int run(function<int(int, int)> func)
{
    return func(7, 3);
}

int main()
{
    auto calculate = bind(add, 5, 6, 7);
    cout << calculate(1, 2, 3) << endl;

    auto calculat = bind(add, _2, _3, _1);
    cout << calculat(10, 20, 30) << endl;

    auto calc = bind(add, _2, 100, _1);
    cout << calc(10, 20) << endl;

    cout << run(calc) << endl;

    Test test;
    auto calcClass = bind(&Test::add, test, _2, 100, _1);

    cout << run(calcClass) << endl;
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
