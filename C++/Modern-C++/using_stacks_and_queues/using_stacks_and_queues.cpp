// using_stacks_and_queues.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
#include <stack>
#include <queue>

using namespace std;

class Test 
{
private:
    string name;

public:
    Test(string name) : name(name)
    {

    }

    ~Test()
    {
        //cout << "desctructor called" << endl;
    }

    void print()
    {
        cout << name << endl;
    }
};


int main()
{
    //LIFO
    stack<Test> testStack;

    testStack.push(Test("Mario"));
    testStack.push(Test("Maria"));
    testStack.push(Test("Kathy"));

    cout << endl;

    while (testStack.size() > 0)
    {
        Test& test = testStack.top();
        test.print();
        testStack.pop();
    }

    // Invalido, referenciado objeto destruido
   /* Test& test0 = testStack.top();
    testStack.pop();
    test0.print();*/

    ////Aqui eh copia
    //Test test1 = testStack.top();
    //test1.print();
    //testStack.pop();

    ////Aqui tambem
    //Test test2 = testStack.top();
    //testStack.pop();
    //testStack.pop();
    //test2.print();


    cout << "Agora com queue" << endl;

    //FIFO
    queue<Test> testQueue;

    testQueue.push(Test("Mario"));
    testQueue.push(Test("Maria"));
    testQueue.push(Test("Kathy"));

    cout << endl;

    //testQueue.back().print();
    //testQueue.front().print();

    while (testQueue.size() > 0)
    {
        Test& test = testQueue.front();
        test.print();
        testQueue.pop();
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
