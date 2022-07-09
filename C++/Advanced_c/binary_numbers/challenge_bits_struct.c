#include <stdio.h>

struct onscreen_box_packed
{
    unsigned int opaque:1;
    unsigned int visible_border:1;
    unsigned int box_color:3;
    unsigned int border_color:3;
    unsigned int border_style:2;
}; 

long long decimalParaBinario(unsigned int numeroDecimal)
{
    int sobra = 0;
    int idx = 1;
    long long ret = 0;

    while(numeroDecimal > 0)
    {
        sobra = numeroDecimal % 2;
        ret += idx * sobra;
        numeroDecimal /= 2;
        idx *= 10;
    }

    return ret;
}

/*
    Programa que usa uma estrutura para gerar dados packed para uma configuração qualquer dentro de um int (32 bits)
*/
int main(void)
{

    struct onscreen_box_packed screen_config = {0};

    printf("Tamanho da estrutura = %lu\n", sizeof(screen_config));
    printf("Tamanho do uns int = %lu\n", sizeof(unsigned int));

    screen_config.opaque = 1;
    screen_config.visible_border = 1;
    screen_config.box_color = 7;
    screen_config.border_style = 2;
    screen_config.border_color = 3;

    printf("Box configurada dec[%u]\n", screen_config);
    return 0;
}