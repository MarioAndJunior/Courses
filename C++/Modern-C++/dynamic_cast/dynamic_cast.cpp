// dynamic_cast.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
using namespace std;

class Parent
{
public:
    virtual void speak()
    {
        cout << "Parent aqui!" << endl;
    }
};

class Brother : public Parent
{

};

class Sister : public Parent
{

};

int main()
{
    Parent parent;
    Brother brother;

    Parent* ppb = &parent;

    //dynamic_cast faz uma validacao em runtime e devolve nullptr se os tipos convertidos nao fazem sentido, mais seguro
    Brother* pbb = dynamic_cast<Brother*>(ppb);

    if (pbb == nullptr)
    {
        cout << "cast invalido" << endl;
    }

    return 0;
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
