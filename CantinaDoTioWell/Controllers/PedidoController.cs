using CantinaDoTioWell.DAO;
using CantinaDoTioWell.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CantinaDoTioWell.Controllers
{
    public class PedidoController : Controller
    {
        // GET: Pedido
        public ActionResult Index()
        {
            List<Produtos> p = new List<Produtos>();
            ProdutoDB prod = new ProdutoDB();
            p = prod.ConsultarProdutos();
            ViewBag.Lista = new SelectList(p, "Id", "Nome");
            return View();
        }
        [HttpPost]
        public ActionResult InserirPedido(Pedido pedido)
        {
            //ProdutoDB prod = new ProdutoDB();
            //Produtos ProdutoContexto = prod.ConsultarProdutos().Find(x => x.Nome.Contains(ProdutoComprado));
            ClienteDB cli = new ClienteDB();
            Cliente ClienteContexto = cli.ConsultarClientes().Find(x => x.Nome.Contains(pedido.cliente.Nome));
            if (ClienteContexto != null) // && ProdutoContexto != null
            {
                PedidoDB ped = new PedidoDB();
                ped.InserirPedido(ClienteContexto.IdCliente ,pedido.Produto.Id, pedido.Quantidade);
                return RedirectToAction("Index");
            }
            return View("Error");
            
        }
        public ActionResult Pagar(int Idpedido)
        {
            PedidoDB pedido = new PedidoDB();
            pedido.PagarPedido(Idpedido);
            return RedirectToAction("Relatorio");
        }
        public ActionResult Relatorio()
        {
            List<Pedido> p = new List<Pedido>();
            PedidoDB ped = new PedidoDB();
            p = ped.ConsultarPedido();
            ViewBag.ListaPedidos = p;
            return View(p);
        }


        public List<Pedido> ConsultarPedido()
        {
            return new PedidoDB().ConsultarPedido();
        }
    }
}
