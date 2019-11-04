using Atividade_Produto.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Atividade_Produto.Models
{
    public class ItensProduto : BaseEntity
    {
        [Column("Preco")]
        public double Preco { get; set; }

        [Column("Quantidade")]
        public int Quantidade { get; set; }

        public virtual Produto Produto { get; set; }
        public virtual Pedido Pedido { get; set; }
    }
}
