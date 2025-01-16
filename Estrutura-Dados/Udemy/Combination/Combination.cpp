// Combination.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>

typedef unsigned long long BigPositive;

BigPositive loopFactorial(int n)
{
    BigPositive result = 1;
    for (int i = 1; i <= n; i++)
    {
        result *= i;
    }

    return result;
}

BigPositive recursiveFactorial(int n)
{
    if (n == 0)
    {
        return 1;
    }

    return recursiveFactorial(n - 1) * n;
}

// nCr or nPr calculates the combination/ permutation of a given set. The number of possible combinations of a subset
// n          n!
//  C  =   --------
//   r     r!(n-r)!
BigPositive permutation(int n, int r)
{
    BigPositive numerator = 0;
    BigPositive denominator = 0;

    numerator = loopFactorial(n);
    denominator = loopFactorial(r) * loopFactorial(n - r);

    return numerator / denominator;
}

BigPositive recursevlyPermutation(int n, int r)
{
    if (n == r || r == 0)
    {
        return 1;
    }
    else
    {
        return recursevlyPermutation(n - 1, r - 1) + recursevlyPermutation(n - 1, r);
    }
}

int main()
{
    std::cout << "nCr!\n";
    std::cout << permutation(12, 6) << std::endl;
    std::cout << recursevlyPermutation(60, 6) << std::endl;
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
