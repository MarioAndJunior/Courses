// obj_initialization_default_delete.cpp : This file contains the 'main' function. Program execution begins and ends there.
//
 
#include <iostream>
using namespace std;

class Test
{
private:
    int id{ 10 };
    string name{ "Mario" };

public:
    //se sobrecarregarmos o construtor nao compila, pois precisa do padrao
    Test() = default;
    Test(int id) : id(id)
    {

    }
    Test(const Test& other) = default;
    //Test(const Test& other) = delete; se colocar igual a delete eh o mesmo que desabilitar o metodo
    Test& operator=(const Test& other) = default;

    void print()
    {
        cout << "Id: " << this->id << " Name: " << this->name << endl;
    }
};
int main()
{
    Test t1;
    t1.print();

    Test t2(77);
    t2.print();

    Test t3 = t2;
    t3.print();

    t3 = t1;

    t3.print();
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
