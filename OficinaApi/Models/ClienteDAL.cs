using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace OficinaApi.Models
{
    public class ClienteDAL
    {

        protected static string GetStringConexao()
        {
            return ConfigurationManager.ConnectionStrings["ConexaoHoracio"].ConnectionString;
        }

        public static int InsertCliente(Cliente Cliente)
        {
            int reg = 0;
            using (SqlConnection con = new SqlConnection(GetStringConexao()))
            {
                string sql = "INSERT INTO TB_CLIENTES(NOME, TELEFONE, EMAIL) VALUES (@NOME, @TELEFONE, @EMAIL)";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@NOME", Cliente.Nome);
                    cmd.Parameters.AddWithValue("@TELEFONE", Cliente.Telefone);
                    cmd.Parameters.AddWithValue("@EMAIL", Cliente.Email);

                    con.Open();
                    reg = cmd.ExecuteNonQuery();
                    con.Close();
                }
                return reg;
            }
        }

        public static int UpdateCliente(Cliente Cliente)
        {
            int reg = 0;
            using (SqlConnection con = new SqlConnection(GetStringConexao()))
            {
                string sql = "UPDATE TB_CLIENTES SET NOME = @NOME, TELEFONE = @TELEFONE, EMAIL = @EMAIL WHERE ID = @ID ";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@ID", Cliente.Id);
                    cmd.Parameters.AddWithValue("@NOME", Cliente.Nome);
                    cmd.Parameters.AddWithValue("@TELEFONE", Cliente.Telefone);
                    cmd.Parameters.AddWithValue("@EMAIL", Cliente.Email);

                    con.Open();
                    reg = cmd.ExecuteNonQuery();
                    con.Close();
                }
                return reg;
            }
        }
        public static int DeleteCliente(int id)
        {
            int reg = 0;
            using (SqlConnection con = new SqlConnection(GetStringConexao()))
            {
                string sql = "DELETE FROM TB_CLIENTES WHERE ID = @ID";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@ID", id);

                    con.Open();
                    reg = cmd.ExecuteNonQuery();
                    con.Close();
                }
                return reg;
            }
        }

        public static List<Cliente> GetClientes()
        {
            List<Cliente> _Clientes = new List<Cliente>();
            using (SqlConnection con = new SqlConnection(GetStringConexao()))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT ID, NOME, TELEFONE, EMAIL FROM TB_CLIENTES", con))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr != null)
                        {
                            while (dr.Read())
                            {
                                var Cliente = new Cliente();
                                Cliente.Id = Convert.ToInt32(dr["ID"]);
                                Cliente.Nome = dr["NOME"].ToString();
                                Cliente.Telefone = dr["TELEFONE"].ToString();
                                Cliente.Email = dr["EMAIL"].ToString();

                                _Clientes.Add(Cliente);
                            }
                        }
                        return _Clientes;
                    }
                }
            }
        }

        public static Cliente GetCliente(int? id)
        {
            Cliente Cliente = null;
            using (SqlConnection con = new SqlConnection(GetStringConexao()))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT ID, NOME, TELEFONE, EMAIL FROM TB_CLIENTES WHERE ID = @ID", con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr != null)
                        {
                            while (dr.Read())
                            {
                                Cliente = new Cliente();
                                Cliente.Id = Convert.ToInt32(dr["ID"]);
                                Cliente.Nome = dr["NOME"].ToString();
                                Cliente.Telefone = dr["TELEFONE"].ToString();
                                Cliente.Email = dr["EMAIL"].ToString();
                            }
                        }
                        return Cliente;
                    }
                }
            }
        }
    }

}