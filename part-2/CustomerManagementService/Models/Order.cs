namespace CustomerManagementService.Models;
/// <summary>
/// Represents an order in the Customer Management Service.
/// </summary>
public class Order
{
    /// <summary>
    /// Gets or sets the unique identifier for the order.
    /// </summary>
    public Guid OrderId { get; set; }

    /// <summary>
    /// Gets or sets the unique identifier for the product associated with the order.
    /// </summary>
    public Guid ProductId { get; set; }

    /// <summary>
    /// Gets or sets the unique identifier for the customer who placed the order.
    /// </summary>
    public Guid CustomerId { get; set; }

    /// <summary>
    /// Gets or sets the unique identifier for the sales employee who handled the order.
    /// </summary>
    public Guid EmployeeId { get; set; }

    /// <summary>
    /// Gets or sets the quantity of the product ordered.
    /// </summary>
    public int? Quantity { get; set; }

    /// <summary>
    /// Gets or sets the date when the order was placed.
    /// </summary>
    public DateTime OrderDate { get; set; }

    /// <summary>
    /// Gets or sets the product associated with the order.
    /// </summary>
    public Product Product { get; set; }

    /// <summary>
    /// Gets or sets the customer who placed the order.
    /// </summary>
    public Customer Customer { get; set; }

    /// <summary>
    /// Gets or sets the sales employee who handled the order.
    /// </summary>
    public SalesEmployee SalesEmployee { get; set; }
}