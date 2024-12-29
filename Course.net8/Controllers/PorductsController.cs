using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
namespace Course.net8.Controllers;


[Route("api/[controller]")]
[ApiController]
public class PorductsController : Controller
{
    private readonly IProductsRepository _productsRepository;
    
    public PorductsController(
        IProductsRepository productsRepository)
    {
        this._productsRepository = productsRepository;
    }


    [HttpGet]
    public async Task<ActionResult<List<Product>>> Get()
    {
        var result =  await _productsRepository.GetAllProducts();
        
        return Ok(result);
    }
    
    [HttpGet("{id}")]
    [ProducesResponseType(200, Type = typeof(Product))]
    [ProducesResponseType(404)]
    public async Task<ActionResult<Product>> GetById(int id)
    {
        var result = await _productsRepository.GetProductById(id);
        if (result == null)
        {
            return NotFound();
        }
        else
        {
            return Ok(result);
        }
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(200, Type = typeof(Product))]
    [ProducesResponseType(404)]
    public  async Task<ActionResult<Product>> DeleteItem(int id)
    {
        var result = await _productsRepository.GetProductById(id);
        if (result == null)
        {
            return NotFound();
        }
        
        
        await _productsRepository.DeleteItem(id);
        return Ok(result);
        
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Product>> UpdateItem(int id, Product product)
    {
        var result = await _productsRepository.GetProductById(id);
        if (result == null)
        {
            return NotFound();
        }
        await _productsRepository.UpdateProduct(id,product);

        return Ok(result);
    }

    [HttpPost]
    [ProducesResponseType(201, Type = typeof(Product))]
    public async Task<ActionResult<Product>> AddNewProduct(Product product)
    {
       var addedProduct = await _productsRepository.AddNewProduct(product);
       return Created($"api/products/{addedProduct.Id}", addedProduct);
    }
    
    


}