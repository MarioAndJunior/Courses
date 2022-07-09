#include <stdio.h>
#include <stdarg.h>

// void func(int, ...);

// int main()   {
//     func(2, 3, 5, 7, 10, 13);
//     return 0;
// }

// void func(int n, ...)
// {
//     int number, i = 0;
//     va_list start;
//     va_start(start, n);
//     while (i != 4)    {
//         number = va_arg(start, int);
//         i++;
//     }
//     printf("Number: %d %d\n", number, i);
// }


void static inline func1(float b) {
    printf ("%lf\n",b*2);
}
    
int main()  {
        inline func1(2.2);
        return 0;
}