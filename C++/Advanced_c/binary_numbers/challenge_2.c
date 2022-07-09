#include <stdio.h>
#include <math.h>

unsigned int pegaNumero()
{
    unsigned int ret = 0;
    
    printf("Insira um numero: ");
    scanf("%u", & ret);

    return ret;
}

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
    Programa em que o usuario deve inserir um numero e o indice do bit a ser checado
    Entao checar se o bit está ligado ou nao e entao liga-lo
*/ 
int main (void)
{
    unsigned int numero = pegaNumero();
    unsigned int indice = 0;
    unsigned int auxNum = 0;

    printf("Numero  inserido dec[%u] bin[%lld]\n", numero, decimalParaBinario(numero));
    printf("Entre com o indice que deseja checar e setar 0 a 31\n");
    indice = pegaNumero();

    auxNum = (1 << indice);

    //printf("Mask dec[%u] bin[%lld]\n", mask, decimalParaBinario(mask));

    if((numero >> indice) & 1)
    {
        printf("O bit do indice esta ligado\n");
    }
    else
    {
        printf("O bit do indice esta desligado\n");
    }

    printf("Vamos ligar o bit\n");
    numero |= auxNum;
    printf("Numero apos a alteracao dec[%u] bin[%lld]", numero, decimalParaBinario(numero));
    printf("\n");

    return 0;
}