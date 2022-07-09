using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Portal.Infraestrutura
{
    public static class Utilidades
    {
        public static bool EhArquivo(string path)
        {
            var partesPath = path.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
            var ultimaParte = partesPath.Last();
            
            return ultimaParte.Contains('.');
        }

        public static string ConverterPathParaNomeAssembly(string path)
        {
            var nomeComPontos = path.Replace('/', '.');
            var prefixoAssembly = "ByteBank.Portal";

            var nomeCompleto = $"{prefixoAssembly}{nomeComPontos}";

            return nomeCompleto;
        }

        public static string ObterTipoDeConteudo(string path)
        {
            if (path.EndsWith(".css"))
            {
                return "text/css; charset=utf8";
            }

            if (path.EndsWith(".html"))
            {
                return "text/html; charset=utf8";
            }

            if (path.EndsWith(".js"))
            {
                return "application/js; charset=utf8";
            }

            throw new NotImplementedException("Tipo não mapeado!");
        }
    }
}
