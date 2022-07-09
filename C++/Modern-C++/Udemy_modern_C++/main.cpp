#include<iostream>

using namespace std;


void myghtGoWrong()
{
	bool error1 = false;
	bool error2 = true;

	if (error1)
	{
		throw "Something went wrong";
	}

	if (error2)
	{
		throw string("Something else went wrong");
	}
}
int main(void)
{
	//basic exception
	try
	{
		myghtGoWrong();
	}
	catch (string e)
	{
		cout << "Error description: " << e << endl;
	}

	
	

	cout << "Still running" << endl;
	return 0;
}