// Power.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>

int pow(int m, int n)
{
    if (n == 0)
    {
        return 1;
    }
    std::cout << __func__ << " iterou" << std::endl;
    return pow(m, n - 1) * m;
}

int superPow(int m, int n)
{
    if (n == 0)
    {
        return 1;
    }

    if (n % 2 == 0)
    {
        std::cout << __func__ << " iterou" << std::endl;
        return superPow(m * m, n / 2);
    }
    else
    {
        std::cout << __func__ << " iterou" << std::endl;
        return m * superPow(m * m, (n - 1) / 2);
    }
}

int loopPow(int m, int n)
{
    int res = 1;
    for (int i = 1; i <= n; i++)
    {
        std::cout << __func__ << " iterou" << std::endl;
        res *= m;
    }
    return res;
}

int main()
{
    std::cout << "Power!\n";

    std::cout << pow(2, 12) << std::endl;
    std::cout << superPow(2, 12) << std::endl;
    std::cout << loopPow(2, 12) << std::endl;
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
