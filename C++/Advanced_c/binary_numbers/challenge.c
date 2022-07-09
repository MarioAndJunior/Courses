#include <stdio.h>


int pegaNumero()
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
    Programa para pegar dois inputs e 
    fazer as operacoes binarias ~ & | ^ 
    um com o outro e << >> com um nuero qualquer, 
    mostrar o resultado em binario e decimal
*/
int main(void)
{
    unsigned int primeiro = pegaNumero();
    unsigned int segundo = pegaNumero();
    unsigned int resultado = 0;

    printf("Numero inserido dec[%u] bin [%llu]\nApos operacao ~ dec[%u] bin[%llu]", 
        primeiro, decimalParaBinario(primeiro), ~primeiro, decimalParaBinario(~primeiro));
    
    printf("\nNumero inserido dec[%u] bin [%llu]\nApos operacao ~ dec[%u] bin[%llu]", 
        segundo, decimalParaBinario(segundo), ~segundo, decimalParaBinario(~segundo));

    resultado = primeiro & segundo;
    printf("\n[%u] & [%u] = dec[%u] bin[%llu]", primeiro, segundo, resultado, decimalParaBinario(resultado));
    resultado = primeiro | segundo;
    printf("\n[%u] | [%u] = dec[%u]bin[%llu]", primeiro, segundo, resultado, decimalParaBinario(resultado));

    resultado = primeiro ^ segundo;
    printf("\n[%u] ^ [%u] = dec[%u]bin[%llu]", primeiro, segundo, resultado, decimalParaBinario(resultado));

    printf("\n[%u] << [3] = [%u]", primeiro, primeiro << 3);
    printf("\n[%u] >> [2] = [%u]", segundo, segundo >> 2);

    printf("\n");
    return 0;
}