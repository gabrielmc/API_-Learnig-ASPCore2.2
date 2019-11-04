using System.ComponentModel.DataAnnotations.Schema;

namespace Atividade_Produto.Models.Base
{
    public class BaseEntity
    {
        [Column("Id")]
        public int Id { get; set; }
    }
}
