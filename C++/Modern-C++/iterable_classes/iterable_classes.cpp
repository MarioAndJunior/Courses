// iterable_classes.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include "Ring.h"

int main()
{
    Ring<string> textring(3);

    textring.add("one");
    textring.add("two");
    textring.add("three");

    //C++ 98 style
    for (Ring<string>::iterator it = textring.begin(); it != textring.end(); it++)
    {
        cout << *it << endl;
    }

    cout << endl;

    //C++ 11 style
    for (auto value : textring)
    {
        cout << value << endl;
    }

    Ring<int> someNumbers{ 1,2,3,4,5,6,7,8,9 };
    for (auto value : someNumbers)
    {
        cout << value << endl;
    }

    Ring<string> someStrings{ "10","20","30","40","50","60","70","80","90" };
    for (auto value : someStrings)
    {
        cout << value << endl;
    }

    someStrings.print({ "one", "two", "three" });
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
