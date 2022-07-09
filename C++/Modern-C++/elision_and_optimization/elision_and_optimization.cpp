// elision_and_optimization.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
#include <vector>
using namespace std;

class Test
{
public:
    Test()
    {
        cout << "construtor chamado" << endl;
    }

    virtual ~Test()
    {
        cout << "destrutor chamado" << endl;
    }

    Test(const Test& other)
    {
        cout << "construtor de copia chamado" << endl;
    }

    Test operator=(const Test& other)
    {
        cout << "operador de atribuicao chamado" << endl;
        return *this;
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
    Test test1 = getTest();

    cout << test1 << endl;

    vector<Test> tests;

    tests.push_back(Test());

    system("pause");
    return 0;
}

// APENAS PARA LEMBRAR -fno-elide-constructors. Testar no vs2008
// Run program: Ctrl + F5 or Debug > Start Without Debugging menu
// Debug program: F5 or Debug > Start Debugging menu

// Tips for Getting Started: 
//   1. Use the Solution Explorer window to add/manage files
//   2. Use the Team Explorer window to connect to source control
//   3. Use the Output window to see build output and other messages
//   4. Use the Error List window to view errors
//   5. Go to Project > Add New Item to create new code files, or Project > Add Existing Item to add existing code files to the project
//   6. In the future, to open this project again, go to File > Open > Project and select the .sln file
