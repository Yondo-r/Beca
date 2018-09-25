using CantinaDoTioWell.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CantinaDoTioWell.DAO
{
    internal class ClienteDB
    {
        string conecta = ConfigurationManager.ConnectionStrings["ConectaBanco"].ConnectionString;

        internal Cliente InserirClientes(string Nome, string Telefone, string Email)
        {
            SqlConnection conn = new SqlConnection(conecta);
            string sqlQuery = "INSERT INTO CLIENTE (NomeCliente, Email, Telefone)VALUES(@nomeCompleto, @email, @telefone)";
            SqlCommand comando = new SqlCommand(sqlQuery, conn);
            comando.Parameters.Add(new SqlParameter("@nomeCompleto", Nome));
            comando.Parameters.Add(new SqlParameter("@telefone", Telefone));
            comando.Parameters.Add(new SqlParameter("@email", Email));
            try
            {
                conn.Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception("Houve um problema na gravação dos dados" + e);
            }
            finally
            {
                conn.Close();
            }
            return null;
        }

        internal List<Cliente> ConsultarClientes()
        {
            List<Cliente> lstCliente = new List<Cliente>();
            SqlConnection conn = new SqlConnection(conecta);

            string sql = "Select * from CLIENTE";
            SqlCommand cmd = new SqlCommand(sql, conn);

            conn.Open();
            SqlDataReader leitor = cmd.ExecuteReader();

            while (leitor.Read())
            {
                Cliente cliente = new Cliente();
                cliente.IdCliente = Convert.ToInt32(leitor["IdCliente"].ToString());
                cliente.Nome = leitor["NomeCliente"].ToString();
                cliente.Telefone = leitor["Telefone"].ToString();
                cliente.Email = leitor["Email"].ToString();

                lstCliente.Add(cliente);
            }
            return lstCliente;
        }
    }
}