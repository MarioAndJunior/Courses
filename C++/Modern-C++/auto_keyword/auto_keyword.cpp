// auto_keyword.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
#include <typeinfo>

using namespace std;

// sem o -> bool tambem funciona
auto test() -> bool
{
    return true;
}

// sem o decltype tambem funciona, nao sei se eh o compilador ou a versao do c++
template<class T>
auto test2(T value) -> decltype(value)
{
    return value;
}

template<class T, class S>
auto sum(T value1, S value2) -> decltype(value1)
{
    cout << typeid(value1).name() << endl;
    cout << typeid(value1).raw_name() << endl;
    cout << typeid(value1).hash_code() << endl;

    return value1 + value2;
}

int main()
{
    auto value = 7;
    
    cout << value << endl;

    cout << typeid(value).name() << endl;
    cout << typeid(value).raw_name() << endl;
    cout << typeid(value).hash_code() << endl;

    cout << test() << endl;

    cout << test2(7) << endl;
    cout << test2("Hello") << endl;

    string first = "Hello ";
    string second = "world";
    cout << sum(first, second) << endl;
    cout << sum(6, 7) << endl;
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
