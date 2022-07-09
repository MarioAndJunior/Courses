using ByteBank.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.SistemaAgencia
{
    public class ListaDeContaCorrente
    {
        public int Tamanho 
        {
            get
            {
                return this.proximaPosicao;
            }
        }

        ContaCorrente[] itens;
        int proximaPosicao;
        public ListaDeContaCorrente(int tamahoInicial = 5)
        {
            this.itens = new ContaCorrente[tamahoInicial];
            this.proximaPosicao = 0;
        }

        public void Adicionar(ContaCorrente conta)
        {
            Console.WriteLine($"Adicionando item na lista, posição atual: {this.proximaPosicao}");
            this.VerificarCapacidade(this.proximaPosicao + 1);
            this.itens[proximaPosicao] = conta;
            this.proximaPosicao++;
        }

        public void AdicionarVarios(params ContaCorrente[] contas)
        {
            foreach (var item in contas)
            {
                this.Adicionar(item);
            }
        }

        public void Remover(ContaCorrente conta)
        {
            int indiceItem = -1;

            for (int i = 0; i < this.proximaPosicao; i++)
            {
                ContaCorrente contaAtual = this.itens[i];

                if (conta.Equals(contaAtual))
                {
                    indiceItem = i;
                    break;
                }
            }

            if (indiceItem == -1)
            {
                return;
            }

            for (int i = indiceItem; i < this.proximaPosicao - 1; i++)
            {
                this.itens[i] = this.itens[i + 1];
            }

            proximaPosicao--;
            this.itens[proximaPosicao] = null;
        }
        
        public ContaCorrente GetItemPeloIndice(int indice)
        {
            if (indice < 0 || indice >= this.proximaPosicao)
            {
                throw new ArgumentOutOfRangeException();
            }

            return this.itens[indice];
        }

        public ContaCorrente this[int indice]
        {
            get
            {
                return this.GetItemPeloIndice(indice);
            }
        }

        private void VerificarCapacidade(int tamanhoNecessario)
        {
            if (this.itens.Length >= tamanhoNecessario)
            {
                return;
            }

            int novoTamanho = this.itens.Length * 2;
            if(tamanhoNecessario > novoTamanho)
            {
                novoTamanho = tamanhoNecessario;
            }

            ContaCorrente[] contas = new ContaCorrente[novoTamanho];

            for (int index = 0; index < this.itens.Length; index++)
            {
                Console.WriteLine(".");
                contas[index] = this.itens[index];
            }

            this.itens = contas;
        }
    }
}
