// unique_pointers.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
#include <memory>
using namespace std;

class Test
{
private:
    int size{ 0 };
public:
    Test()
    {
        cout << "construida" << endl;
    }

    void greet()
    {
        cout << "Hello" << endl;
    }

    virtual ~Test()
    {
        cout << "destruida" << endl;
    }
};

class Temp
{
private:
    unique_ptr<Test[]> tests;
public:
    Temp() /*tests(new Test[10])*/
    {
        this->tests = make_unique<Test[]>(10);
    }
};
int main()
{
    //Um jeito de inicializar
    unique_ptr<int> pInt(new int);

    //Outro jeito, acho mais interessante
    unique_ptr<int> pInt2 = make_unique<int>();

    /*
        Lembrando que os unique pointers trem uma relacao de 1 para 1 com o objeto que apontam, quando o ponteiro sai de escopo o objeto eh deletado
        Outro ponto interessante eh que sao as chaves que definem o escopo
        https://iamsorush.com/posts/unique-pointers-cpp/#:~:text=Unique%20pointers%20are%20smart%20pointers%20that%20help%20us,They%20follow%20%E2%80%9CResource%20Acquisition%20Is%20Initialization%E2%80%9D%20%28RAII%29%20rule.
        Tao performatico quanto raw pointers
    */

    *pInt = 100;
    *pInt2 = 999;

    cout << pInt << endl;
    cout << pInt2 << endl;
    cout << *pInt << endl;
    cout << *pInt2 << endl;

    cout << typeid(pInt).name() << endl;
    cout << typeid(pInt).raw_name() << endl;
    cout << typeid(pInt).hash_code() << endl;

    // Tambem funciona com vetores
    unique_ptr<Test[]> tests = make_unique <Test[]>(10);

    tests[9].greet();

    cout << endl;

    Temp temp;
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
