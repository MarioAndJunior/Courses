#include <stdio.h>
#include <stdlib.h>
#include <ctype.h>

void getFileName (char* fileName)
{
    if(fileName)
    {
        printf("\nVoce nao me passou o nome do arquivo, por favor digite o mesmo: ");
        scanf("%s", fileName);
    }
}

FILE* createTempFile()
{
    FILE* fp = fopen("temp.txt", "w");
    if(fp)
    {
        return fp;
    }

    return NULL;
}

int main(int argc, char const *argv[])
{
    const char* fileName = NULL;
    char fileNameAux[128] = {0};

    if(argc == 2)
    {
        fileName = argv[argc - 1];
    }

    if(fileName == NULL)
    {
        getFileName(fileNameAux);
        fileName = fileNameAux;
    }

    FILE* fp = fopen(fileName, "r");

    if(!fp)
    {
        printf("\nErro ao abrir o arquivo, saindo...");
        exit(1);
    }

    FILE* tempFile = createTempFile();
    if(!tempFile)
    {
        printf("\nErro ao criar o temp.");
        exit(1);
    }

    while(1)
    {
        char c = '\0';
        c = fgetc(fp);

        if(c == EOF)
        {
            break;
        }

        if(islower(c))
        {
            fputc(toupper(c), tempFile);
        }
        else
        {
            fputc(tolower(c), tempFile);
        }
    }

    fclose(tempFile);
    fclose(fp);

    system("cp -f temp.txt teste.txt");
    //system("rm temp.txt");
    remove("temp.txt");
    return 0;
}
