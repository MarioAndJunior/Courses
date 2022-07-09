// move_constructor.cpp : This file contains the 'main' function. Program execution begins and ends there.
//
#include <iostream>
#include <vector>
using namespace std;

class Test
{
private:
    static const int SIZE{ 100 };
    int* buffer{ nullptr };

public:
    Test()
    {
        cout << "construtor chamado" << endl;
        //maneira old school de inicializar os ponteiros
        //this->buffer = new int[SIZE];
        //memset(this->buffer, 0, sizeof(int) * SIZE);

        //maneira c++11 de inicializar os ponteiros
        //this->buffer = new int[SIZE]();

        //maneira independente de compilador e moderna de inicializar os ponteiros
        this->buffer = new int[SIZE] {};

        /*for (int i = 0; i < SIZE; i++)
        {
            int number = buffer[i];
            cout << number << endl;
        }*/
    }

    Test(int i)
    {
        cout << "construtor parametrizado chamado" << endl;
        this->buffer = new int[SIZE] {};

        for (int i = 0; i < SIZE; i++)
        {
            this->buffer[i] = 7 * i;
        }
    }

    virtual ~Test()
    {
        cout << "destrutor chamado" << endl;
        delete[] this->buffer;
    }

    Test(const Test& other)
    {
        cout << "construtor de copia chamado" << endl;
        this->buffer = new int[SIZE] {};
        memcpy(this->buffer, other.buffer, sizeof(int) * SIZE);
    }

    Test operator=(const Test& other)
    {
        cout << "operador de atribuicao chamado" << endl;
        this->buffer = new int[SIZE] {};
        memcpy(this->buffer, other.buffer, sizeof(int) * SIZE);

        return *this;
    }

    Test(Test&& other) noexcept
    {
        cout << "move costructor chamado" << endl;
        this->buffer = other.buffer;
        other.buffer = nullptr;
    }

    void printBuffer()
    {
        for (int i = 0; i < SIZE; i++)
        {
            int number = buffer[i];
            cout << number << " ";
        }
        cout << endl;
    }

    friend ostream& operator<<(ostream& out, const Test& test);
};


ostream& operator<<(ostream& out, const Test& test)
{
    out << "Ola, aqui eh a classe Test" << endl;
    return out;
}

Test getTest()
{
    return Test();
}

int main()
{
    vector<Test> tests;

    tests.push_back(Test(8));

    tests.at(0).printBuffer();
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
