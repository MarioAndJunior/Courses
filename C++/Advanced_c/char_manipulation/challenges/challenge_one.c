#include <stdio.h>

void introMessage()
{
    printf("\n");
    printf("***************************************\n");
    printf("***************************************\n");
    printf("****Contador de linhas e caracteres****\n");
    printf("***************************************\n");
    printf("***************************************\n");
}

int fgetcFromFile(FILE* fp)
{
    return fgetc(fp);
}


int fgetcFromInput()
{
    return fgetc(stdin);
}

void countWordsAndChars(int* words, int* characters, const char* fileName)
{
    if(words && characters)
    {
        FILE* fp = NULL;
        int charsCount = 0;
        int wordsCount = 0;

        if(fileName)
        {
            fp = fopen(fileName, "r");
        }
        else
        {
            printf("Voce nao esta usando um arquivo, digite as palavras, por favor (use ctrl + d para terminar): ");
        }

        char lastChar = '\0';

        while(1)
        {
            char c = '\0';

            if(fp)
            {
                c = fgetcFromFile(fp);
            }
            else
            {
                c = fgetcFromInput();
            }

            if(c == '\n' || c == ' ')
            {
                wordsCount++;
            }
            else if(c == EOF)
            {
                if(lastChar != '\0')
                {
                    wordsCount++;
                }

                *characters = charsCount;
                *words = wordsCount;
                break;
            }
            else
            {
                lastChar = c;
                charsCount++;
            }
        }
    }
}

int main(int argc, char const *argv[])
{
    const char* fileName = NULL;
    int charsCount = 0;
    int wordsCount = 0;

    if(argc == 2)
    {
        fileName = argv[argc - 1];
    }

    introMessage();

    countWordsAndChars(&wordsCount, &charsCount, fileName);
    printf("\nTotal de palavras[%d] e caracteres[%d]\n", wordsCount, charsCount);

    return 0;
}
