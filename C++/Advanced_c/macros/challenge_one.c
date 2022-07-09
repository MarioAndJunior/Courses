#include <stdio.h>
#include <stdlib.h>


int main(int argc, char const *argv[])
{
    puts("***********************************************************");
    printf("*               Compile date %s                  *\n", __DATE__);
    printf("*               Compile time %s                     *\n", __TIME__);
    puts("***********************************************************");
   
    printf("We are in line %d in the function %s\n", __LINE__, __func__);
    printf("The program %s ISO standard\n", __STDC__ == 1 ? "is" : "is not");
    return 0;
}
