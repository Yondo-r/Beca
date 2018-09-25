using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CantinaDoTioWell.Models
{
    public class Cliente
    {
        private int _IdCliente;

        public int IdCliente
        {
            get { return _IdCliente; }
            set { _IdCliente = value; }
        }

        private string _Nome;

        public string Nome 
        {
            get { return _Nome; }
            set { _Nome = value; }
        }

        private string _Telefone;

        public string Telefone
        {
            get { return _Telefone; }
            set { _Telefone = value; }
        }

        private string _Email;

        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }

    }
}