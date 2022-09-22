
using Core.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController: ControllerBase
    {
        private StoreContext _context;

        public StoreContext Context { get; }
        public ProductController(StoreContext context){
            _context = context;

        }
        [HttpGet]

        public async Task<ActionResult<List<Product>>> GetProducts()
        {

           var products = await _context.Products.ToListAsync();
           return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Product>>> GetProduct(int id){
            var singleProduct = await _context.Products.FindAsync(id);
            return Ok(singleProduct);
        }
        
    }
}