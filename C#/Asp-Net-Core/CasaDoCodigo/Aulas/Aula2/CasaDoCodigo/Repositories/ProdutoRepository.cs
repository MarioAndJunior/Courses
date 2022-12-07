using CasaDoCodigo.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CasaDoCodigo.Repositories
{
    public class ProdutoRepository : BaseRepository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(ApplicationContext contexto) : base(contexto)
        {
        }

        public IList<Produto> GetProdutos()
        {
            return this.dbSet.ToList();
        }

        public void SaveProdutos(List<Livro> livros)
        {
            foreach (var livro in livros)
            {
                if (!this.dbSet.Where(p => p.Codigo == livro.Codigo).Any())
                {
                    this.dbSet.Add(new Produto(livro.Codigo, livro.Nome, livro.Preco));
                }
            }

            this.contexto.SaveChanges();
        }
    }
}
