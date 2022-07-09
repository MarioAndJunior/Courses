// functional_types.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
#include <vector>
#include <algorithm>
#include <functional>

using namespace std;

class Check
{
public:
    bool operator()(string& text)
    {
        return text == "stars";
    }
} check1; // inicializando aqui por preguica mesmo
bool check(string& text)
{
    return text.size() == 4;
}

void run(function<bool(string&)> check)
{
    string text = "stars";
    cout << check(text) << endl;
}

int main()
{
    vector<string> someStrings{ "one", "two", "three", "four", "five", "six", "seven" };

    auto lambda = [](string test) {return test.size() == 3; };

    int count = -1;

    // Usando lambda
    count = count_if(someStrings.begin(), someStrings.end(), lambda);
    cout << count << endl;

    // Usando ponteiro de funcao
    count = count_if(someStrings.begin(), someStrings.end(), check);
    cout << count << endl;

    // Usando functor
    count = count_if(someStrings.begin(), someStrings.end(), check1);
    cout << count << endl;

    // Usando functor e functional type
    run(check1);

    //Usando lambda e functional type
    run(lambda);

    //Usando ponteiro de funcao e functional type
    run(check);

    //functional type como variavel local
    function<int(int, int)> add = [](int first, int second) {return first + second; };
    cout << add(1, 999) << endl;
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
