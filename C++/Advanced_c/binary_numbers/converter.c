#include <stdio.h>

int main(void)
{
    // unsigned long long num = 1;
    // for(int i = 0; i < 64; i++)
    // {
    //     printf("Idx: %d - Numero: %llu\n", i, num);

    //     num <<= 1;
    // }


    int num = 100;
    while (num > 0)
    {
        num >>= 1;
        printf("Numero: %u\n", num);
    }
    
    return 0;
}