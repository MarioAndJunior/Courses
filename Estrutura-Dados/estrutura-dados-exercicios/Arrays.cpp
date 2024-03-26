#include <stdio.h>
#include <stdlib.h>


void printaInicioExercicio(int numero)
{
	printf("\n\n\n");
	printf("Exercicio %d\n", numero);
}

void exercicioUm()
{
	const int INTEIROS_TAMANHO = 10;
	int inteiros[INTEIROS_TAMANHO] = { 10, 20, 30, 40, 50, 60, 70, 80, 90, 100 };

	printaInicioExercicio(1);
	
	for (int i = 0; i < INTEIROS_TAMANHO; i++)
	{
		printf("Inteiros em [%d] = [%d]\n", i, inteiros[i]);
	}
}

void exercicioDois()
{
	const int MATRIZ_TAMANHO = 4;
	char matrizChars[MATRIZ_TAMANHO][MATRIZ_TAMANHO]{};

	matrizChars[0][0] = 'a';
	matrizChars[0][1] = 'b';
	matrizChars[0][2] = 'c';
	matrizChars[0][3] = 'd';

	matrizChars[1][0] = 'e';
	matrizChars[1][1] = 'f';
	matrizChars[1][2] = 'g';
	matrizChars[1][3] = 'h';

	matrizChars[2][0] = 'i';
	matrizChars[2][1] = 'j';
	matrizChars[2][2] = 'k';
	matrizChars[2][3] = 'l';

	matrizChars[3][0] = 'm';
	matrizChars[3][1] = 'n';
	matrizChars[3][2] = 'o';
	matrizChars[3][3] = 'p';

	printaInicioExercicio(2);

	for (int i = 0; i < MATRIZ_TAMANHO; i++)
	{
		for (int j = 0; j < MATRIZ_TAMANHO; j++)
		{
			printf("Char em [%d][%d] = [%c]\n", i, j, matrizChars[i][j]);
		}

		printf("\n");
	}
}

//int main(int argc, const char** args)
//{
//	printf("Iniciando os exercicios\n");
//	exercicioUm();
//	exercicioDois();
//	return 0;
//}