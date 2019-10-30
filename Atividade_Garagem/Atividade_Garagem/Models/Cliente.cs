using Atividade_Garagem.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Atividade_Garagem.Models
{
    public class Cliente : BaseEntity
    {
        [Column("Nome")]
        public string Nome { get; set; }

        [Column("CPF")]
        public string CPF { get; set; }

        [Column("PlacaVeiculo")]
        public string PlacaVeiculo { get; set; }
    }
}
