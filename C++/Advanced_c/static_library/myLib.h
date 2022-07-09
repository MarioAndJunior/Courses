#ifndef __MYLIB_H__
#define __MYLIB_H__

void func(void);

#endif

/*
    primeiro compila
    gcc -c *.c -o *.o
    depois pega os arquivos *.o e "compacta" nos *.a
    ar rcs *.a *.o
    para testar 
    ar -t *.a

    DEPOIS
    compilar um executavel de testes
    gcc -I <caminho> -c *.c -o *.o
    gcc -o <nome_do_exe> <nome_do_exe>.o <path_para_lib/*.a>
*/

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