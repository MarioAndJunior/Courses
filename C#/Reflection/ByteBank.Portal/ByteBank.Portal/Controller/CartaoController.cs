using ByteBank.Service;
using ByteBank.Service.Cartao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Portal.Controller
{
    public class CartaoController : ControllerBase
    {
        private ICartaoService cartaoService;
        public CartaoController()
        {
            this.cartaoService = new CartaoServiceTeste();
        }

        public string Debito() =>
            View(new { CartaoPromocao = cartaoService.ObterCartaoDeDebitoDeDestaque() });

        public string Credito() =>
            View(new { CartaoPromocao = cartaoService.ObterCartaoDeCreditoDeDestaque() });
    }
}
