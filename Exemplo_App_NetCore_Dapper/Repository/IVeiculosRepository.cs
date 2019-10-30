using Exemplo_App_NetCore_Dapper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exemplo_App_NetCore_Dapper.Repository
{
    public interface IVeiculosRepository
    {
        List<Veiculo_Marca> GetMarcas();
        List<Veiculo_Modelo> GetModelos();
        long Add(Veiculo_Modelo modelo);
        Veiculo_Modelo Get(int id);
        int Edit(Veiculo_Modelo modelo);
        int Delete(int id);
    }
}
