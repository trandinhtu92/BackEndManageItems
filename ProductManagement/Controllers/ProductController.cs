using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ProductManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private ApplicationDbContext _dbContext;
        public ProductController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost("Post")]
        public async Task<IActionResult> Create(ProductModel product)
        {
            _dbContext.Products.Add(product);
            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {

                throw;
            }
            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductModel>>> GetProducts()
        {
            return await _dbContext.Products.ToListAsync();
        }

        [HttpPut("ProductUpdate")]
        public async Task<IActionResult> PutProduct(ProductModel product)
        {
            _dbContext.Update(product);

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {

                throw;
            }
            return NoContent();
        }
        [HttpDelete("DeleteProduct")]
        public async Task<IActionResult> DeleteProduct(ProductModel productData)
        {
            var product = await _dbContext.Products.FindAsync(productData.IDProduct);
            if (product == null)
            {
                return NotFound();
            }
            _dbContext.Products.Remove(product);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

    }
}
