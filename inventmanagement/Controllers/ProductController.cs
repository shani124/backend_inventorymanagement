using inventmanagement.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace inventmanagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductContext _productContext;

        public ProductController(ProductContext productContext)
        {
            _productContext = productContext;
        }

        // GET: api/<ProductController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products =await _productContext.Products.ToListAsync();
            return Ok(products);
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ProductController>
        [HttpPost]
        public async Task<IActionResult> PostAsync(Product product)
        {   
            _productContext.Products.Add(product);
            await _productContext.SaveChangesAsync();
            return Created($"/get-product-by-id?id={product.Id}", product);
        }

        // PUT api/<ProductController>/5
        [HttpPut]
        public async Task<IActionResult> PutAsync(Product productupdate)
        {
            _productContext.Products.Update(productupdate);
            await _productContext.SaveChangesAsync();
            return NoContent();
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var producttodelete=await _productContext.Products.FindAsync(id);
            _productContext.Products.Remove(producttodelete);
            await _productContext.SaveChangesAsync();
            return NoContent();
        }
    }
}
