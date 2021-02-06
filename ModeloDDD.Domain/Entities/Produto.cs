using System.ComponentModel.DataAnnotations.Schema;

namespace ModeloDDD.Domain.Entities
{
    [Table("Produto")]
    public class Produto : Base
    {
        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public bool IsDisponivel { get; set; }
        public int Quantidade { get; set; }
    }
}
