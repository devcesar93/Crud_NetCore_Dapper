using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Exemplo_App_NetCore_Dapper.Models
{
    [Table("Veiculo_Modelo")] //A extensão Dapper.Contrib, pluraliza os nomes das tabelas, então temos que forçar o nome no DataAnnotations
    public class Veiculo_Modelo
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nome { get; set; }

        [Required]
        public int Ano { get; set; }

        [Required]
        [MaxLength(100)]
        public string Tipo { get; set; }

        [Required]
        public double PrecoFipe { get; set; }

        [Required]
        public int MarcaId { get; set; }

        [Write(false)] // atributo do Dapper para excluir essa propriedade nas querys do banco (inserts, updates etc..)
        public virtual Veiculo_Marca Dados_Marca { get; set; }
    }
}
