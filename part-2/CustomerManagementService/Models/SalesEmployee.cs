namespace CustomerManagementService.Models;
/// <summary>
/// Represents a sales employee in the Customer Management Service.
/// </summary>
public class SalesEmployee
{
    /// <summary>
    /// Gets or sets the unique identifier for the sales employee.
    /// </summary>
    public Guid EmployeeId { get; set; }

    /// <summary>
    /// Gets or sets the name of the sales employee.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the region where the sales employee operates.
    /// </summary>
    public string Region { get; set; }

    /// <summary>
    /// Gets or sets the unique identifier for the manager of the sales employee.
    /// </summary>
    public Guid? ManagerId { get; set; }

    /// <summary>
    /// Gets or sets the manager of the sales employee.
    /// </summary>
    public SalesEmployee Manager { get; set; }
}