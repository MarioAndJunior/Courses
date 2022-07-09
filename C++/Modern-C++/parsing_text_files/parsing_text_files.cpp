#include <iostream>
#include <fstream>
#include <string>

using namespace std;

int main()
{
    string fileName = "..\\parsing_text_files\\stats.txt";
    ifstream input;

    input.open(fileName);

    if (!input.is_open())
    {
        return 1;
    }

    while (input)
    {
        string line;
        getline(input, line, ':');

        int population;
        input >> population;

        cout << line << " -- " << population << endl;

        input >> ws;
        if (!input)
        {
            break;
        }
    }

    input.close();

    system("pause");
    input.close();
    return 0;
}