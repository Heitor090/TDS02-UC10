using ControleEstoque.API.DTOs;

namespace ControleEstoque.API.Services
{
    public interface IContaReceberService
    {
    
        Task  <IEnumerable<ContaReceberDto>>ObterTodosAsync();

        Task <ContaReceberDto?>ObterPorIdAsync(int id, DateTime dataVencimento);

        Task <ContaReceberDto>CriarAsync(CriarContaReceberDto dto) ;

        Task AtualizarAsync(AtualizarContaReceberDto dto);

        Task DeletarAsync(int id);

        
        DateTime GetDataVencimento();
        Task ObterPorIdAsync(int id);
    }
}
