 using ControleEstoque.API.DTOs;
using ControleEstoque.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ControleEstoque.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContaReceberController : ControllerBase
    {
        private readonly IContaReceberService _contaReceberService;

        public ContaReceberController(IContaReceberService contaReceberService)
        {
            _contaReceberService = contaReceberService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var contasReceber = await _contaReceberService.ObterTodosAsync();
            return Ok(contasReceber);
        }

        [HttpGet("{id}")] 
        public async Task<IActionResult> GetById(int id, DateTime dataVencimento)
        {
            var contaReceber = await _contaReceberService.ObterPorIdAsync(id, dataVencimento);
            if (contaReceber == null) 
                return NotFound();
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CriarContaReceberDto dto)
        {
            var contaReceberCriada = await _contaReceberService.CriarAsync(dto);
            return Created(nameof(Create), contaReceberCriada);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, AtualizarContaReceberDto dto)
        {
            var existe = await _contaReceberService.ObterPorIdAsync(id, _contaReceberService.GetDataVencimento());
            if (existe == null) 
                return NotFound();

            await _contaReceberService.AtualizarAsync(dto);
            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _contaReceberService.DeletarAsync(id);
            return NoContent();
        }
    }
}
