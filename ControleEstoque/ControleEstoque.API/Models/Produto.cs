using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControleEstoque.API.Models
{
    public class Produto
    {
        public int Id { get; set; }

        [StringLength (100), Required]
        public string Nome { get; set; }


        [Column(TypeName ="decimal(10,2)"), Required]
        public decimal Preco { get; set; }


        public int QuantidadeEstoque { get; set; }

        public ICollection<PedidoItem> PedidoItems { get; set; }

        [ForeignKey("Fornecedor")]
        public int FornecedorId { get; set; }
        public Fornecedor Fornecedor { get; set; }



    }
}
