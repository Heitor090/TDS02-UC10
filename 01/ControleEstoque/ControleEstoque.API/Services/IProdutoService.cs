using ControleEstoque.API.DTOs;

namespace ControleEstoque.API.Services
{
    public interface IProdutoService
    {
        Task<IEnumerable<ProdutoDto>> ObterTodosProdutosAsync();
        Task<ProdutoDto?> ObterProdutoPorIdAsync(int id);
        Task RemoverAsync(int id);
        Task<ProdutoDto> CriarProdutoAsync(CriarProdutoDto criarProdutoDto);
         Task AtualizarProdutoAsync(ProdutoDto produtoDto);
        Task AtualizarProdutoAsync(AtualizarProdutoDto dto);
    }
}

