namespace CustomerManagementService.Models;
// <summary>
/// Represents a customer in the Customer Management Service.
/// </summary>
public class Customer
{
    /// <summary>
    /// Gets or sets the unique identifier for the customer.
    /// </summary>
    public Guid CustomerId { get; set; }

    /// <summary>
    /// Gets or sets the name of the customer.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the email address of the customer.
    /// </summary>
    public string Email { get; set; }

    /// <summary>
    /// Gets or sets the region where the customer is located.
    /// </summary>
    public string Region { get; set; }
}
