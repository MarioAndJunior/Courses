#include <stdio.h>
#include <stdlib.h>
#include <time.h>

const int VETOR_TAMANHO_MAXIMO = 10;
int vetor[VETOR_TAMANHO_MAXIMO]{};
int chuteAtual = 0;

void preencheVetor()
{
	time_t t;
	srand((unsigned)time(&t));

	for (int i = 0; i < VETOR_TAMANHO_MAXIMO; i++)
	{
		vetor[i] = rand() % 100;
	}
}

void inicializa()
{
	printf("******************************************************************************************************\n");
	printf("*****************************************JOGO DA ADIVINHACAO******************************************\n");
	printf("******************************************************************************************************\n");

	preencheVetor();
}

void pedeNumero()
{
	printf("Digite um numero de 0 a 99\n");
	chuteAtual = (char)getchar();
}

bool validaChute()
{
	for (int i = 0; i < VETOR_TAMANHO_MAXIMO; i++)
	{
		if (vetor[i] == chuteAtual)
		{
			return true;
		}
	}

	return false;
}

void imprimeVetor()
{
	printf("Conteudo do vetor: ");
	for (int i = 0; i < VETOR_TAMANHO_MAXIMO; i++)
	{
		printf("%d, ", vetor[i]);
	}

	printf("\n");
}

void mainLoop()
{
	char continuarJogando = 'S';
	do
	{
		pedeNumero();
		if (validaChute())
		{
			printf("Acertou mizerávi.\n");
			imprimeVetor();
			break;
		}
		else
		{
			printf("Deseja continuar jogando? S/N\n");
			continuarJogando = (char)getchar();
		}
	} while (continuarJogando == 'S');
}


int main(int argc, const char** argv)
{
	inicializa();
	mainLoop();
	return 0;
}