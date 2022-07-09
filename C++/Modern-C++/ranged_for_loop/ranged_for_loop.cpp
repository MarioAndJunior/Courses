// ranged_for_loop.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
#include <vector>
using namespace std;

int main()
{
    //auto facilita muito aqui (const char* texts[])
    auto texts = { "one", "two", "three", "four" };

    for (auto text : texts)
    {
        cout << text << endl;
    }

    vector<int> numbers;

    numbers.push_back(1);
    numbers.push_back(2);
    numbers.push_back(3);
    numbers.push_back(4);

    for (auto number : numbers)
    {
        cout << number << endl;
    }

    //somente para exemplificar o uso do auto para o iterator
    for (auto it = numbers.begin(); it != numbers.end(); it++)
    {
        cout << *it << endl;
    }

    string hello = "hello";

    for (auto c : hello)
    {
        cout << c << endl;
    }
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
