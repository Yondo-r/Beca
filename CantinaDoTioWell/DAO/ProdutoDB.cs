using CantinaDoTioWell.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CantinaDoTioWell.DAO
{
    internal class ProdutoDB
    {
        string conecta = ConfigurationManager.ConnectionStrings["ConectaBanco"].ConnectionString;

        internal Produtos InserirProdutos(string Nome, decimal Preco, int Quantidade)
        {
            SqlConnection conn = new SqlConnection(conecta);
            string sqlQuery = "INSERT INTO PRODUTO (NomeProduto, Preco, Quantidade)VALUES(@NomeProduto, @Preco, @Quantidade)";
            SqlCommand comando = new SqlCommand(sqlQuery, conn);
            comando.Parameters.Add(new SqlParameter("@NomeProduto", Nome));
            comando.Parameters.Add(new SqlParameter("@Preco", Preco));
            comando.Parameters.Add(new SqlParameter("@Quantidade", Quantidade));
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

        internal List<Produtos> ConsultarProdutos()
        {
            List<Produtos> lstProduto = new List<Produtos>();
            SqlConnection conn = new SqlConnection(conecta);

            string sql = "Select * from Produto";
            SqlCommand cmd = new SqlCommand(sql, conn);

            conn.Open();
            SqlDataReader leitor = cmd.ExecuteReader();

            while (leitor.Read())
            {
                Produtos produto = new Produtos();
                produto.Id = Convert.ToInt32(leitor["Id"].ToString());
                produto.Nome = leitor["NomeProduto"].ToString();
                produto.Preco = Convert.ToDecimal(leitor["Preco"].ToString());
                produto.Quantidade = Convert.ToInt32(leitor["Quantidade"].ToString());

                lstProduto.Add(produto);
            }
            return lstProduto;
        }
    }
}