// lambda_expression_params.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
using namespace std;

void testGreet(void (*pGreet)(string))
{
    if (pGreet)
    {
        pGreet("Maria");
    }
}

void testDivide(double (*divide)(double a, double b))
{
    auto rVal = divide(9, 3);
    cout << rVal << endl;
}

int main()
{
    auto pGreet = [](string name) {cout << "Hello, " << name << endl; };

    pGreet("Mario");

    testGreet(pGreet);

    auto pDivide = [](double a, double b) ->double
    {
        if (b == 0)
        {
            return 0;
        }

        return a / b;
    };


    cout << pDivide(10.0, 5.0) << endl;
    cout << pDivide(15.0, 10.0) << endl;
    
    testDivide(pDivide);
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

