// static_cast.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
using namespace std;

class Parent
{
public:
    void speak()
    {
        cout << "Parent aqui!" << endl;
    }
};

class Brother : public Parent
{
public:
    void talk()
    {
        cout << "brother aqui!" << endl;
    }
};

class Sister : public Parent
{

};

int main()
{
    float number = 3.1415;
    cout << (int)number << endl;
    cout << int(number) << endl;
    cout << static_cast<int>(number) << endl;


    Parent parent1;
    Brother brother1;
    
    Parent* pParent = &parent1;
    cout << pParent << endl;
    Brother* pBrother = &brother1;
    cout << pBrother << endl;

    Parent* ppb = &parent1;
    
    //Assim nao compila
    //Brother* pbb = ppb;
    
    //Static cast deve ser usado com cautela pois eh algo apenas em tempo de compilacao, sem muitas validacoes, caso tentemos acessar um membro de brother aqui vai ocasionar um crash
    Brother* pbb = static_cast<Brother*>(ppb);
    cout << ppb << endl;
    cout << pbb << endl;

    pbb->talk();

    Parent&& p = static_cast<Parent&&>(parent1);
    cout << &p << endl;

    p.speak();

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
