using Atividade_Produto.Models.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Atividade_Produto.Models
{
    public class Pedido : BaseEntity
    {
        [Column("Descricao")]
        public string Descricao { get; set; }

        [Column("Data")]
        public DateTime data { get; set; }

        public virtual Cliente Cliente { get; set; }
    }
}
