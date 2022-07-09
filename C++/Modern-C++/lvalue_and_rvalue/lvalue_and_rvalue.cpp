// lvalue_and_rvalue.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
#include <vector>
using namespace std;

class Test
{
private:
    static const int SIZE{ 100 };
    int* buffer;

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

void check(Test& lValue)
{
    cout << "funcao lValue!!!" << endl;
}

void check(Test&& rValue)
{
    cout << "funcao rValue!!!" << endl;
}

int main()
{
    Test test1 = getTest();

    cout << test1 << endl;
    //test1.printBuffer();

    vector<Test> tests;

    tests.push_back(Test());

    //i eh um lvalue e 7 eh um rvalue
    int i = 7;

    int* pI = &i;
    cout << *pI << endl;

    //nao compila pois 7 eh um rvalue e nao podemos referencia-lo
    //int* p7 = &7;

    //Como test1 eh um lvalue funciona sem problemas
    Test* pTest = &test1;
    cout << *pTest << endl;

    //Nao funciona pois retornos de funcoes sao coniderados rvalues
    /*Test& pTest2 = getTest();
    cout << pTest2 << endl;*/

    //funciona pelo pre decremento
    int* pI2 = &++i;
    cout << *pI2 << endl;

    //pelo pos nao, pois o compilador trabalha com variavel temporaria que eh rvalue
    //int* pI3 = &i++;

    //nao funciona pois a expressao se torna um rvalue, variaveis temporarias
    //int* pI4 = &(7 + i);


    printf("\n\n\n");
    cout << "Testes com lvalues" << endl;
    /****************************lValue***********************************/

    Test& lTest = test1;
    //Se deixarmos a referencia como const funciona, pois isso "extende a vida util do retorno de funcao temporario"
    const Test& lTest2 = getTest();

    Test test2(Test());

    printf("\n\n\n");
    cout << "Testes com rvalues" << endl;
    /****************************rValue**********************************/

    //Eh possivel referenciar os rvalues com dois & (&&)

    Test& lTest1 = test1;
    Test&& rTest1 = getTest();

    check(lTest1);
    check(getTest());
    check(Test());

    return 0;
}

/*Como regra "geral" lValues sao variaveis que podemos obter os seus esnderecos (trabalhar com suas referencias)
lValue e rValue vem de left and right mesmo, referindo-se aos lados de uma operacao de atribuicao
*/