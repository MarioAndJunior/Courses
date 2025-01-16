// Array.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>

void array101();

void arrayHeapVsStack();
void printAll(int* array, int size);

int* increaseArraySize(int* p, int currentSize, int newSize);

void dynamicArray();

void twoDimentionalArray();

int main()
{
    std::cout << "Array!\n";
    //array101();
    //arrayHeapVsStack();
    //dynamicArray();

    twoDimentionalArray();
}

void twoDimentionalArray()
{
    //stack
    int A[3][4] = { { 1,2,3,4 },{ 2,4,6,8 },{ 3,5,7,9 } };
    for (int i = 0; i < 3; i++)
    {
        for (int j = 0; j < 4; j++)
        {
            std::cout << A[i][j] << ' ';
        }
    }

    //heap
    int* B[3]; // this one array is in stack

    B[0] = new int[4];
    B[1] = new int[4];
    B[2] = new int[4];
    B[1][2] = 15;

    std::cout << B[1][2] << std::endl;

    //heap with double pointer
    int** C; //only this pointer is in stack
    C = new int* [3];
    C[0] = new int[4];
    C[1] = new int[4];
    C[2] = new int[4];
}

void dynamicArray()
{
    int* p = new int[5];

    p[0] = 5;
    p[1] = 8;
    p[2] = 9;
    p[3] = 6;
    p[4] = 4;

    p = increaseArraySize(p, 5, 10);

    printAll(p, 10);
    delete[] p;
}

int* increaseArraySize(int* array, int currentSize, int newSize)
{
    int* p2 = new int[newSize];
    memcpy(p2, array, sizeof(array) * currentSize);

    delete[] array;
    array = p2;
    p2 = nullptr;

    return array;
}

void printAll(int* array, int size)
{
    for (int i = 0; i < size; i++)
    {
        std::cout << array[i] << ' ';
    }

    std::cout << std::endl;
}

void arrayHeapVsStack()
{
    int n = 5;
    //C++
    int* A = new int[n];
    A[0] = 3;
    A[1] = 5;
    A[2] = 7;
    A[3] = 9;
    A[4] = 11;
    A = (int*)malloc(sizeof(int) * n);

    int B[5] = { 2,4,6,8,10 };

    //C++
    delete[]A;
    //C
    free(A);
}

void array101()
{
    // scalar variable
    int x = 10;
    // array of 5 elements
    int A[5];
    A[2] = 15;
    std::cout << sizeof(A) << std::endl;
    std::cout << sizeof(int) << std::endl;
    std::cout << &A[0] << std::endl;
    std::cout << &A[1] << std::endl;
    std::cout << &A[2] << std::endl;
    std::cout << &A[3] << std::endl;
    std::cout << &A[4] << std::endl;
    std::cout << A << std::endl;
    std::cout << *(A + 2) << std::endl;
    std::cout << 2[A] << std::endl;

    int B[5] = { 2,4,6,8,10 };
    std::cout << *(B + 2) << std::endl;
    int C[5] = { 2,4 }; //2|4|0|0|0
    std::cout << *(C + 2) << std::endl;
    int D[5] = { 0 }; // all zeroes
    std::cout << *(D + 2) << std::endl;
    int E[] = { 2,4,6,8,10 };
    std::cout << sizeof(E) << std::endl;

    // traverse elemnts
    for (int i = 0; i < 5; i++)
    {
        std::cout << E[i] << ' ';
    }

    std::cout << std::endl;

    for (int i = 0; i < 5; i++)
    {
        printf("%u\n", (unsigned int)&E[i]);
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
