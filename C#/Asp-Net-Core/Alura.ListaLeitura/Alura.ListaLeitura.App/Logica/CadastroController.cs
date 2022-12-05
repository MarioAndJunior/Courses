using Alura.ListaLeitura.App.Negocio;
using Alura.ListaLeitura.App.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace Alura.ListaLeitura.App.Logica
{
    public class CadastroController
    {
        public IActionResult ExibeFormulario()
        {
            //var html = HtmlUtils.CarregaArquivoHTML("formulario");
            var html = new ViewResult
            {
                ViewName = "formulario"
            };
            return html;
        }

        public string Incluir(Livro livro)
        {
            LivroRepositorioCSV repo = new LivroRepositorioCSV();
            repo.Incluir(livro);

            return "Livro adicionado com sucesso!";
        }
    }
}
