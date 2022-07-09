// template_functions.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>

using namespace std;

template<typename T>
void print(T type)
{
    cout << "Template: " << type << endl;
}

void print(int n)
{
    cout << "Non-template: " << n << endl;
}

template<typename T>
void show()
{
    cout << "Template show: " << T() << endl;
}

int main()
{
    print(5);

    print<string>("Hello there!");

    print(6);
    print<int>(6);

    print<>(3);

    //Nao compila pq o compilador nao sabe qual eh o tipo
    //show();

    show<double>();

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
