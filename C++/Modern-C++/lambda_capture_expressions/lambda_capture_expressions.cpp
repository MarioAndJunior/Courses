// lambda_capture_expressions.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
using namespace std;

int main()
{
    int one = 1;
    int two = 2;
    int three = 3;

    //Expressao lambda valida, mas que faz nada
    []() {}();

    //Expressao lambda que captura duas variaveis by value
    [one, two]() {cout << one << ", " << two << endl; }();

    //Expressao lambda que captura todas as variaveis locais by value
    [=]() {cout << one << ", " << two << ", " << three << endl; }();

    //Expressao lambda que captura duas by value e uma by reference
    [=, &three]() {three = 100;  cout << one << ", " << two << ", " << three << endl; }();

    //Expressao lambda que captura todas by reference
    [&]() {three = 3; cout << one << ", " << two << ", " << three << endl; }();

    //Expressao lambda que captura duas by reference e uma by value
    [&, three]() {/*three = 100;*/ cout << one << ", " << two << ", " << three << endl; }();
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
