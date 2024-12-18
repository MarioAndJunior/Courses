#include <iostream>

using namespace std;

struct Rectangle
{
	int length;
	int breadth;
	char x;
};

template<class T>
class Arithmetic 
{
private:
	T a;
	T b;
public:
	Arithmetic(T a, T b) 
	{
		this->a = a;
		this->b = b;
	}
	~Arithmetic()
	{
		cout << "Arithmetic on " << this << " destroyed" << endl;
	}

	T add()
	{
		return a + b;
	}

	T sub()
	{
		return a - b;
	}
};

void playWithArrays()
{
	int A[5] = {};
	A[0] = 15;
	A[1] = 15;
	A[2] = 25;

	cout << sizeof(A) << endl;
	cout << sizeof(A[0]) << endl;
	cout << A[0] << endl;

	printf("%d\n", A[4]);

	for (int i = 0; i < 5; i++)
	{
		printf("%d\n", A[i]);
	}

	for (int x : A)
	{
		printf("%d\n", x);
	}

	Rectangle r = { 10, 5 };
	r.breadth = 15;
	r.length = 10;
	printf("%llu\n", sizeof(r));
}

int main() 
{
	//playWithArrays();

	Arithmetic<int> a(10, 5);
	cout << a.add() << endl;
	cout << a.sub() << endl;

	Arithmetic<int> c(10, 5);
	cout << a.add() << endl;
	cout << a.sub() << endl;

	Arithmetic<float> b(10.8, 3.7);
	cout << b.add() << endl;
	cout << b.sub() << endl;

	cout << sizeof(int) << endl;
	cout << sizeof(char*) << endl;
	cout << &a << endl;
	cout << sizeof(a) << endl;
	cout << &b << endl;

	memcpy(&b, &a, sizeof(8));

	cout << memcmp(&a, &c, sizeof(Rectangle)) << endl;

	cout << b.add() << endl;
	cout << b.sub() << endl;
	return 0;
}