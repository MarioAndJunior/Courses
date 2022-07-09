#include <stdio.h>
#include <stdarg.h>

int dynamicSum(int count, ...);

int main(int argc, char const *argv[])
{
    int sum = 0;
    int call = 0;
    
    ++call;
    sum = dynamicSum(2, 20, 30);
    printf("Soma do %d chamado = %d\n", call, sum);

    ++call;
    sum = dynamicSum(4, 20, 30, 40, 50);
    printf("Soma do %d chamado = %d\n", call, sum);
    
    ++call;
    sum = dynamicSum(5, 20, 30, 40, 50, 60);
    printf("Soma do %d chamado = %d\n", call, sum);
    
    ++call;
    sum = dynamicSum(6, 20, 30, 40, 50, 60, 70);
    printf("Soma do %d chamado = %d\n", call, sum);
    
    return 0;
}


int dynamicSum(int count, ...)
{
    int sum = 0;

    va_list varList;
    va_start(varList, count);

    for(int i = 0; i < count; i++)
    {
        sum += va_arg(varList, int);
    }

    va_end(varList);

    return sum;
}
