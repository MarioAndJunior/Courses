#include <iostream>
#include <exception>

using namespace std;

void goesWrong()
{
    bool error1Detected = true;
    bool error2Detected = false;

    if (error1Detected)
    {
        throw bad_alloc();
    }

    if (error2Detected)
    {
        throw exception();
    }
}

int main()
{
    //Nos catchs deve-se considerar primeiro as classes derivadas
    try
    {
        goesWrong();
    }
    catch (const bad_alloc& e)
    {
        cout << "bad_alloc: " << e.what() << endl;
    }
    catch (const exception& e)
    {
        cout << "Exception: " << e.what() << endl;
    }

    std::cout << "Hello World!\n";
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
