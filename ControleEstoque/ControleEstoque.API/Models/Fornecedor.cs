using System.ComponentModel.DataAnnotations;

namespace ControleEstoque.API.Models
{
    public class Fornecedor
    {

        public int Id { get; set; }


        [StringLength(100), Required]
        public string NomeFantasia { get; set; }

        public string CNPJ { get; set; }

        public ICollection<Produto> Produtos { get; set; }

    }
}
