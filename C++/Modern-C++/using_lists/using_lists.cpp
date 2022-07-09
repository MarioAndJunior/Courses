#include <iostream>
#include <list>

using namespace std;

int main()
{
    list<int> numbers;

    numbers.push_back(1);
    numbers.push_back(2);
    numbers.push_back(3);
    numbers.push_front(0);// primeiro elemento

    list<int>::iterator it1 = numbers.begin();
    it1++;
    numbers.insert(it1, 100);
    
    list<int>::iterator it2 = numbers.begin();

    while (it2 != numbers.end())
    {
        if (*it2 == 2)
        {
            numbers.insert(it2, 123456);
        }
        if (*it2 == 3)
        {
            it2 = numbers.erase(it2);
        }

        if (it2 != numbers.end())
        {
            it2++;
        }
    }
    for (list<int>::iterator it = numbers.begin(); it != numbers.end(); it++)
    {
        cout << *it << endl;
    }

    system("pause");
    return 0;
}