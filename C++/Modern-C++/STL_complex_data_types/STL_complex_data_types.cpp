// STL_complex_data_types.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
#include <vector>
#include <map>

using namespace std;

int main()
{
    map<string, vector<int> > scores;

    scores["Mario"].push_back(10);
    scores["Mario"].push_back(20);
    scores["Kathy"].push_back(15);

    for (map<string, vector<int> >::iterator it = scores.begin(); it != scores.end(); it++)
    {
        string name = it->first;
        vector<int> scoreList = it->second;

        cout << name << ": " << flush;

        for (int i = 0; i < scoreList.size(); i++)
        {
            cout << scoreList[i] << " " << flush;
        }

        cout << endl;
    }
    system("pause");

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
