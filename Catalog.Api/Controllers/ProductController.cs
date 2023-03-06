using Catalog.Api.Models;
using Catalog.Api.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IProductRepository _repository;

    public ProductController(IProductRepository repository) => _repository = repository;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
    {
        var products = await _repository.GetProducts();
        return Ok(products);
    }
    [HttpGet("byId")]
    public async Task<ActionResult<Product>> GetProductById(string id)
    {
        var product = await _repository.GetProduct(id);
        return (product is null) ? NotFound() : Ok(product);
    }
    [HttpGet("byName")]
    public async Task<ActionResult<IEnumerable<Product>>> GetProductsByName(string name)
    {
        var products =  await _repository.GetProductsByName(name);
        return (products is null) ? NotFound() : Ok(products);
    }
    [HttpGet("byCategory")]
    public async Task<ActionResult<IEnumerable<Product>>> GetProductsByCategory(string category)
    {
        var products =  await _repository.GetProductsByCategory(category);
        return (products is null) ? NotFound() : Ok(products);
    }
    [HttpPost]
    public async Task<IActionResult> InsertProduct(Product product)
    {
        if (product == null)
            return BadRequest("Invalid Product");

        await _repository.CreateProduct(product);
        return Ok("Inserted successfully");
    }
    
    [HttpPut]
    public async Task<ActionResult<bool>> UpdateProduct(Product product)
    {
        if (product == null)
            return BadRequest("Invalid Product");

        await _repository.UpdateProduct(product);
        return Ok("Updated successfully");
    }
    
    [HttpDelete]
    public async Task<ActionResult<bool>> RemoveProduct(string id)
    {
        return Ok(await _repository.DeleteProduct(id));
    }
    
}