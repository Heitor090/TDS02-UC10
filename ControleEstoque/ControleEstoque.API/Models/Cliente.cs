using System.ComponentModel.DataAnnotations;

namespace ControleEstoque.API.Models
{
    public class  Cliente: Usuario 
    {
        [StringLength(14)]
        public string cpf { get; set; }

        public ICollection<Pedido> Pedidos { get; set; }

    }


}
