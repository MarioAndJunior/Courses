#include <stdio.h>
#include <stdlib.h>
#include <string.h>

#define MAX_LINE_LENGTH     255

int main(int argc, char const *argv[])
{
    if(argc != 3)
    {
        puts("Invalid number of args");
        exit(1);
    }

    const char* filePath = argv[2];
    char charToCheck = argv[1][0];

    printf("\nWelcome to char checker\nWill look for the char[%c] in the filePath[%s]\n", charToCheck, filePath);

    FILE* filePtr = fopen(filePath, "r");

    if(!filePtr)
    {
        puts("Error opening file, leaving...");
        exit(1);
    }

    char line[MAX_LINE_LENGTH] = {0};
    int found = 0;

    while(fgets(line, MAX_LINE_LENGTH, filePtr) != NULL)
    {
        if(strchr(line, charToCheck))
        {
            found++;
            fputs(line, stdout);
        }
    }

    if(found == 0)
    {
        puts("Caractere nao encontrado");
    }

    fclose(filePtr);

    return 0;
}
