using Microsoft.AspNetCore.Mvc;
using CustomerManagementService.Models;
using CustomerManagementService.ViewModels;

namespace CustomerManagementService.Controllers;
[Route("api/[controller]")]
[ApiController]
public class OrderController(OrderViewModel orderViewModel) : ControllerBase
{
    /// <summary>
    /// Retrieves a list of all orders, optionally filtered by the specified number of days in the past.
    /// </summary>
    /// <param name="orderDaysInPast">The number of days in the past to filter orders by.</param>
    /// <returns>A list of all orders that match the filter.</returns>
    /// <response code="200">Returns the list of orders.</response>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Order>>> GetAllOrders([FromQuery] int orderDaysInPast = 0)
    {
        return await orderViewModel.GetAllOrders(orderDaysInPast);
    }

    /// <summary>
    /// Creates a new order.
    /// </summary>
    /// <param name="order">The order to create.</param>
    /// <returns>The created order.</returns>
    /// <response code="201">Returns the newly created order.</response>
    /// <response code="400">If the order is null or invalid.</response>
    [HttpPost]
    public async Task<ActionResult<Order>> CreateOrder(Order order)
    {
        Order createdOrder = await orderViewModel.CreateOrder(order);
        return CreatedAtAction(nameof(GetOrder), new { id = createdOrder.OrderId }, createdOrder);
    }

    /// <summary>
    /// Retrieves an order by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the order.</param>
    /// <returns>The order with the specified unique identifier.</returns>
    /// <response code="200">Returns the order.</response>
    /// <response code="404">If the order is not found.</response>
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<Order>> GetOrder(Guid id)
    {
        Order? order = await orderViewModel.GetOrder(id);
        if (order == null)
        {
            return NotFound();
        }
        return order;
    }

    /// <summary>
    /// Updates an order by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the order to update.</param>
    /// <param name="order">The updated order details.</param>
    /// <returns>No content.</returns>
    /// <response code="204">If the update was successful.</response>
    /// <response code="400">If the order is null or invalid.</response>
    /// <response code="404">If the order is not found.</response>
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateOrder(Guid id, Order order)
    {
        if (!await orderViewModel.UpdateOrder(id, order))
        {
            return NotFound();
        }
        return NoContent();
    }

    /// <summary>
    /// Deletes an order by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the order to delete.</param>
    /// <returns>No content.</returns>
    /// <response code="204">If the deletion was successful.</response>
    /// <response code="404">If the order is not found.</response>
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteOrder(Guid id)
    {
        if (!await orderViewModel.DeleteOrder(id))
        {
            return NotFound();
        }
        return NoContent();
    }

    /// <summary>
    /// Retrieves orders by the specified product identifier, filtered by the specified number of days in the past.
    /// </summary>
    /// <param name="productId">The unique identifier of the product.</param>
    /// <param name="orderDaysInPast">The number of days in the past to filter orders by.</param>
    /// <returns>A list of orders that match the filter.</returns>
    /// <response code="200">Returns the list of orders.</response>
    [HttpGet("ProductId/{productId:guid}")]
    public async Task<ActionResult<IEnumerable<Order>>> GetOrdersByProductId(Guid productId, [FromQuery] int orderDaysInPast = 0)
    {
        return await orderViewModel.GetOrdersByProductId(productId, orderDaysInPast);
    }

    /// <summary>
    /// Retrieves orders by the specified customer identifier, filtered by the specified number of days in the past.
    /// </summary>
    /// <param name="customerId">The unique identifier of the customer.</param>
    /// <param name="orderDaysInPast">The number of days in the past to filter orders by.</param>
    /// <returns>A list of orders that match the filter.</returns>
    /// <response code="200">Returns the list of orders.</response>
    [HttpGet("CustomerId/{customerId:guid}")]
    public async Task<ActionResult<IEnumerable<Order>>> GetOrdersByCustomerId(Guid customerId, [FromQuery] int orderDaysInPast = 0)
    {
        return await orderViewModel.GetOrdersByCustomerId(customerId, orderDaysInPast);
    }

    /// <summary>
    /// Retrieves orders by the specified employee identifier, filtered by the specified number of days in the past.
    /// </summary>
    /// <param name="employeeId">The unique identifier of the sales employee.</param>
    /// <param name="orderDaysInPast">The number of days in the past to filter orders by.</param>
    /// <returns>A list of orders that match the filter.</returns>
    /// <response code="200">Returns the list of orders.</response>
    [HttpGet("EmployeeId/{employeeId:guid}")]
    public async Task<ActionResult<IEnumerable<Order>>> GetOrdersByEmployeeId(Guid employeeId, [FromQuery] int orderDaysInPast = 0)
    {
        return await orderViewModel.GetOrdersByEmployeeId(employeeId, orderDaysInPast);
    }

    /// <summary>
    /// Retrieves orders by the specified quantity, filtered by the specified number of days in the past.
    /// </summary>
    /// <param name="quantity">The quantity of products in the order.</param>
    /// <param name="orderDaysInPast">The number of days in the past to filter orders by.</param>
    /// <returns>A list of orders that match the filter.</returns>
    /// <response code="200">Returns the list of orders.</response>
    [HttpGet("Quantity/{quantity:int?}")]
    public async Task<ActionResult<IEnumerable<Order>>> GetOrdersByQuantity(int? quantity, [FromQuery] int orderDaysInPast = 0)
    {
        return await orderViewModel.GetOrdersByQuantity(quantity, orderDaysInPast);
    }
}