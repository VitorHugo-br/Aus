using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetoAus.BLL.Dto;
using ProjetoAus.BLL.Services;
using ProjetoAus.Data.interfaces;
using ProjetoAus.Models;

namespace ProjetoAus.Api.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class ProductController(ProductService productService) : ControllerBase
{
    [HttpGet]
    [Route("")]
    public async Task<IActionResult> GetAll([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
    {
        var products = await productService.GetAllAsync(page, pageSize);
        return Ok(products);
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<ActionResult<Product>> GetById(Guid id)
    {
        var product = await productService.GetByIdAsync(id);
        return product is not null ? Ok(product) : NotFound();
    }

    [HttpPost]
    [Route("")]
    public async Task<ActionResult<Product>> AddAsync([FromBody] RegisterProductDto productDto)
    {
        var createdProduct = await productService.CreateAsync(productDto);
        if (createdProduct == null) return BadRequest("All fields are required");
        return CreatedAtAction(nameof(GetById), new { id = createdProduct.Id }, createdProduct);
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> UpdateAsync(Guid id, [FromBody] ProductDto productDto)
    {
        var updatedProduct = await productService.UpdateAsync(id, productDto);
        if (updatedProduct == null) return NotFound();
        return Ok(updatedProduct);
    }

    [HttpDelete()]
    [Route("{id}")]
    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        var deleteProduct = await productService.DeleteAsync(id);
        if (deleteProduct == null) return NotFound("Incorrect Id or product doesn't exist");
        return Ok(deleteProduct);
    }
    
}