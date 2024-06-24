using Microsoft.EntityFrameworkCore;
using CustomerManagementService.Data;
using CustomerManagementService.Models;

namespace CustomerManagementService.ViewModels;
/// <summary>
/// Provides methods for managing customers in the Customer Management Service.
/// </summary>
public class CustomerViewModel(CustomerContext context)
{
    /// <summary>
    /// Gets a list of all customers.
    /// </summary>
    /// <returns>A list of all customers.</returns>
    public async Task<List<Customer>> GetAllCustomers()
    {
        return await context.Customers.ToListAsync();
    }

    /// <summary>
    /// Gets a customer by their unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the customer.</param>
    /// <returns>The customer with the specified unique identifier.</returns>
    public async Task<Customer> GetCustomer(Guid id)
    {
        return await context.Customers.FindAsync(id);
    }

    /// <summary>
    /// Creates a new customer.
    /// </summary>
    /// <param name="customer">The customer to create.</param>
    /// <returns>The created customer.</returns>
    public async Task<Customer> CreateCustomer(Customer customer)
    {
        customer.CustomerId = Guid.NewGuid();
        context.Customers.Add(customer);
        await context.SaveChangesAsync();
        return customer;
    }

    /// <summary>
    /// Updates an existing customer.
    /// </summary>
    /// <param name="id">The unique identifier of the customer to update.</param>
    /// <param name="customer">The updated customer details.</param>
    /// <returns><c>true</c> if the update was successful; otherwise, <c>false</c>.</returns>
    public async Task<bool> UpdateCustomer(Guid id, Customer customer)
    {
        if (id != customer.CustomerId)
        {
            return false;
        }

        context.Entry(customer).State = EntityState.Modified;

        try
        {
            await context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!CustomerExists(id))
            {
                return false;
            }

            throw;
        }

        return true;
    }

    /// <summary>
    /// Deletes a customer by their unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the customer to delete.</param>
    /// <returns><c>true</c> if the deletion was successful; otherwise, <c>false</c>.</returns>
    public async Task<bool> DeleteCustomer(Guid id)
    {
        Customer? customer = await context.Customers.FindAsync(id);
        if (customer == null)
        {
            return false;
        }

        context.Customers.Remove(customer);
        await context.SaveChangesAsync();

        return true;
    }

    /// <summary>
    /// Checks if a customer with the specified unique identifier exists.
    /// </summary>
    /// <param name="id">The unique identifier of the customer.</param>
    /// <returns><c>true</c> if the customer exists; otherwise, <c>false</c>.</returns>
    private bool CustomerExists(Guid id)
    {
        return context.Customers.Any(e => e.CustomerId == id);
    }
}