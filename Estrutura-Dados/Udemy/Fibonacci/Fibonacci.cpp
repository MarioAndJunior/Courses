// Fibonacci.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>

int* fibMemorization;

int fibIteration(int n)
{
    if (n <= 1)
    {
        return n;
    }

    int term0 = 0;
    int term1 = 1;
    int result = 0;

    for (int i = 2; i <= n; i++)
    {
        result = term0 + term1;
        term0 = term1;
        term1 = result;
    }

    return result;
}

int fibRecursive(int n)
{
    std::cout << "called without memo" << std::endl;
    if (n <= 1)
    {
        return n;
    }
    else
    {
        return fibRecursive(n - 1) + fibRecursive(n - 2);
    }
}

void initializeFibMemorization(int n)
{
    fibMemorization = new int[n];
    for (int i = 0; i < n; i++)
    {
        fibMemorization[i] = -1;
    }
}

int fibRecursiveWithMemorization(int n)
{
    std::cout << "called with memo" << std::endl;
    if (n <= 1)
    {
        fibMemorization[n] = n;
        return n;
    }
    else
    {
        if (fibMemorization[n - 2] == -1)
        {
            fibMemorization[n - 2] = fibRecursiveWithMemorization(n - 2);
        }

        if (fibMemorization[n - 1] == -1)
        {
            fibMemorization[n - 1] = fibRecursiveWithMemorization(n - 1);
        }

        return fibMemorization[n - 2] + fibMemorization[n - 1];
    }
}

int main()
{
    std::cout << "Fibonacci!\n";
    std::cout << fibIteration(6) << std::endl;
    std::cout << fibRecursive(6) << std::endl;
    initializeFibMemorization(6);
    std::cout << fibRecursiveWithMemorization(6) << std::endl;
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
