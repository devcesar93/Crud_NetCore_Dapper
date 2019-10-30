using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Exemplo_App_NetCore_Dapper.Models;
using Microsoft.Extensions.Configuration;
using Dapper.Contrib.Extensions;

namespace Exemplo_App_NetCore_Dapper.Repository
{
    public class VeiculosRepository : IVeiculosRepository
    {
        IConfiguration _configuration;

        public VeiculosRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetConnection()
        {
            var connection = _configuration.GetSection("ConnectionStrings").GetSection("ConexaoSQL").Value;
            return connection;
        }


        public long Add(Veiculo_Modelo modelo)
        {
            var connectionString = this.GetConnection();
            long count = 0;
            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    //Exemplo com o Dapper Puro
                    //var query = @"INSERT INTO Veiculo_Modelo(Ano, MarcaId, Nome, PrecoFipe, Tipo) VALUES(@Ano, @MarcaId, @Nome, @PrecoFipe, @Tipo); 
                    //SELECT CAST(SCOPE_IDENTITY() as INT); ";
                    //count = con.Execute(query, modelo);

                    //Exemplo com a Extensão Dapper Contrib
                    count = con.Insert(modelo);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
                return count;
            }
        }

        public int Delete(int id)
        {
            var connectionString = this.GetConnection();
            var count = 0;
            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = "DELETE FROM Veiculo_Modelo WHERE Id =" + id;
                    count = con.Execute(query);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
                return count;
            }
        }

        public int Edit(Veiculo_Modelo modelo)
        {
            var connectionString = this.GetConnection();
            var count = 0;
            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();  //Ano, MarcaId, Nome, PrecoFipe, Tipo
                    var query = @"UPDATE Veiculo_Modelo SET Ano = @Ano, MarcaId = @MarcaId, Nome = @Nome, PrecoFipe = @PrecoFipe, Tipo = @Tipo
                    WHERE Id = " + modelo.Id;
                    count = con.Execute(query, modelo);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
                return count;
            }
        }

        public Veiculo_Modelo Get(int id)
        {
            var connectionString = this.GetConnection();
            Veiculo_Modelo modelo = new Veiculo_Modelo();
            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = "SELECT * FROM Veiculo_Modelo WHERE Id =" + id;
                    modelo = con.Query<Veiculo_Modelo>(query).FirstOrDefault();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
                return modelo;
            }
        }

        public List<Veiculo_Marca> GetMarcas()
        {
            var connectionString = this.GetConnection();
            List<Veiculo_Marca> VeiculoMarcas = new List<Veiculo_Marca>();
            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = "SELECT * FROM Veiculo_Marca";
                    VeiculoMarcas = con.Query<Veiculo_Marca>(query).ToList();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
                return VeiculoMarcas;
            }
        }

        public List<Veiculo_Modelo> GetModelos()
        {
            var connectionString = this.GetConnection();
            List<Veiculo_Modelo> VeiculoModelos = new List<Veiculo_Modelo>();
            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();

                    string sql = @"SELECT * FROM Veiculo_Modelo " +
                                "INNER JOIN Veiculo_Marca ON Veiculo_Modelo.MarcaId = Veiculo_Marca.Id";

                    VeiculoModelos = con.Query<Veiculo_Modelo, Veiculo_Marca, Veiculo_Modelo>(sql,
                        (modelo, marca) =>
                        {
                            modelo.Dados_Marca = marca;
                            return modelo;
                        },
                    splitOn: "Id").Distinct().ToList();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
                return VeiculoModelos;
            }
        }
    }
}
