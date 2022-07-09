// abstract_classes_puer_virtual_functions.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
using namespace std;

class Animal
{
public:
    virtual void speak() = 0;
};

class Dog : public Animal
{
public:

    virtual void run() = 0;
    // Inherited via Animal
    virtual void speak() override
    {
        cout << "Woof!" << endl;
    }

};

class Labrador : public Dog
{
public:
    // Inherited via Dog
    virtual void run() override
    {
        cout << "Labrador running" << endl;
    }
};

int main()
{
    Dog* dogs[5] = { 0 };
    
    Labrador lab;
    lab.speak();
    lab.run();
    
    dogs[0] = &lab;

    dogs[0]->speak();
    dogs[0]->run();

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
