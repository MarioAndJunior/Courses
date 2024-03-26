bool LinearSearch(int[] numbers, int itemToFind)
{
    int iterations = 0;
    for (int i = 0; i < numbers.Length; i++)
    {
        iterations++;
        if (numbers[i] == itemToFind)
        {
            Console.WriteLine($"Linear search iteractions with item found [{iterations}]");
            Console.WriteLine($"Item was at [{i}]");
            return true;
        }
    }

    Console.WriteLine($"Linear search iteractions with no item found [{iterations}]");
    return false;
}

bool BinarySearch(int[] numbers, int itemToFind)
{
    int iterations = 0;
    int minor = 0;
    int major = numbers.Length - 1;

    while ( minor <= major ) 
    {
        iterations++;
        int medium = (major + minor) / 2;
        if (numbers[medium] == itemToFind)
        {
            Console.WriteLine($"Binary search iteractions with item found [{iterations}]");
            Console.WriteLine($"Item was at [{medium}]");
            return true;
        }
        else if (numbers[medium] < itemToFind)
        {
            minor = medium + 1;
        }
        else
        {
            major = medium - 1;
        }
    }

    Console.WriteLine($"Binary search iteractions with no item found [{iterations}]");
    return false;
}

int[] numbers = { 1, 3, 5, 7, 9 };

LinearSearch(numbers, 9);
BinarySearch(numbers, 9);


int FindSmallerIndex(int[] numbers)
{
    int smaller = numbers[0];
    int smallerIndex = 0;

    for (int i = 0; i < numbers.Length; i++) 
    {
        if (numbers[i] < smaller)
        {
            smaller = numbers[i];
            smallerIndex = i;
        }
    }

    return smallerIndex;
}

int[] SelectionSort(int[] numbers)
{
    int[] sorted = new int[numbers.Length];
    int[] numbersCopy = (int[])numbers.Clone();

    for (int i = 0; i < numbers.Length; i++)
    {
        int smallerIdx = FindSmallerIndex(numbersCopy);
        sorted[i] = numbersCopy[smallerIdx];
        numbersCopy = numbersCopy.Except(new int[] { numbersCopy[smallerIdx] }).ToArray();
    }

    return sorted;
}

void Print(int[] numbers)
{
    Console.Write("[ ");
    for (int i = 0; i < numbers.Length; i++)
    {
        Console.Write($"{numbers[i]}, ");
    }

    Console.Write(" ]");
    Console.WriteLine();
}

int[] unsortedNumbers = { 10, 7, 22, 31, 11, 8, 55, 99 };

int[] sortedNumbers = SelectionSort(unsortedNumbers);

Print(sortedNumbers);

void PrintNumberRecursive(int number)
{
    Console.WriteLine(number);

    if (number == 0)
    {
        return;
    }

    PrintNumberRecursive(number - 1);
}

PrintNumberRecursive(10);