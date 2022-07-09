// binary_files.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
#include <fstream>

using namespace std;

//#pragma pack(push, 1) //Fazems isso para retirar o padding da struct
struct Person
{
    char name[128];
    int age;
    double weight;
};
//#pragma pack(pop)

int main()
{

    Person someone = {"Mario", 35, 100.99};
    string fileName = ".\\test.bin";
    
    //Write
    ofstream outputFile;

    outputFile.open(fileName, ios::binary);

    if (outputFile.is_open())
    {
        outputFile.write(reinterpret_cast<char*>(&someone), sizeof(Person));
        outputFile.close();
    }
    else
    {
        cout << "Could not create file " + fileName << endl;
    }

    //Read
    Person someoneElse = {0};
    ifstream inputFile;

    inputFile.open(fileName, ios::binary);

    if (inputFile.is_open())
    {
        inputFile.read(reinterpret_cast<char*>(&someoneElse), sizeof(Person));
        inputFile.close();
    }
    else
    {
        cout << "Could not open file " + fileName << endl;
    }

    cout << someoneElse.name << ", " << someoneElse.age << ", " << someoneElse.weight << endl;

    system("pause");
    return 0;

}