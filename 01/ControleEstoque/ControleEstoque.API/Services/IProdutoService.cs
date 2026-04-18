using ControleEstoque.API.DTOs;

namespace ControleEstoque.API.Services
{
    public interface IProdutoService
    {
        Task<IEnumerable<ProdutoDto>> ObterTodosProdutosAsync();
        Task<ProdutoDto?> ObterProdutoPorIdAsync(int id);
    }
}

