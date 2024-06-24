namespace CustomerManagementService.Models;
/// <summary>
/// Represents a sales cache record in the Customer Management Service.
/// </summary>
public class SalesCache
{
    /// <summary>
    /// Gets or sets the category of the sales cache.
    /// </summary>
    public string Category { get; set; }

    /// <summary>
    /// Gets or sets the year of the sales cache.
    /// </summary>
    public int Year { get; set; }

    /// <summary>
    /// Gets or sets the total sales for the specified category and year.
    /// </summary>
    public decimal TotalSales { get; set; }
}