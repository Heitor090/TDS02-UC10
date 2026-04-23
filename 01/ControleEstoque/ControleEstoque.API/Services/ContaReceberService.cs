using ControleEstoque.API.Data;
using ControleEstoque.API.DTOs;
using ControleEstoque.API.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleEstoque.API.Services
{
    public class ContaReceberService : IContaReceberService
    {

        private readonly AppDbContext _context;

        public ContaReceberService(AppDbContext context)
        {
            _context = context;
        }


       

        public async Task AtualizarAsync(AtualizarContaReceberDto dto)
        {
           var contaReceber = await _context.ContasReceber.FindAsync(dto.Id);
           if (contaReceber != null)
           {
               var cliente = await _context.Clientes.FirstOrDefaultAsync(f => f.Id == dto.ClienteId);
               if (cliente == null) throw new Exception("Cliente não encontrado");

                contaReceber.Descricao = dto.Descricao;
                contaReceber.Valor = dto.Valor;
                contaReceber.DataVencimento = dto.DataVencimento;
                contaReceber.DataPagamento = dto.DataPagamento;
                contaReceber.Status = dto.Status;
                contaReceber.ClienteId = dto.ClienteId;
                    
                await _context.SaveChangesAsync();
            }
           

        }

       

        public async Task<ContaReceberDto> CriarAsync(CriarContaReceberDto dto)
        {
            var contaReceber = new ContaReceber
            {
                Descricao = dto.Descricao,
                Valor = dto.Valor,
                DataVencimento = dto.DataVencimento,
                Status = dto.Status,
                ClienteId = dto.ClienteId
            };
            _context.ContasReceber.Add(contaReceber);
            await _context.SaveChangesAsync();

            return new ContaReceberDto
            {
                Id = contaReceber.Id,
                Descricao = contaReceber.Descricao,
                Valor = contaReceber.Valor,
                DataVencimento = contaReceber.DataVencimento,
                DataPagamento = contaReceber.DataPagamento,
                Status = contaReceber.Status,
                ClienteId = contaReceber.ClienteId
            };
        }         

        public DateTime GetDataVencimento()
        {
            throw new NotImplementedException();
        }

        public async Task<ContaReceberDto?> ObterPorIdAsync(int id, DateTime dataVencimento)
        {
                var contasReceber = _context.ContasReceber.FirstOrDefault(c => c.Id == id);
                if (contasReceber == null)               
                    return null;

            return new ContaReceberDto
            {
                Id = contasReceber.Id,
                Descricao = contasReceber.Descricao,
                Valor = contasReceber.Valor,
                DataVencimento = contasReceber.DataVencimento,
                DataPagamento = contasReceber.DataPagamento,
                Status = contasReceber.Status,
                ClienteId = contasReceber.ClienteId
            };
        }

        public Task ObterPorIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ContaReceberDto>> ObterTodosAsync()
        {
                return await _context.ContasReceber.Select(c => new ContaReceberDto
                {
                    Id = c.Id,
                    Descricao = c.Descricao,
                    Valor = c.Valor,
                    DataVencimento = c.DataVencimento,
                    DataPagamento = c.DataPagamento,
                    Status = c.Status,
                    ClienteId = c.ClienteId
                })
                .ToListAsync();
        }

        Task IContaReceberService.DeletarAsync(int id)               
        {
            var contaReceber =  _context.ContasReceber.FirstOrDefault(c => c.Id == id);
            if (contaReceber != null)
            {
                _context.ContasReceber.Remove(contaReceber);
                return _context.SaveChangesAsync();
            }
            return Task.CompletedTask;

        }
    }
}
