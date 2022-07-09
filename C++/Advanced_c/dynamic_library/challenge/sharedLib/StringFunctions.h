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

/*
    Para os SO Shared Object
    primeiro compila
    gcc -c -fPIC *.c -shared -o *.so


    DEPOIS
    compilar um executavel de testes
    gcc -I <caminho> -c *.c -o *.o
    gcc -o <nome_do_exe> <nome_do_exe>.o -L<caminho_para_so> -l <nome_do_so>

    export LD_LIBRARY_PATH=<caminho_para_o_so>:$LD_LIBRARY_PATH para adicionar no path
*/