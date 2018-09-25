using CantinaDoTioWell.DAO;
using CantinaDoTioWell.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CantinaDoTioWell.Controllers
{
    public class ClienteController: Controller
    {
        public ActionResult index()
        {
            return View();
        }
        public ActionResult InserirCliente(string Nome, string Telefone, string Email)
        {
            ClienteDB cli = new ClienteDB();
            cli.InserirClientes(Nome, Telefone, Email);
            return View("Index");
        }
        public ClienteController() { }

        public List<Cliente> ConsultarCliente()
        {
            return new ClienteDB().ConsultarClientes();
        }
       
    }
}

        