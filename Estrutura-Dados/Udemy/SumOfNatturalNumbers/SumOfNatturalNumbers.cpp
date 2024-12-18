// SumOfNatturalNumbers.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
#include <chrono>
#include <thread>

typedef std::chrono::high_resolution_clock Time;
typedef std::chrono::milliseconds Ms;
typedef std::chrono::duration<float> Fsec;

int recursiveSum(int n)
{
    if (n == 0)
    {
        return n;
    }

    return recursiveSum(n - 1) + n;
}

int loopSum(int n)
{
    int result = 0;
    for (int i = 1; i <= n; i++)
    {
        result += i;
    }

    return result;
}

int formulaSum(int n)
{
    return n * (n + 1) / 2;
}

int main()
{
    std::cout << "Sum of natural\n";
    
    
    auto t0 = Time::now();

    std::cout << recursiveSum(10) << std::endl;
    std::cout << loopSum(10) << std::endl;
    std::cout << formulaSum(10) << std::endl;
    //Ms napTime(200);
    //std::this_thread::sleep_for(napTime);

    auto t1 = Time::now();
    Fsec fs = t1 - t0;
    Ms d = std::chrono::duration_cast<Ms>(fs);
    std::cout << "Levou " << d.count() << " ms" << std::endl;

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
