using Microsoft.AspNetCore.Mvc;
using CustomerManagementService.Models;
using CustomerManagementService.ViewModels;

namespace CustomerManagementService.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CustomerController(CustomerViewModel customerViewModel) : ControllerBase
{
    /// <summary>
    /// Retrieves a list of all customers.
    /// </summary>
    /// <returns>A list of all customers.</returns>
    /// <response code="200">Returns the list of customers.</response>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Customer>>> GetAllCustomers()
    {
        return await customerViewModel.GetAllCustomers();
    }

    /// <summary>
    /// Creates a new customer.
    /// </summary>
    /// <param name="customer">The customer to create.</param>
    /// <returns>The created customer.</returns>
    /// <response code="201">Returns the newly created customer.</response>
    /// <response code="400">If the customer is null or invalid.</response>
    [HttpPost]
    public async Task<ActionResult<Customer>> CreateCustomer(Customer customer)
    {
        Customer createdCustomer = await customerViewModel.CreateCustomer(customer);
        return CreatedAtAction(nameof(GetCustomer), new { id = createdCustomer.CustomerId }, createdCustomer);
    }

    /// <summary>
    /// Retrieves a customer by their unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the customer.</param>
    /// <returns>The customer with the specified unique identifier.</returns>
    /// <response code="200">Returns the customer.</response>
    /// <response code="404">If the customer is not found.</response>
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<Customer>> GetCustomer(Guid id)
    {
        Customer? customer = await customerViewModel.GetCustomer(id);
        if (customer == null)
        {
            return NotFound();
        }
        return customer;
    }

    /// <summary>
    /// Updates a customer by their unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the customer to update.</param>
    /// <param name="customer">The updated customer details.</param>
    /// <returns>No content.</returns>
    /// <response code="204">If the update was successful.</response>
    /// <response code="400">If the customer is null or invalid.</response>
    /// <response code="404">If the customer is not found.</response>
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateCustomer(Guid id, Customer customer)
    {
        if (!await customerViewModel.UpdateCustomer(id, customer))
        {
            return NotFound();
        }
        return NoContent();
    }

    /// <summary>
    /// Deletes a customer by their unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the customer to delete.</param>
    /// <returns>No content.</returns>
    /// <response code="204">If the deletion was successful.</response>
    /// <response code="404">If the customer is not found.</response>
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteCustomer(Guid id)
    {
        if (!await customerViewModel.DeleteCustomer(id))
        {
            return NotFound();
        }
        return NoContent();
    }
}