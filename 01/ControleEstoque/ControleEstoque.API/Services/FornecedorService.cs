using ControleEstoque.API.Data;
using ControleEstoque.API.DTOs;
using ControleEstoque.API.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleEstoque.API.Services
{
    public class FornecedorService : IFornecedorService
    {
        private readonly AppDbContext _context;

        public FornecedorService(AppDbContext context)
        {
            _context = context;
        }


        async Task IFornecedorService.AtualizarAsync(AtualizarFornecedorDto dto)
        {
            var fornecedor = await _context.Fornecedores.FindAsync(dto.Id);

            if (fornecedor != null)
            {
                fornecedor.NomeFantasia = dto.NomeFantasia;
                _context.Fornecedores.Update(fornecedor);
               await  _context.SaveChangesAsync();
            }
           
        }
                            
        async Task<FornecedorDto> IFornecedorService.CriarAsync(CriarFornecedorDto dto)
        {
           var fornecedor = new Fornecedor
            {
                NomeFantasia = dto.NomeFantasia,
                CNPJ = dto.CNPJ
            };
            _context.Fornecedores.Add(fornecedor);
           await _context.SaveChangesAsync();

            return new FornecedorDto()
            {
                Id = fornecedor.Id,
                NomeFantasia = fornecedor.NomeFantasia,
                CNPJ = fornecedor.CNPJ
            };
        }

        async Task<FornecedorDto?> IFornecedorService.ObterPorIdAsync(int id)
        {
            var fornecedorModel = await _context.Fornecedores.FirstOrDefaultAsync(f => f.Id == id);
            if (fornecedorModel == null)
                return null;
            return new FornecedorDto
            {
                Id = fornecedorModel.Id,
                NomeFantasia = fornecedorModel.NomeFantasia,
                CNPJ = fornecedorModel.CNPJ
            };
        }
        async Task<IEnumerable<FornecedorDto>> IFornecedorService.ObterTodosAsync()
        {
            return await _context.Fornecedores // Acessa a tabela Fornecedores no banco de dados
                    .Select(f => new FornecedorDto // Projeta cada entidade Fornecedor para um FornecedorDto
                    {
                        Id = f.Id,
                        NomeFantasia = f.NomeFantasia,
                        CNPJ = f.CNPJ
                    })
            .ToListAsync(); // Executa a consulta de forma assíncrona e retorna a lista de FornecedorDto
        }
        async Task IFornecedorService.RemoverAsync(int id)
        {
            var fornecedor = await _context.Fornecedores.FirstOrDefaultAsync(f => f.Id == id);

            if (fornecedor != null) {
                _context.Fornecedores.Remove(fornecedor);
                await _context.SaveChangesAsync();
            }
        }


    }
}

