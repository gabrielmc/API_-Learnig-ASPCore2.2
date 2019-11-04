using Atividade_Produto.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Atividade_Produto.Models
{
    public class Categoria : BaseEntity
    {
        [Column("Nome")]
        public string Nome { get; set; }

        [Column("Descricao")]
        public string Descricao { get; set; }
    }
}
