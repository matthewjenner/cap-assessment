namespace CustomerManagementService.Models;
/// <summary>
/// Represents a product in the Customer Management Service.
/// </summary>
public class Product
{
    /// <summary>
    /// Gets or sets the unique identifier for the product.
    /// </summary>
    public Guid ProductId { get; set; }

    /// <summary>
    /// Gets or sets the name of the product.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the price of the product.
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    /// Gets or sets the category of the product.
    /// </summary>
    public string Category { get; set; }
}