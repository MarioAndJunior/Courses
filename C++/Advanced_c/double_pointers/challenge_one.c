#include <stdio.h>
#include <malloc.h>


int main(int argc, char const *argv[])
{
    int myNum = 999;
    int* myNumPtr = NULL;
    int** myNumPtrPtr = NULL;


    myNumPtr = &myNum;
    myNumPtrPtr = &myNumPtr;


    printf("myNum value %d\n", myNum);
    printf("myNum adrress %p\n", &myNum);
    printf("myNumPtr adrress %p\n", &myNumPtr);
    printf("myNumPtr value %p\n", myNumPtr);
    printf("myNumPtrPtr adrress %p\n", &myNumPtrPtr);
    printf("myNumPtrPtr value %p\n", myNumPtrPtr);
    printf("myNumPtr deref %u\n", *myNumPtr);
    printf("myNumPtrPtr deref %u\n", **myNumPtrPtr);
    return 0;
}
