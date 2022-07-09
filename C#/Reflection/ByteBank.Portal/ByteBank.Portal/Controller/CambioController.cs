
using ByteBank.Portal.Filtros;
using ByteBank.Service;
using ByteBank.Service.Cambio;
using ByteBank.Service.Cartao;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Portal.Controller
{
    public class CambioController : ControllerBase
    {
        private ICambioService cambioService;
        private ICartaoService cartaoService;

        public CambioController()
        {
            this.cambioService = new CambioTesteService();
            this.cartaoService = new CartaoServiceTeste();

        }
        [ApenasHorarioComercialFiltro]
        public string MXN()
        {
            var valorFinal = this.cambioService.Calcular("MXN", "BRL", 1);
            return View(new 
            { 
                Valor = valorFinal
            });

        }

        [ApenasHorarioComercialFiltro]
        public string USD()
        {
            var valorFinal = this.cambioService.Calcular("USD", "BRL", 1);
            return View(new
            {
                Valor = valorFinal
            });
        }
        [ApenasHorarioComercialFiltro]
        public string Calculo(string moedaDestino) =>
            Calculo("BRL", moedaDestino, 1);

        [ApenasHorarioComercialFiltro]
        public string Calculo(string moedaDestino, decimal valor) =>
            Calculo("BRL", moedaDestino, valor);

        [ApenasHorarioComercialFiltro]
        public string Calculo(string moedaOrigem, string moedaDestino, decimal valor)
        {
            var valorFinal = this.cambioService.Calcular(moedaOrigem, moedaDestino, valor);
            var cartaoPromocao = this.cartaoService.ObterCartaoDeCreditoDeDestaque();
            var modelo = new
            {
                MoedaOrigem = moedaOrigem,
                MoedaDestino = moedaDestino,
                ValorOrigem = valor,
                ValorDestino = valorFinal,
                CartaoPromocao = cartaoPromocao
            };

            return View(modelo);
        }


    }
}
