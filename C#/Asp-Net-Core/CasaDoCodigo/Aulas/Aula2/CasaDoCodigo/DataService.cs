using CasaDoCodigo.Models;
using CasaDoCodigo.Repositories;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace CasaDoCodigo
{
    public class DataService : IDataService
    {
        private readonly ApplicationContext contexto;
        private readonly IProdutoRepository produtoRepository;

        public DataService(ApplicationContext contexto, IProdutoRepository produtoRepository)
        {
            this.contexto = contexto;
            this.produtoRepository = produtoRepository;
        }

        public void InicializaDb()
        {
            contexto.Database.EnsureCreated();
            List<Livro> livros = GetLivros();
            this.produtoRepository.SaveProdutos(livros);
        }

        private static List<Livro> GetLivros()
        {
            string json = File.ReadAllText("livros.json");
            List<Livro> livros = JsonConvert.DeserializeObject<List<Livro>>(json);
            return livros;
        }
    }
}
