using CantinaDoTioWell.DAO;
using CantinaDoTioWell.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CantinaDoTioWell.Controllers
{
    public class ProdutoController: Controller
    {
        public ActionResult index()
        {
           
            List<Produtos> p = new List<Produtos>();
            ProdutoDB prod = new ProdutoDB();
            p = prod.ConsultarProdutos();
            ViewBag.Lista = p;
            return View();
        }

        public ActionResult InserirProdutos(string Nome, decimal Preco, int Quantidade)
        {
            ProdutoDB prd = new ProdutoDB();
            prd.InserirProdutos(Nome, Preco, Quantidade);
            return View("Index");

        }
        public ProdutoController() { }

        public List<Produtos> ConsultarProdutos()
        {
            return new ProdutoDB().ConsultarProdutos();
        }
    }
}