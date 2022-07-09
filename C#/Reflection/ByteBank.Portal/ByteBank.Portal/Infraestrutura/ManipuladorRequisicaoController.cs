using ByteBank.Portal.Infraestrutura.Binding;
using ByteBank.Portal.Infraestrutura.Filtros;
using ByteBank.Portal.Infraestrutura.IoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Portal.Infraestrutura
{
    public class ManipuladorRequisicaoController
    {
        private readonly ActionBinder actionBinder = new ActionBinder();
        private readonly FilterResolver filterResolver = new FilterResolver();
        private readonly ControllerResolver resolver;
        public ManipuladorRequisicaoController(IContainer container)
        {
            this.resolver = new ControllerResolver(container);
        }
        public void Manipular(HttpListenerResponse resposta, string path)
        {
            var partes = path.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
            var controllerNome = partes[0];
            var actionNome = partes[1];
            var controllerNomeCompleto = $"ByteBank.Portal.Controller.{controllerNome}Controller";

            //var controllerWrapper = Activator.CreateInstance("ByteBank.Portal", controllerNomeCompleto, Array.Empty<object>());
            //var controller = controllerWrapper.Unwrap();
            var controller = this.resolver.ObterController(controllerNomeCompleto);

            var actionBindInfo = this.actionBinder.ObterActionBindInfo(controller, path);

            var filterResult = this.filterResolver.VerificarFiltros(actionBindInfo);

            if (filterResult.PodeContinuar)
            {
                var resultado = (string)actionBindInfo.Invoke(controller);

                var bytesConteudo = Encoding.UTF8.GetBytes(resultado);
                resposta.StatusCode = 200;
                resposta.ContentType = "text/html; charset=utf8";
                resposta.ContentLength64 = bytesConteudo.Length;

                resposta.OutputStream.Write(bytesConteudo, 0, bytesConteudo.Length);
                resposta.OutputStream.Close();
            }
            else
            {
                resposta.StatusCode = 307;
                resposta.RedirectLocation = "/Erro/Inesperado";
                resposta.OutputStream.Close();
            }
        }
    }
}
