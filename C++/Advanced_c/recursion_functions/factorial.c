#include <stdio.h>

int factorial(int number)
{
    if(number == 0)
    {
        return 1;
    }

    return number * factorial(number - 1);
}

int main(int argc, char const *argv[])
{
    printf("Entre com o numero\n");
    int num = 0;
    scanf("%d", &num);

    printf("O fatorial de %d eh %d\n", num, factorial(num));
    return 0;
}
