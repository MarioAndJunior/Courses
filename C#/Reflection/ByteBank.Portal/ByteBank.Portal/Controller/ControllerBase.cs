using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ByteBank.Portal.Controller
{
    public abstract class ControllerBase
    {
        protected string View([CallerMemberName]string nomeArquivo = null)
        {
            var type = GetType();
            var diretorioNome = type.Name.Replace("Controller", "");

            var nomeCompletoRecurso = $"ByteBank.Portal.View.{diretorioNome}.{nomeArquivo}.html";
            var assembly = Assembly.GetExecutingAssembly();

            var streamRecurso = assembly.GetManifestResourceStream(nomeCompletoRecurso);
            var streamLeitura = new StreamReader(streamRecurso);
            var textoPagina = streamLeitura.ReadToEnd();

            return textoPagina;
        }

        protected string View(object model, [CallerMemberName]string nomeArquivo = null)
        {
            var viewBruta = View(nomeArquivo);
            var regex = new Regex("\\{{(.*?)\\}}");
            var todasAsPropriedadesDoModelo = model.GetType().GetProperties();
            var viewProcessada = regex.Replace(viewBruta, (match) =>
            {
                var nomePropriedade = match.Groups[1].Value;
                var propriedade = todasAsPropriedadesDoModelo.Single(prop => prop.Name == nomePropriedade);

                var valorBruto = propriedade.GetValue(model);
                return valorBruto?.ToString();
            });

            return viewProcessada;
        }
    }
}
