using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Loja.Testes.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        private static void CrudADOVsEF()
        {
            GravarUsandoAdoNet();
            GravarUsandoEntity();
            RecuperarProdutos();
            ExcluirProdutos();
            AtualizarProduto();
        }

        private static void EntendendoChangeTracker()
        {
            using (var contexto = new LojaContext())
            {
                var serviceProvider = contexto.GetInfrastructure<IServiceProvider>();
                var loggerFactory = serviceProvider.GetService<ILoggerFactory>();
                loggerFactory.AddProvider(SqlLoggerProvider.Create());

                var produtos = contexto.Produtos.ToList();

                ExibeEntries(contexto.ChangeTracker.Entries());

                //var p1 = produtos.Last();
                //p1.Nome = "Goldeneye";

                var novoProduto = new Produto()
                {
                    Nome = "Sabão em Pó",
                    Categoria = "Limpeza",
                    Preco = 5.99,
                };
                contexto.Produtos.Add(novoProduto);

                ExibeEntries(contexto.ChangeTracker.Entries());

                contexto.Produtos.Remove(novoProduto);

                //var p1 = contexto.Produtos.First();
                //contexto.Produtos.Remove(p1);

                ExibeEntries(contexto.ChangeTracker.Entries());

                //contexto.SaveChanges();

                EntityEntry<Produto> entityEntry = contexto.Entry(novoProduto);
                Console.WriteLine($"\n\n{entityEntry} - {entityEntry.State}");

                ExibeEntries(contexto.ChangeTracker.Entries());
            }
        }

        private static void ExibeEntries(IEnumerable<EntityEntry> entries)
        {
            Console.WriteLine("==================");
            foreach (var e in entries)
            {
                Console.WriteLine($"{e.Entity} - {e.State}");
            }
        }

        private static void AtualizarProduto()
        {
            ExcluirProdutos();
            // incluir
            GravarUsandoEntity();
            RecuperarProdutos();

            // atualizar
            using (var repo = new ProdutoDAOEntity())
            {
                Produto produto = repo.Produtos().First();

                produto.Nome = "Cassino Royale editado";
                repo.Atualizar(produto);
            }
            RecuperarProdutos();
        }

        private static void ExcluirProdutos()
        {
            using (var repo = new ProdutoDAOEntity())
            {
                IList<Produto> produtos = repo.Produtos();

                foreach (var item in produtos)
                {
                    repo.Remover(item);
                }

                RecuperarProdutos();
            }
        }

        private static void RecuperarProdutos()
        {
            using (var repo = new ProdutoDAOEntity())
            {
                IList<Produto> produtos = repo.Produtos(); // Mesmo que select * from
                Console.WriteLine($"Foram encontrados {produtos.Count} produtos");
                foreach (var item in produtos)
                {
                    Console.WriteLine(item.Nome);
                }
            }
        }

        private static void GravarUsandoEntity()
        {
            Produto p = new Produto();
            p.Nome = "Cassino Royale";
            p.Categoria = "Livros";
            p.Preco = 19.89;

            using (var contexto = new ProdutoDAOEntity())
            {
                contexto.Adicionar(p);
            }
        }

        private static void GravarUsandoAdoNet()
        {
            Produto p = new Produto();
            p.Nome = "Harry Potter e a Ordem da Fênix";
            p.Categoria = "Livros";
            p.Preco = 19.89;

            using (var repo = new ProdutoDAO())
            {
                repo.Adicionar(p);
            }
        }
    }
}
