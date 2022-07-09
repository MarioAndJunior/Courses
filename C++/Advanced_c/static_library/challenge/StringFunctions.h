#ifndef __STRINGFUNCTIONS_H__
#define __STRINGFUNCTIONS_H__

#include <stdio.h>
#include <string.h>
#include <stdlib.h>

int count(const char* string, char character);
int alphabetsOnly(const char* string, char* alphabetsString);
int length(const char* string);
int concat(const char* first, const char* second, char* resultString);
int copy(const char* string, char* copyString);
int contains(const char* string, const char* subString);

#endif