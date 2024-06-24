using Microsoft.EntityFrameworkCore;
using CustomerManagementService.Data;
using CustomerManagementService.Models;

namespace CustomerManagementService.ViewModels;
/// <summary>
/// Provides methods for managing products in the Customer Management Service.
/// </summary>
public class ProductViewModel(CustomerContext context)
{
    /// <summary>
    /// Gets a list of all products.
    /// </summary>
    /// <returns>A list of all products.</returns>
    public async Task<List<Product>> GetAllProducts()
    {
        return await context.Products.ToListAsync();
    }

    /// <summary>
    /// Gets a product by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the product.</param>
    /// <returns>The product with the specified unique identifier.</returns>
    public async Task<Product> GetProduct(Guid id)
    {
        return await context.Products.FindAsync(id);
    }

    /// <summary>
    /// Creates a new product.
    /// </summary>
    /// <param name="product">The product to create.</param>
    /// <returns>The created product.</returns>
    public async Task<Product> CreateProduct(Product product)
    {
        product.ProductId = Guid.NewGuid();
        context.Products.Add(product);
        await context.SaveChangesAsync();
        return product;
    }

    /// <summary>
    /// Updates an existing product.
    /// </summary>
    /// <param name="id">The unique identifier of the product to update.</param>
    /// <param name="product">The updated product details.</param>
    /// <returns><c>true</c> if the update was successful; otherwise, <c>false</c>.</returns>
    public async Task<bool> UpdateProduct(Guid id, Product product)
    {
        if (id != product.ProductId)
        {
            return false;
        }

        context.Entry(product).State = EntityState.Modified;

        try
        {
            await context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ProductExists(id))
            {
                return false;
            }
            else
            {
                throw;
            }
        }

        return true;
    }

    /// <summary>
    /// Deletes a product by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the product to delete.</param>
    /// <returns><c>true</c> if the deletion was successful; otherwise, <c>false</c>.</returns>
    public async Task<bool> DeleteProduct(Guid id)
    {
        Product? product = await context.Products.FindAsync(id);
        if (product == null)
        {
            return false;
        }

        context.Products.Remove(product);
        await context.SaveChangesAsync();

        return true;
    }

    /// <summary>
    /// Checks if a product with the specified unique identifier exists.
    /// </summary>
    /// <param name="id">The unique identifier of the product.</param>
    /// <returns><c>true</c> if the product exists; otherwise, <c>false</c>.</returns>
    private bool ProductExists(Guid id)
    {
        return context.Products.Any(e => e.ProductId == id);
    }
}