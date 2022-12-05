using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Alura.ListaLeitura.App.Mvc
{
    public class RoteamentoPadrao
    {
        public static Task TratamentoPadrao(HttpContext context)
        {
            // rota padrao: /<Classe>Logica/Metodo
            // {classe}/{metodo}

            var nomeClasse = Convert.ToString(context.GetRouteValue("classe"));
            var nomeMetodo = Convert.ToString(context.GetRouteValue("metodo"));

            var nomeCompleto = $"Alura.ListaLeitura.App.Logica.{nomeClasse}Logica";

            var tipo = Type.GetType(nomeCompleto);
            var metodo = tipo.GetMethods().Where(m => m.Name == nomeMetodo).First();
            var requestDelegate = Delegate.CreateDelegate(typeof(RequestDelegate), metodo) as RequestDelegate;

            return requestDelegate.Invoke(context);
        }
    }
}
