using ControleEstoque.API.Data;
using ControleEstoque.API.DTOs;
using Microsoft.EntityFrameworkCore;

namespace ControleEstoque.API.Services
{
    public class ProdutoService : IProdutoService   
    {
        private readonly AppDbContext _context;

        public ProdutoService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ProdutoDto> ObterProdutoPorIdAsync(int id)
        {
           var produto = await _context.Produtos
                .Include(p => p.Fornecedor)
                .FirstOrDefaultAsync(p => p.Id == id);
            if (produto == null) return null;
                         
            
            return new ProdutoDto
            {
                Id = produto.Id,
                Nome = produto.Nome,
                Preco = produto.Preco,
                QauntidadeEstoque = produto.QauntidadeEstoque,
                Fornecedor = new FornecedorDto
                {
                    Id = produto.Fornecedor.Id,
                    CNPJ = produto.Fornecedor.CNPJ,
                    NomeFantasia = produto.Fornecedor.NomeFantasia
                }
            };
        }

        public Task<IEnumerable<ProdutoDto>> ObterTodosProdutosAsync()
        {
            throw new NotImplementedException();
        }
    }
}
