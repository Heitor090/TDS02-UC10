namespace ControleEstoque.API.DTOs
{
    public class ContaReceberDto
    {

            public int Id { get; set; }
            public string Descricao { get; set; }
            public decimal Valor { get; set; }
            public DateTime DataVencimento { get; set; }
            public DateTime? DataPagamento { get; set; }
            public string Status { get; set; }

    }

    public class CriarContaReceberDto
    {
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataVencimento { get; set; }
        public string Status { get; set; }
    }

    public class AtualizarContaReceberDto
        {
            public int Id { get; set; }
            public string Descricao { get; set; }
            public decimal Valor { get; set; }
            public DateTime DataVencimento { get; set; }
            public DateTime? DataPagamento { get; set; }
            public string Status { get; set; }
    }
}
