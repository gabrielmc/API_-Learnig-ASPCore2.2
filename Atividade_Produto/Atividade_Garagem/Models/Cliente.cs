using Atividade_Produto.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Atividade_Produto.Models
{
    public class Cliente : BaseEntity
    {
        [Column("Nome")]
        public string Nome { get; set; }

        [Column("CPF")]
        public string CPF { get; set; }

        [Column("RG")]
        public string RG { get; set; }

        [Column("CEP")]
        public int CEP { get; set; }
    }
}
