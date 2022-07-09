using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Portal.Infraestrutura
{
    public class ManipuladorRequisicaoArquivo
    {
        public void Manipular(HttpListenerResponse resposta, string path)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var nomeRecurso = Utilidades.ConverterPathParaNomeAssembly(path);
            var recursoStream = assembly.GetManifestResourceStream(nomeRecurso);

            if (recursoStream == null)
            {
                resposta.StatusCode = 404;
                resposta.OutputStream.Close();
            }
            else
            {
                using (recursoStream)
                {
                    var bytesRecurso = new byte[recursoStream.Length];
                    resposta.ContentLength64 = recursoStream.Length;

                    recursoStream.Read(bytesRecurso, 0, bytesRecurso.Length);
                    resposta.ContentType = Utilidades.ObterTipoDeConteudo(path);

                    resposta.OutputStream.Write(bytesRecurso, 0, bytesRecurso.Length);
                    resposta.OutputStream.Close();
                }
            }
        }
    }
}
