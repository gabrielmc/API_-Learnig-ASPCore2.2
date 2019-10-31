using Atividade_Garagem.Models.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Atividade_Garagem.Models
{
    public class Servico : BaseEntity
    {
        [Column("Id_Cliente")]
        public int ClienteID { get; set; }

        [Column("Entrada")]
        public DateTime Entrada { get; set; }

        [Column("Saida")]
        public DateTime Saida { get; set; }

        [Column("Preco")]
        public decimal Preco { get; set; }

        public virtual Cliente Cliente { get; set; }
    }
}
