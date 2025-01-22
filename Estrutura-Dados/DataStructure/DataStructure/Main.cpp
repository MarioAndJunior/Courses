#include "Array.h"

Array<int>* generateNewArray();
void findMissingElements();
void findAndCountDuplicates();
void arrayMainMenu();

int main(int argc, const char* argv[])
{
    //arrayMainMenu();
    findMissingElements();

    findAndCountDuplicates();
    return 0;
}

void findAndCountDuplicates()
{
    Array<int> arr(10);
    arr.Append(3);
    arr.Append(6);
    arr.Append(8);
    arr.Append(8);
    arr.Append(10);
    arr.Append(12);
    arr.Append(15);
    arr.Append(15);
    arr.Append(15);
    arr.Append(20);

    arr.FindDuplicateElementsSorted()->Display();
    arr.FindDuplicateElementsSortedWithSimpleHashTableTechnique()->Display();
}

void findMissingElements()
{
    Array<int> arr(11);
    arr.Append(1);
    arr.Append(2);
    arr.Append(4);
    arr.Append(5);
    arr.Append(6);
    arr.Append(7);
    arr.Append(9);
    arr.Append(12);
    arr.Append(13);
    arr.Append(14);
    arr.Append(17);

    arr.FindMissingElementsSortedSequence()->Display();
    arr.FindMissingElementsUnsortedSequence()->Display();
}

Array<int>* generateNewArray()
{
    int size;
    std::cout << "Enter the size of array" << std::endl;
    std::cin >> size;
    Array<int>* arr = nullptr;
    arr = new Array<int>(size);

    return arr;
}
Array<int>* generateSortedArrayFrom(int startIndex, int size)
{
    auto arr = new Array<int>(size);

    for (int i = startIndex; i < startIndex + size; i++)
    {
        arr->Append(i);
    }

    return arr;
}


void arrayMainMenu()
{
    int choice;
    
    int index;
    int element;
    Array<int>* arr = generateNewArray();

    do
    {
        std::cout << "Menu" << std::endl;
        std::cout << "1. Insert" << std::endl;
        std::cout << "2. Delete" << std::endl;
        std::cout << "3. Search" << std::endl;
        std::cout << "4. Sum" << std::endl;
        std::cout << "5. Display" << std::endl;
        std::cout << "6. Append" << std::endl;
        std::cout << "7. Reverse" << std::endl;
        std::cout << "8. MergeSorted" << std::endl;
        std::cout << "9. DifferenceSorted" << std::endl;
        std::cout << "10. UnionSorted" << std::endl;
        std::cout << "11. IntersectionSorted" << std::endl;
        std::cout << "99. Exit" << std::endl;

        std::cout << "Enter your choice" << std::endl;
        std::cin >> choice;

        switch (choice)
        {
            case 1:
            {
                std::cout << "Enter an element and index" << std::endl;
                std::cin >> element >> index;
                arr->Insert(element, index);
                break;
            }
            case 2:
            {
                std::cout << "Enter an index" << std::endl;
                std::cin >> index;
                arr->Delete(index);
                break;
            }
            case 3:
            {
                std::cout << "Enter an element" << std::endl;
                std::cin >> element;
                int result = arr->BinarySearch(element);
                if (result >= 0)
                {
                    std::cout << "Found at " << result << std::endl;
                }
                else
                {
                    std::cout << "Not found" << std::endl;
                }
                break;
            }
            case 4:
            {
                int result = arr->Sum();
                std::cout << "Result of sum is " << result << std::endl;
                break;
            }
            case 5:
            {
                arr->Display();
                break;
            }
            case 6:
            {
                std::cout << "Enter an element" << std::endl;
                std::cin >> element;
                arr->Append(element);
                break;
            }
            case 7:
            {
                arr->ReverseWithSwap();
                break;
            }
            case 8:
            {
                auto arr2 = generateSortedArrayFrom(0, 10);
                auto arr3 = generateSortedArrayFrom(11, 10);
                std::cout << "Merged " << std::endl;
                arr2->MergeSorted(*arr3)->Display();
                delete arr2;
                delete arr3;
                break;
            }
            case 9:
            {
                auto arr2 = generateSortedArrayFrom(0, 10);
                auto arr3 = generateSortedArrayFrom(11, 10);
                std::cout << "Difference " << std::endl;
                arr2->DifferenceSorted(*arr3)->Display();
                delete arr2;
                delete arr3;
                break;
            }
            case 10:
            {
                auto arr2 = generateSortedArrayFrom(0, 10);
                auto arr3 = generateSortedArrayFrom(11, 10);
                std::cout << "Union " << std::endl;
                arr2->UnionSorted(*arr3)->Display();
                delete arr2;
                delete arr3;
                break;
            }
            case 11:
            {
                auto arr2 = generateSortedArrayFrom(0, 10);
                auto arr3 = generateSortedArrayFrom(11, 10);
                std::cout << "Intersection " << std::endl;
                arr2->IntersectionSorted(*arr3)->Display();
                delete arr2;
                delete arr3;
                break;
            }
            case 99:
                break;
        }
    } while (choice != 99);

    delete arr;
}