using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CantinaDoTioWell.Models
{
    public class Pedido
    {
        public int IdPedido { get; set; }
        public Cliente cliente { get; set; }
        public Produtos Produto { get; set; }
        public int Quantidade { get; set; }
        public DateTime DataCompra { get; set; }
    }
}