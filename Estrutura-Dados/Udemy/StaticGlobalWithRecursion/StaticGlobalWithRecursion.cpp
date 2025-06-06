// StaticGlobalWithRecursion.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
using namespace std;

int fun(int n)
{
    static int x = 0;

    if (n > 0)
    {
        x++;
        return fun(n - 1) + x;
    }

    return 0;
}

int fun(int n, int x)
{
    if (n > 0)
    {
        x++;
        return fun(n - 1, x) + x;
    }

    return 0;
}

int main()
{
    int n = 5;
    int x = 0;

    cout << fun(n) << endl;
    cout << fun(n) << endl;
    cout << fun(n, x) << endl;
    cout << fun(n, x) << endl;

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
