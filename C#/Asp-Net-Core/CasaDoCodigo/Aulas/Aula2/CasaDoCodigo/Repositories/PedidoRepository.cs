using CasaDoCodigo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.Repositories
{
    public interface IPedidoRepository
    {
        Pedido GetPedido();
        void AddItem(string codigo);
    }

    public class PedidoRepository : BaseRepository<Pedido>, IPedidoRepository
    {
        private readonly IHttpContextAccessor contextAccessor;

        public PedidoRepository(ApplicationContext contexto,
            IHttpContextAccessor contextAccessor) : base(contexto)
        {
            this.contextAccessor = contextAccessor;
        }

        public void AddItem(string codigo)
        {
            var produto = contexto.Set<Produto>()
                .Where(p => p.Codigo == codigo)
                .SingleOrDefault();

            if (produto == null)
            {
                throw new ArgumentException("Produto não encontrado");
            }

            var pedido = this.GetPedido();

            var itemPedido = contexto.Set<ItemPedido>()
                .Where(i => i.Produto.Codigo == codigo
                && i.Pedido.Id == pedido.Id)
                .SingleOrDefault();

            if (itemPedido == null)
            {
                itemPedido = new ItemPedido(pedido, produto, 1, produto.Preco);
                contexto.Set<ItemPedido>()
                    .Add(itemPedido);

                contexto.SaveChanges();
            }
        }

        public Pedido GetPedido()
        {
            var pedidoId = this.GetPedidoId();
            var pedido = this.dbSet
                .Include(p => p.Itens)
                .ThenInclude(i => i.Produto)
                .Where(p => p.Id == pedidoId)
                .SingleOrDefault();

            if (pedido == null)
            {
                pedido = new Pedido();
                this.dbSet.Add(pedido);
                this.contexto.SaveChanges();
                this.SetPedidoId(pedido.Id);
            }

            return pedido;
        }

        private int? GetPedidoId()
        {
            return this.contextAccessor.HttpContext.Session.GetInt32("pedidoId");
        }

        private void SetPedidoId(int pedidoId)
        {
            this.contextAccessor.HttpContext.Session.SetInt32("pedidoId", pedidoId);
        }
    }

}
