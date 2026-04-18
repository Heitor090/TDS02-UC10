using ControleEstoque.API.Data;
using ControleEstoque.API.DTOs;
using ControleEstoque.API.Models;
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

        public async Task<IEnumerable<ProdutoDto>> ObterTodosProdutosAsync()
        {
            return await _context.Produtos
                .Select(p => new ProdutoDto
                {
                    Id = p.Id,
                    Nome = p.Nome,
                    Preco = p.Preco,
                    QauntidadeEstoque = p.QauntidadeEstoque,
                    Fornecedor = new FornecedorDto
                    {
                        Id = p.Fornecedor.Id,
                        CNPJ = p.Fornecedor.CNPJ,
                        NomeFantasia = p.Fornecedor.NomeFantasia
                    }
                })
                .ToListAsync();

        }

        public async Task RemoverAsync(int id)
        {
            var produto = await _context.Produtos.FindAsync(id);
            if (produto != null) _context.Produtos.Remove(produto);
            await _context.SaveChangesAsync();
        }

        public async Task<ProdutoDto>CriarProdutoAsync(CriarProdutoDto dto)
        {
            var produto = new Produto()
            {
                Nome = dto.Nome,
                Preco = dto.Preco,
                QauntidadeEstoque = dto.QauntidadeEstoque,
                FornecedorId = dto.FornecedorId
            };
           
            _context.Produtos.Add(produto);
            await _context.SaveChangesAsync();
            return await ObterProdutoPorIdAsync(produto.Id);
        }
        

        public Task AtualizarProdutoAsync(ProdutoDto produtoDto)
        {
            throw new NotImplementedException();
        }
    }
}
