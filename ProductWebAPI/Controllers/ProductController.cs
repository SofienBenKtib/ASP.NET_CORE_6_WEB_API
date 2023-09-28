using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductWebAPI.Models;

namespace ProductWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductDbContext _dbContext;
        public ProductController(ProductDbContext productDbContext)
        {
            _dbContext = productDbContext;
        }

        [HttpGet]
        //returns all the products in the database
        public ActionResult<IEnumerable<Product>> GetProducts()
        {
            return _dbContext.Products;
        }

        //returns a product by id
        [HttpGet("{productId:int}")]
        public async Task<ActionResult<Product>> GetById(int productId)
        {
            var product = await _dbContext.Products.FindAsync(productId);
            return product;
        }

        //creating a product
        [HttpPost]
        public async Task<ActionResult<Product>> Create(Product product)
        {
            await _dbContext.Products.AddAsync(product);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }
        //updating an existing product
        [HttpPut]
        public async Task<ActionResult<Product>> Update(Product product)
        {
            _dbContext.Products.Update(product);
            await _dbContext.SaveChangesAsync();
            return product;
        }

        //deleting a product from the database
        [HttpDelete("{productId:int}")]
        public async Task<ActionResult> Delete(int productId)
        {
            var product= await _dbContext.Products.FindAsync(productId);
            _dbContext.Products.Remove(product);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}
