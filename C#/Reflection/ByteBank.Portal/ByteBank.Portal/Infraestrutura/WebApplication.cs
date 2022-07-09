using ByteBank.Portal.Controller;
using ByteBank.Portal.Infraestrutura.IoC;
using ByteBank.Service;
using ByteBank.Service.Cambio;
using ByteBank.Service.Cartao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Portal.Infraestrutura
{
    public class WebApplication
    {
        private readonly string[] prefixos;
        private readonly IContainer container = new ContainerSimples();
        public WebApplication(string[] prefixos)
        {
            if (prefixos == null)
            {
                throw new ArgumentException(nameof(prefixos));
            }

            this.prefixos = prefixos;
            this.Configurar();
        }

        public void Iniciar()
        {
            while (true)
            {
                this.ManipularRequisicao();
            }
        }

        public void Configurar()
        {
            //this.container.Registrar(typeof(ICambioService), typeof(CambioTesteService));
            //this.container.Registrar(typeof(ICartaoService), typeof(CartaoServiceTeste));
            this.container.Registrar<ICambioService, CambioTesteService>();
            this.container.Registrar<ICartaoService, CartaoServiceTeste>();
        }

        private void ManipularRequisicao()
        {
            var httpListener = new HttpListener();

            foreach (var prefixo in this.prefixos)
            {
                httpListener.Prefixes.Add(prefixo);
            }

            httpListener.Start();
            var contexto = httpListener.GetContext();
            var requiscao = contexto.Request;
            var resposta = contexto.Response;

            var path = requiscao.Url.PathAndQuery;

            if (Utilidades.EhArquivo(path))
            {
                var manipulador = new ManipuladorRequisicaoArquivo();
                manipulador.Manipular(resposta, path);
            }
            else
            {
                var manipulador = new ManipuladorRequisicaoController(this.container);
                manipulador.Manipular(resposta, path);
            }

            //if (path == "/Assets/css/styles.css")
            //{
            //    var assembly = Assembly.GetExecutingAssembly();
            //    var nomeRecurso = "ByteBank.Portal.Assets.css.styles.css";
            //    var recursoStream = assembly.GetManifestResourceStream(nomeRecurso);
            //    var bytesRecurso = new byte[recursoStream.Length];

            //    recursoStream.Read(bytesRecurso, 0, bytesRecurso.Length);
            //    resposta.ContentType = "text/css; charset=utf8";

            //    resposta.OutputStream.Write(bytesRecurso, 0, bytesRecurso.Length);
            //    resposta.OutputStream.Close();

            //}
            //else if (path == "/Assets/js/main.js")
            //{
            //    var assembly = Assembly.GetExecutingAssembly();
            //    var nomeRecurso = "ByteBank.Portal.Assets.js.main.js";
            //    var recursoStream = assembly.GetManifestResourceStream(nomeRecurso);
            //    var bytesRecurso = new byte[recursoStream.Length];

            //    recursoStream.Read(bytesRecurso, 0, bytesRecurso.Length);
            //    resposta.ContentType = "application/js; charset=utf8";

            //    resposta.OutputStream.Write(bytesRecurso, 0, bytesRecurso.Length);
            //    resposta.OutputStream.Close();
            //}
            //else
            //{
            //    resposta.ContentType = "text/html; charset=utf8";
            //    resposta.StatusCode = 200;
            //    var respostaConteudo = "Hello, World";
            //    var respostaConteudoBytes = Encoding.UTF8.GetBytes(respostaConteudo);

            //    resposta.OutputStream.Write(respostaConteudoBytes);
            //    resposta.OutputStream.Close();
            //}

            httpListener.Close();
        }
    }
}
