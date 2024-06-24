using Microsoft.AspNetCore.Mvc;
using CustomerManagementService.Models;
using CustomerManagementService.ViewModels;

namespace CustomerManagementService.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ProductController(ProductViewModel productViewModel) : ControllerBase
{
    /// <summary>
    /// Retrieves a list of all products.
    /// </summary>
    /// <returns>A list of all products.</returns>
    /// <response code="200">Returns the list of products.</response>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Product>>> GetAllProducts()
    {
        return await productViewModel.GetAllProducts();
    }

    /// <summary>
    /// Creates a new product.
    /// </summary>
    /// <param name="product">The product to create.</param>
    /// <returns>The created product.</returns>
    /// <response code="201">Returns the newly created product.</response>
    /// <response code="400">If the product is null or invalid.</response>
    [HttpPost]
    public async Task<ActionResult<Product>> CreateProduct(Product product)
    {
        Product createdProduct = await productViewModel.CreateProduct(product);
        return CreatedAtAction(nameof(GetProduct), new { id = createdProduct.ProductId }, createdProduct);
    }

    /// <summary>
    /// Retrieves a product by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the product.</param>
    /// <returns>The product with the specified unique identifier.</returns>
    /// <response code="200">Returns the product.</response>
    /// <response code="404">If the product is not found.</response>
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<Product>> GetProduct(Guid id)
    {
        Product? product = await productViewModel.GetProduct(id);
        if (product == null)
        {
            return NotFound();
        }
        return product;
    }

    /// <summary>
    /// Updates a product by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the product to update.</param>
    /// <param name="product">The updated product details.</param>
    /// <returns>No content.</returns>
    /// <response code="204">If the update was successful.</response>
    /// <response code="400">If the product is null or invalid.</response>
    /// <response code="404">If the product is not found.</response>
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateProduct(Guid id, Product product)
    {
        if (!await productViewModel.UpdateProduct(id, product))
        {
            return NotFound();
        }
        return NoContent();
    }

    /// <summary>
    /// Deletes a product by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the product to delete.</param>
    /// <returns>No content.</returns>
    /// <response code="204">If the deletion was successful.</response>
    /// <response code="404">If the product is not found.</response>
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteProduct(Guid id)
    {
        if (!await productViewModel.DeleteProduct(id))
        {
            return NotFound();
        }
        return NoContent();
    }
}