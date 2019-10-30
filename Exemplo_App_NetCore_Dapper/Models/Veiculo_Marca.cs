using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Exemplo_App_NetCore_Dapper.Models
{
    public class Veiculo_Marca
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(100)]
        [Required]
        public string Marca { get; set; }

        public virtual List<Veiculo_Modelo> Modelos { get; set; }
    }
}
