namespace ModeloDDD.Application.DTO
{
    public class ProdutoDTO
    {
        public int? Id { get; set; }
        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public int Quantidade { get; set; }
        public decimal ValorMaximoVenda { get; set; }
    }
}