#include "StringFunctions.h"

int main(void)
{
    const char* string = "O Rato roeu a roupa do rei de Roma 123&*$";
    printf("Count do r = %d\n", count(string, 'r'));

    char auxStr[128] = {0};
    printf("Alphabets count = %d\n", alphabetsOnly(string, auxStr));
    printf("Alphabets only string = %s\n", auxStr);

    printf("length = %d\n", length(string));

    memset(auxStr, 0, sizeof(auxStr));
    printf("Tamanho com concat roeu de novo = %d\n", concat(string, " roeu de novo", auxStr));
    printf("Concatenated String = %s\n", auxStr);
    
    memset(auxStr, 0, sizeof(auxStr));
    printf("Copy = %d\n", copy(string, auxStr));
    printf("Copy string = %s\n", auxStr);

    printf("Roma index = %d\n", contains(string, "Roma"));
    
    return 0;
}


/*
int count(const char* string, char character);
int alphabetsOnly(const char* string, char* alphabetsString);
int length(const char* string);
int concat(const char* first, const char* second, char* resultString);
int copy(const char* string, char* copyString);
int contains(const char* string, const char* subString);
*/