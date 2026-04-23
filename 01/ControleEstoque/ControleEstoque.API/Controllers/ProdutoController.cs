using ControleEstoque.API.DTOs;
using ControleEstoque.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ControleEstoque.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService _produtoService;

        public ProdutoController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
            => Ok(await _produtoService.ObterTodosProdutosAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
            => Ok(await _produtoService.ObterProdutoPorIdAsync(id));

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _produtoService.RemoverAsync(id);
            return Ok("Produto removido com sucesso!");
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CriarProdutoDto dto)
        {
            var produto = await _produtoService.CriarProdutoAsync(dto);
            return Ok(produto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] AtualizarProdutoDto dto)
        {
            if (id != dto.Id) return BadRequest("O Id da rota é difrente do id do Produto.");
            await _produtoService.AtualizarProdutoAsync(dto);
            return NoContent();




        }
    }
}
