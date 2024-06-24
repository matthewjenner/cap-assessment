using Microsoft.EntityFrameworkCore;
using CustomerManagementService.Data;
using CustomerManagementService.Models;

namespace CustomerManagementService.ViewModels;
/// <summary>
/// Provides methods for managing orders in the Customer Management Service.
/// </summary>
public class OrderViewModel(CustomerContext context)
{
    /// <summary>
    /// Gets a list of all orders, filtered by the specified number of days in the past.
    /// </summary>
    /// <param name="orderDaysInPast">The number of days in the past to filter orders by.</param>
    /// <returns>A list of all orders that match the filter.</returns>
    public async Task<List<Order>> GetAllOrders(int orderDaysInPast)
    {
        DateTime filterDate = GetFilterDateValue(orderDaysInPast);
        return await context.Orders
            .Include(o => o.Product)
            .Include(o => o.Customer)
            .Include(o => o.SalesEmployee)
            .Where(o => o.OrderDate >= filterDate).ToListAsync();
    }

    /// <summary>
    /// Gets an order by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the order.</param>
    /// <returns>The order with the specified unique identifier.</returns>
    public async Task<Order?> GetOrder(Guid id)
    {
        return await context.Orders
            .Include(o => o.Product)
            .Include(o => o.Customer)
            .Include(o => o.SalesEmployee)
            .FirstOrDefaultAsync(o => o.OrderId == id);
    }

    /// <summary>
    /// Creates a new order.
    /// </summary>
    /// <param name="order">The order to create.</param>
    /// <returns>The created order.</returns>
    public async Task<Order> CreateOrder(Order order)
    {
        order.OrderId = Guid.NewGuid();
        context.Orders.Add(order);
        await context.SaveChangesAsync();
        return order;
    }

    /// <summary>
    /// Updates an existing order.
    /// </summary>
    /// <param name="id">The unique identifier of the order to update.</param>
    /// <param name="order">The updated order details.</param>
    /// <returns><c>true</c> if the update was successful; otherwise, <c>false</c>.</returns>
    public async Task<bool> UpdateOrder(Guid id, Order order)
    {
        if (id != order.OrderId)
        {
            return false;
        }

        context.Entry(order).State = EntityState.Modified;

        try
        {
            await context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!OrderExists(id))
            {
                return false;
            }

            throw;
        }

        return true;
    }

    /// <summary>
    /// Deletes an order by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the order to delete.</param>
    /// <returns><c>true</c> if the deletion was successful; otherwise, <c>false</c>.</returns>
    public async Task<bool> DeleteOrder(Guid id)
    {
        Order? order = await context.Orders.FindAsync(id);
        if (order == null)
        {
            return false;
        }

        context.Orders.Remove(order);
        await context.SaveChangesAsync();

        return true;
    }

    /// <summary>
    /// Gets orders by the specified product identifier, filtered by the specified number of days in the past.
    /// </summary>
    /// <param name="productId">The unique identifier of the product.</param>
    /// <param name="orderDaysInPast">The number of days in the past to filter orders by.</param>
    /// <returns>A list of orders that match the filter.</returns>
    public async Task<List<Order>> GetOrdersByProductId(Guid productId, int orderDaysInPast)
    {
        DateTime filterDate = GetFilterDateValue(orderDaysInPast);
        return await context.Orders
            .Include(o => o.Product)
            .Include(o => o.Customer)
            .Include(o => o.SalesEmployee)
            .Where(o => o.ProductId == productId && o.OrderDate >= filterDate)
            .ToListAsync();
    }

    /// <summary>
    /// Gets orders by the specified customer identifier, filtered by the specified number of days in the past.
    /// </summary>
    /// <param name="customerId">The unique identifier of the customer.</param>
    /// <param name="orderDaysInPast">The number of days in the past to filter orders by.</param>
    /// <returns>A list of orders that match the filter.</returns>
    public async Task<List<Order>> GetOrdersByCustomerId(Guid customerId, int orderDaysInPast)
    {
        DateTime filterDate = GetFilterDateValue(orderDaysInPast);
        return await context.Orders
            .Include(o => o.Product)
            .Include(o => o.Customer)
            .Include(o => o.SalesEmployee)
            .Where(o => o.CustomerId == customerId && o.OrderDate >= filterDate)
            .ToListAsync();
    }

    /// <summary>
    /// Gets orders by the specified employee identifier, filtered by the specified number of days in the past.
    /// </summary>
    /// <param name="employeeId">The unique identifier of the sales employee.</param>
    /// <param name="orderDaysInPast">The number of days in the past to filter orders by.</param>
    /// <returns>A list of orders that match the filter.</returns>
    public async Task<List<Order>> GetOrdersByEmployeeId(Guid employeeId, int orderDaysInPast)
    {
        DateTime filterDate = GetFilterDateValue(orderDaysInPast);
        return await context.Orders
            .Include(o => o.Product)
            .Include(o => o.Customer)
            .Include(o => o.SalesEmployee)
            .Where(o => o.EmployeeId == employeeId && o.OrderDate >= filterDate)
            .ToListAsync();
    }

    /// <summary>
    /// Gets orders by the specified quantity, filtered by the specified number of days in the past.
    /// </summary>
    /// <param name="quantity">The quantity of products in the order.</param>
    /// <param name="orderDaysInPast">The number of days in the past to filter orders by.</param>
    /// <returns>A list of orders that match the filter.</returns>
    public async Task<List<Order>> GetOrdersByQuantity(int? quantity, int orderDaysInPast)
    {
        if (quantity is 0) quantity = null;
        DateTime filterDate = GetFilterDateValue(orderDaysInPast);
        return await context.Orders
            .Include(o => o.Product)
            .Include(o => o.Customer)
            .Include(o => o.SalesEmployee)
            .Where(o => o.Quantity == quantity && o.OrderDate >= filterDate)
            .ToListAsync();
    }

    /// <summary>
    /// Checks if an order with the specified unique identifier exists.
    /// </summary>
    /// <param name="id">The unique identifier of the order.</param>
    /// <returns><c>true</c> if the order exists; otherwise, <c>false</c>.</returns>
    private bool OrderExists(Guid id)
    {
        return context.Orders.Any(e => e.OrderId == id);
    }

    /// <summary>
    /// Gets the date value to filter orders by, based on the specified number of days in the past.
    /// </summary>
    /// <param name="orderDaysInPast">The number of days in the past to filter orders by.</param>
    /// <returns>The date value to filter orders by.</returns>
    private static DateTime GetFilterDateValue(int orderDaysInPast)
    {
        return orderDaysInPast is 0 ? DateTime.UnixEpoch : DateTime.Now.AddDays(-orderDaysInPast);
    }
}