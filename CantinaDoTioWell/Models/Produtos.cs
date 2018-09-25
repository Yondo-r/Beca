using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CantinaDoTioWell.Models
{
    public class Produtos
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public int Quantidade { get; set; }
        //public IEnumerable<System.Web.Mvc.SelectListItem> Items { get; set; }
    }
}