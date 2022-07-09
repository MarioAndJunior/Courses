#include <iostream>
#include <map>

using namespace std;

int main()
{
    map<string, int> ages;

    ages.insert(make_pair("Peter", 40));

    ages["Mario"] = 35;
    ages["Kathy"] = 37;
    ages["Maria"] = 6;

    cout << ages["Mario"] << endl;

    if (ages.find("Kathy") != ages.end())
    {
        cout << "Encontramos a Kathy" << ", sua idade: " << ages["Kathy"] << endl;
    }
    else
    {
        cout << "Kathy não encontrada" << endl;
    }

    for (map <string, int>::iterator it = ages.begin(); it != ages.end(); it++)
    {
        pair<string, int> age = *it;
        cout << age.first << " : " << age.second << endl;
    }
    
    system("pause");
    return 0;
}
