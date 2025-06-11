using APICatalogo.Context;
using APICatalogo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

namespace APICatalogo.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProdutosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Produto>> Get()
        {
            var produtos = _context.Produtos.Include(p => p.Categoria).AsNoTracking().ToList();

            if (produtos is null)
            {
                return NotFound();
            }

            return produtos;
        }

        [HttpGet("get-async")]
        public async Task<ActionResult<IEnumerable<Produto>>> GetAsync()
        {
            var produtos = await _context.Produtos.Include(p => p.Categoria).AsNoTracking().ToListAsync();

            if (produtos is null)
            {
                return NotFound();
            }

            return produtos;
        }

        [HttpGet("Categoria/{id:int}")]
        public ActionResult<CategoriaProduto> GetCategoriaProduto(int id)
        {
            var p = _context.Produtos.Include(p => p.Categoria).AsNoTracking().FirstOrDefault(p => p.ProdutoId == id);

            CategoriaProduto categoriaProduto = new CategoriaProduto();
       
            categoriaProduto.ProdutoId = p.ProdutoId;
            categoriaProduto.Categoria = p.Categoria?.Nome;
            categoriaProduto.ImagemCategoria = p.Categoria?.ImagemUrl;
                        
            return categoriaProduto;
        }

        [HttpGet("{id:int}", Name ="ObterProduto")]
        public ActionResult<Produto> Get(int id)
        {
            var produto = _context.Produtos.AsNoTracking().FirstOrDefault(p => p.ProdutoId == id);
            
            if (produto is null)
            {
                return NotFound("Produto não encontrado...");
            }

            return produto;
        }

        [HttpGet("get-nome-obrigatorio/{id:int}")]
        public ActionResult<Produto> Get(int id, [BindRequired] string nome)
        {
            var produto = _context.Produtos.AsNoTracking().FirstOrDefault(p => p.ProdutoId == id);

            if (produto is null)
            {
                return NotFound("Produto não encontrado...");
            }

            return produto;
        }

        [HttpPost]
        public ActionResult Post(Produto produto)
        {
            if (produto is null)
                return BadRequest();

            _context.Produtos.Add(produto);
            _context.SaveChanges();

            return new CreatedAtRouteResult("ObterProduto", 
                new { id = produto.ProdutoId }, produto);
        }

        [HttpPut("{id:int}")]
        public ActionResult Put (int id, Produto produto)
        {
            if (id != produto.ProdutoId)
                return BadRequest();

            _context.Entry(produto).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(produto);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var produto = _context.Produtos.FirstOrDefault(p => p.ProdutoId == id);

            if (produto is null)
                return NotFound("Produto não encontrado...");

            _context.Produtos.Remove(produto);
            _context.SaveChanges();

            return Ok();
        }
    }

    public class CategoriaProduto()
    {
        public int ProdutoId { get; set; }
        public string? Categoria { get; set; }
        public string? ImagemCategoria { get; set; }
    }
}
