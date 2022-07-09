#include <iostream>
#include <map>

using namespace std;

class Person
{
public:
	Person() : name(""), age(0)
	{

	}
	Person(string name, int age) : name(name), age(age)
	{

	}
	Person(const Person& other)
	{
		name = other.name;
		age = other.age;

		cout << "copy constructor called" << endl;
	}

	~Person()
	{

	}

	bool operator<(const Person& other) const
	{
		if (name == other.name)
		{
			return age < other.age;
		}

		return name < other.name;
	}

	void print() const
	{
		cout << name << ": " << age << flush;
	}

private:
	string name;
	int age;
};


int main()
{
	//Objetos proprios como valor
	/*map<int, Person> people;

	people[0] = Person("Mike", 40);
	people[1] = Person("Vicky", 30);
	people[2] = Person("Raj", 20);

	people.insert(make_pair(10, Person("mario", 35)));
	people.insert(make_pair(12, Person("kathy", 38)));

	for (map<int, Person>::iterator it = people.begin(); it != people.end(); it++)
	{
		cout << it->first << ": ";
		it->second.print();
		cout << endl;
	}*/

	//Objetos proprios como chave
	map<Person, int> people;

	people[Person("Mike", 40)] = 0;
	people[Person("Mike", 444)] = 123;
	people[Person("Vicky", 30)] = 1;
	people[Person("Raj", 20)] = 2;

	for (map<Person, int>::iterator it = people.begin(); it != people.end(); it++)
	{
		cout << it->second << ": ";
		it->first.print();
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
