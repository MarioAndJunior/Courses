#include <iostream>
#include <vector>

using namespace std;

int main()
{
    vector<string> strings;

    strings.push_back("one");
    strings.push_back("two");
    strings.push_back("three");

    for (int i = 0; i < strings.size(); i++)
    {
        cout << strings[i] << endl;
    }

    vector<string>::iterator it = strings.begin();
    cout << *it << endl;

    it += 2;
    cout << *it << endl;

    vector<string>::iterator it2 = strings.begin();

    for (it2; it2 != strings.end(); it2++)
    {
        cout << "Printing with iterator " << *it2 << endl;
    }

    vector<double> numbers(20);

    cout << "Size: " << numbers.size() << endl;

    int capacity = numbers.capacity();
    cout << "capacity: " << capacity << endl;

    for (int i = 0; i < 10000; i++)
    {
        if (numbers.capacity() != capacity)
        {
            capacity = numbers.capacity();
            cout << "capacity: " << capacity << "index: " << i << endl;
        }

        numbers.push_back(i);
    }

    numbers.resize(100);
    cout << "capacity: " << numbers.capacity() << endl;
    cout << "size: " << numbers.size() << endl;
    //cout << numbers[1000] << endl; exception

    numbers.clear();
    cout << "capacity: " << numbers.capacity() << endl;
    cout << "size: " << numbers.size() << endl;

    numbers.reserve(10000000);
    cout << "capacity: " << numbers.capacity() << endl;
    cout << "size: " << numbers.size() << endl;

    system("pause");
    return 0;
}
