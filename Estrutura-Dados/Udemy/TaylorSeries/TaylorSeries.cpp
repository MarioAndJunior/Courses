// TaylorSeries.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
//            2   3   4
//e = 1 + x   x   x   x
//        - + - + - + - + n termos
//        1   2!  3!  4!
// x eh o valor e n eh o numero de termos, quanto mais termos mais correto o resultado
double e(int x, int n)
{
    //dois estaticos para manter o resultado entre as chamadas
    static double p = 1;
    static double f = 1;
    double result;

    // caso base (tanto da recursão como da serie)
    if (n == 0)
    {
        return 1;
    }

    // chamada recursiva para passar por todos os termos
    result = e(x, n - 1);
    // faz a potenciacao e o fatorial em tempo de retorno (meio que fica de tras pra frente)
    p = p * x;
    f = f * n;

    // soma no retorno
    return result + p / f;
}

int main()
{
    std::cout << "Taylor Series\n";
    std::cout << e(3, 10) << std::endl;
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
