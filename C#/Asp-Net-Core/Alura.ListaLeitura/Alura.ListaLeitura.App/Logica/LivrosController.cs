using Alura.ListaLeitura.App.HTML;
using Alura.ListaLeitura.App.Negocio;
using Alura.ListaLeitura.App.Repositorio;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Alura.ListaLeitura.App.Logica
{
    public class LivrosController : Controller
    {
        public IEnumerable<Livro> Livros { get; set; }

        public string Detalhes(int id)
        {
            LivroRepositorioCSV repo = new LivroRepositorioCSV();
            var livro = repo.Todos.First(x => x.Id == id);

            return livro.Detalhes();
        }

        public IActionResult ParaLer()
        {
            LivroRepositorioCSV repo = new LivroRepositorioCSV();
            this.ViewBag.Livros = repo.ParaLer.Livros;

            return View("lista");
        }

        public IActionResult Lendo()
        {
            LivroRepositorioCSV repo = new LivroRepositorioCSV();
            ViewBag.Livros = repo.Lendo.Livros;

            return View("lista");
        }

        public IActionResult Lidos()
        {
            LivroRepositorioCSV repo = new LivroRepositorioCSV();
            ViewBag.Livros = repo.Lidos.Livros;
            
            return View("lista");
        }

        private static string CarregaLista(IEnumerable<Livro> livros)
        {
            LivroRepositorioCSV repo = new LivroRepositorioCSV();

            var conteudoDoArquivo = HtmlUtils.CarregaArquivoHTML("ParaLer");
            foreach (var item in repo.ParaLer.Livros)
            {
                conteudoDoArquivo = conteudoDoArquivo.Replace("#NOVO-ITEM#", $"<li>{item.Titulo} - {item.Autor}</li>#NOVO-ITEM#");
            }

            conteudoDoArquivo = conteudoDoArquivo.Replace("#NOVO-ITEM#", string.Empty);

            return conteudoDoArquivo;
        }

        //public static Task Teste(HttpContext context)
        public string Teste()
        {
            //return context.Response.WriteAsync("Nova funcionalidade ok);
            return "Nova funcionalidade ok";
        }
    }
}
