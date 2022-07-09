#include "StringFunctions.h"

int arrayLength(const char* string);


int count(const char* string, char character)
{
    int charCount = 0;
    int length = arrayLength(string);
    if(length == 0)
    {
        return charCount;
    }

    for(int i = 0; i < length; i++)
    {
        if(character == string[i])
        {
            charCount++;
        }
    }

    return charCount;
}

int alphabetsOnly(const char* string, char* alphabetsString)
{
    int charCount = 0;
    int length = arrayLength(string);

    if(length == 0 || !alphabetsString)
    {
        alphabetsString = NULL;
        return charCount;
    }

    int newStrIndex = 0;
    for(int i = 0; i < length; i++)
    {
        char character = string[i];

        if(character >= 'a' && character <= 'z' ||
            character >= 'A' && character <= 'Z')
        {
            alphabetsString[newStrIndex] = character;
            newStrIndex++;
            charCount++;   
        }
    }

    return charCount;
}

int length(const char* string)
{
    return arrayLength(string);
}

int concat(const char* first, const char* second, char* resultString)
{
    int charCount = 0;

    if(!first || !second || !resultString)
    {
        return charCount;
    }

    strcat(resultString, first);
    strcat(resultString, second);

    return(strlen(resultString));
}

int copy(const char* string, char* copyString)
{
    int charCount = 0;
    if(!string || !copyString)
    {
        copyString = NULL;
        return charCount;
    }

    for(int i = 0; i < arrayLength(string); i++)
    {
        copyString[i] = string[i];
    }
}

int contains(const char* string, const char* subString)
{
    int stringIndex = -1;
    if(!string || !subString)
    {
        return stringIndex;
    }

    int lengthToFind = arrayLength(string) - arrayLength(subString) - 1; 

    for(int i = 0; i < lengthToFind; i++)
    {
        if(strncmp(&string[i], subString, arrayLength(subString)) == 0)
        {
            stringIndex = i;
        }
    }

    return stringIndex;
}

int arrayLength(const char* string)
{
    int length = 0;
    
    if(!string)
    {
        return length;
    }

    while(string[length] != '\0')
    {
        length++;
    }

    return length;
}