// TowerOfHanoi.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>

void towerOfHanoi(int n, int A, int B, int C)
{
    if (n > 0)
    {
        // from A to C, using B
        towerOfHanoi(n - 1, A, C, B);
        printf("Moving from %d to %d\n", A, C);
        // from B to A, using C
        towerOfHanoi(n - 1, B, A, C);
    }
}

int main()
{
    std::cout << "Tower of Hanoi!\n";
    towerOfHanoi(3, 1, 2, 3);
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
