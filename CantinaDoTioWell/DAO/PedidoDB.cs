using CantinaDoTioWell.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CantinaDoTioWell.DAO
{
    internal class PedidoDB
    {
        string conecta = ConfigurationManager.ConnectionStrings["ConectaBanco"].ConnectionString;

        internal Pedido InserirPedido(int IdCliente, int IdProduto, int Quantidade)
        {
            SqlConnection conn = new SqlConnection(conecta);
            string sqlQuery = "INSERT INTO Pedido (IdCliente, IdProduto, Quantidade, StatusPagamento)VALUES(@IdCliente, @IdComprado, @Quantidade, 0)";
            SqlCommand comando = new SqlCommand(sqlQuery, conn);
            comando.Parameters.Add(new SqlParameter("@IdCliente", IdCliente));
            comando.Parameters.Add(new SqlParameter("@IdComprado", IdProduto));
            comando.Parameters.Add(new SqlParameter("@Quantidade", Quantidade));
            //comando.Parameters.Add(new SqlParameter(0, StatusPagamento));
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

        internal List<Pedido> ConsultarPedido()
        {
            List<Pedido> lstPedido = new List<Pedido>();
            SqlConnection conn = new SqlConnection(conecta);


            string sql = "select distinct Cliente.NomeCliente, Produto.Preco, Produto.NomeProduto, Pedido.Quantidade, dataPedido, Pedido.Id from Cliente, Produto, Pedido where Cliente.IdCliente = Pedido.IdCliente and Produto.Id = Pedido.IdProduto and Pedido.StatusPagamento = 0";
            SqlCommand cmd = new SqlCommand(sql, conn);

            conn.Open();
            SqlDataReader leitor = cmd.ExecuteReader();

            while (leitor.Read())
            {
                Pedido pedido = new Pedido
                {
                    cliente = new Cliente
                    {
                        Nome = leitor["NomeCliente"].ToString()
                    },
                    Produto = new Produtos
                    {
                        Nome = leitor["NomeProduto"].ToString(),
                        Preco = Convert.ToDecimal(leitor["Preco"].ToString())
                    },
                    Quantidade = Convert.ToInt32(leitor["Quantidade"].ToString()),
                    DataCompra = Convert.ToDateTime(leitor["dataPedido"]),
                    IdPedido = Convert.ToInt32(leitor["Id"].ToString())
                };
                lstPedido.Add(pedido);

                //pedido.cliente.Nome = leitor["NomeCliente"].ToString();
                //pedido.Produto.Nome = leitor["NomeProduto"].ToString();
                //pedido.Quantidade = Convert.ToInt32(leitor["Quantidade"].ToString());
                //lstPedido.Add(pedido);
            }
            return lstPedido;
        }
        internal Pedido PagarPedido(int Idpedido)
        {
            SqlConnection conn = new SqlConnection(conecta);
            string sqlQuery = "update Pedido set StatusPagamento = 1 where Id = @Id;";
            SqlCommand comando = new SqlCommand(sqlQuery, conn);
            comando.Parameters.AddWithValue("@Id", Idpedido);
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
    }
}