using ControleEstoque.API.DTOs;

namespace ControleEstoque.API.Services
{
    public interface IContaReceberService
    {
    
        Task  <IEnumerable<ContaReceberDto>>ObterTodosAsync();

        Task <ContaReceberDto?>ObterPorIdAsync(int id, DateTime dataVencimento);

        Task <ContaReceberDto>CriarAsync(CriarContaReceberDto dto) ;

        Task AtualizarAsync(AtualizarContaReceberDto dto, int id);

        Task DeletarAsync(int id);

        Task AtualizarAsync(AtualizarContaReceberDto dto);
        DateTime GetDataVencimento();
        Task ObterPorIdAsync(int id);
    }
}
