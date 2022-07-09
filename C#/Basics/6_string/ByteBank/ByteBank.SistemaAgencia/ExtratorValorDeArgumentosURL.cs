using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.SistemaAgencia
{
    public class ExtratorValorDeArgumentosURL
    {
        public string URL { get; }
        private readonly string argumentos;
        public ExtratorValorDeArgumentosURL(string  url)
        {
            if (String.IsNullOrEmpty(url))
            {
                throw new ArgumentException("O argumento url não pode ser nulo ou vazio", nameof(url));
            }

            int indiceInterrogacao = url.IndexOf('?');
            this.argumentos = url.Substring(indiceInterrogacao + 1);

            this.URL = url;
        }

        public string GetValor(string nomeParametro)
        {
            string termo = nomeParametro.ToUpper() + '=';
            string argumetosUpper = this.argumentos.ToUpper();
            int indiceTermo = argumetosUpper.IndexOf(termo);

            string resultado = this.argumentos.Substring(indiceTermo  + termo.Length);
            int indiceEComercial = resultado.IndexOf('&');

            if (indiceEComercial < 0)
            {
                return resultado;
            }
            return resultado.Remove(indiceEComercial);
        }
    }
}
