using Atividade_Produto.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Atividade_Produto.Models
{
    public class Produto : BaseEntity
    {
        [Column("Nome")]
        public string Nome { get; set; }

        [Column("IdCategoria")]
        public string IdCategoria { get; set; }

        [Column("Preco")]
        public string Preco { get; set; }

        [Column("Estoque")]
        public string Estoque { get; set; }

        public virtual Categoria Categoria { get; set; }
    }
}
