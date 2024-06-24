using CustomerManagementService.Models;

namespace CustomerManagementService.Data;
/// <summary>
/// Initializes the database with seed data.
/// </summary>
public static class DbInitializer
{
    /// <summary>
    /// Ensures the database is created and seeds initial data if the database is empty.
    /// </summary>
    /// <param name="context">The database context used to access the database.</param>
    public static void Initialize(CustomerContext context)
    {
        // Ensure database is created
        context.Database.EnsureCreated();

        // Check if the Products table has any data
        if (context.Products.Any())
        {
            return; // DB has been seeded
        }

        // Seed Customers
        Customer[] customers =
        [
            new Customer { CustomerId = Guid.NewGuid(), Name = "James Smith", Email = "james.smith@example.com", Region = "North" },
            new Customer { CustomerId = Guid.NewGuid(), Name = "Mary Johnson", Email = "mary.johnson@example.com", Region = "East" },
            new Customer { CustomerId = Guid.NewGuid(), Name = "John Williams", Email = "john.williams@example.com", Region = "South" },
            new Customer { CustomerId = Guid.NewGuid(), Name = "Patricia Brown", Email = "patricia.brown@example.com", Region = "West" },
            new Customer { CustomerId = Guid.NewGuid(), Name = "Robert Jones", Email = "robert.jones@example.com", Region = "North" },
            new Customer { CustomerId = Guid.NewGuid(), Name = "Jennifer Garcia", Email = "jennifer.garcia@example.com", Region = "East" },
            new Customer { CustomerId = Guid.NewGuid(), Name = "Michael Martinez", Email = "michael.martinez@example.com", Region = "South" },
            new Customer { CustomerId = Guid.NewGuid(), Name = "Linda Rodriguez", Email = "linda.rodriguez@example.com", Region = "West" },
            new Customer { CustomerId = Guid.NewGuid(), Name = "William Hernandez", Email = "william.hernandez@example.com", Region = "North" },
            new Customer { CustomerId = Guid.NewGuid(), Name = "Elizabeth Lopez", Email = "elizabeth.lopez@example.com", Region = "East" },
            new Customer { CustomerId = Guid.NewGuid(), Name = "David Gonzalez", Email = "david.gonzalez@example.com", Region = "South" },
            new Customer { CustomerId = Guid.NewGuid(), Name = "Barbara Wilson", Email = "barbara.wilson@example.com", Region = "West" },
            new Customer { CustomerId = Guid.NewGuid(), Name = "Joseph Anderson", Email = "joseph.anderson@example.com", Region = "North" },
            new Customer { CustomerId = Guid.NewGuid(), Name = "Susan Thomas", Email = "susan.thomas@example.com", Region = "East" },
            new Customer { CustomerId = Guid.NewGuid(), Name = "Charles Taylor", Email = "charles.taylor@example.com", Region = "South" }
        ];
        context.Customers.AddRange(customers);
        context.SaveChanges();

        // Seed Products
        Product[] products =
        [
            new Product { ProductId = Guid.NewGuid(), Name = "Laptop", Price = 999.99M, Category = "Electronics" },
            new Product { ProductId = Guid.NewGuid(), Name = "Phone", Price = 699.99M, Category = "Electronics" },
            new Product { ProductId = Guid.NewGuid(), Name = "Tablet", Price = 399.99M, Category = "Electronics" },
            new Product { ProductId = Guid.NewGuid(), Name = "Headphones", Price = 199.99M, Category = "Electronics" },
            new Product { ProductId = Guid.NewGuid(), Name = "Smartwatch", Price = 299.99M, Category = "Electronics" },
            new Product { ProductId = Guid.NewGuid(), Name = "Camera", Price = 499.99M, Category = "Electronics" },
            new Product { ProductId = Guid.NewGuid(), Name = "Monitor", Price = 249.99M, Category = "Electronics" },
            new Product { ProductId = Guid.NewGuid(), Name = "Shoes", Price = 49.99M, Category = "Apparel" },
            new Product { ProductId = Guid.NewGuid(), Name = "Shirt", Price = 19.99M, Category = "Apparel" },
            new Product { ProductId = Guid.NewGuid(), Name = "Jacket", Price = 79.99M, Category = "Apparel" },
            new Product { ProductId = Guid.NewGuid(), Name = "Jeans", Price = 39.99M, Category = "Apparel" },
            new Product { ProductId = Guid.NewGuid(), Name = "Hat", Price = 14.99M, Category = "Apparel" },
            new Product { ProductId = Guid.NewGuid(), Name = "Socks", Price = 9.99M, Category = "Apparel" },
            new Product { ProductId = Guid.NewGuid(), Name = "Belt", Price = 24.99M, Category = "Apparel" },
            new Product { ProductId = Guid.NewGuid(), Name = "Desk", Price = 150.00M, Category = "Furniture" },
            new Product { ProductId = Guid.NewGuid(), Name = "Chair", Price = 85.00M, Category = "Furniture" },
            new Product { ProductId = Guid.NewGuid(), Name = "Bookshelf", Price = 120.00M, Category = "Furniture" },
            new Product { ProductId = Guid.NewGuid(), Name = "Bed", Price = 300.00M, Category = "Furniture" },
            new Product { ProductId = Guid.NewGuid(), Name = "Couch", Price = 400.00M, Category = "Furniture" },
            new Product { ProductId = Guid.NewGuid(), Name = "Table", Price = 200.00M, Category = "Furniture" },
            new Product { ProductId = Guid.NewGuid(), Name = "Dresser", Price = 250.00M, Category = "Furniture" },
            new Product { ProductId = Guid.NewGuid(), Name = "Box", Price = 5.00M, Category = "Miscellaneous" }
        ];
        context.Products.AddRange(products);
        context.SaveChanges();

        // Seed SalesEmployees

        // These are just so I can add their managers since we are using guids/uuids for Ids instead of integers that would be more easily guessed.
        Guid guidManagerA = Guid.NewGuid();
        Guid guidManagerB = Guid.NewGuid();

        SalesEmployee[] employees =
        [
            new SalesEmployee { EmployeeId = guidManagerA, Name = "Manager A", Region = "North" },
            new SalesEmployee { EmployeeId = guidManagerB, Name = "Manager B", Region = "East" },
            new SalesEmployee { EmployeeId = Guid.NewGuid(), Name = "Employee 1", Region = "North", ManagerId = guidManagerA },
            new SalesEmployee { EmployeeId = Guid.NewGuid(), Name = "Employee 2", Region = "East", ManagerId = guidManagerB },
            new SalesEmployee { EmployeeId = Guid.NewGuid(), Name = "Employee 3", Region = "South", ManagerId = guidManagerA },
            new SalesEmployee { EmployeeId = Guid.NewGuid(), Name = "Employee 4", Region = "West", ManagerId = guidManagerB },
            new SalesEmployee { EmployeeId = Guid.NewGuid(), Name = "Employee 5", Region = "North", ManagerId = guidManagerA },
            new SalesEmployee { EmployeeId = Guid.NewGuid(), Name = "Employee 6", Region = "East", ManagerId = guidManagerB }
        ];
        context.SalesEmployees.AddRange(employees);
        context.SaveChanges();

        // Seed Orders
        Order[] orders =
        [
            new Order() { OrderId = Guid.NewGuid(), ProductId = products[0].ProductId, CustomerId = customers[0].CustomerId, EmployeeId = employees[2].EmployeeId, Quantity = 2, OrderDate = DateTime.Now }, // Laptop
            new Order() { OrderId = Guid.NewGuid(), ProductId = products[1].ProductId, CustomerId = customers[1].CustomerId, EmployeeId = employees[3].EmployeeId, Quantity = 1, OrderDate = DateTime.Now.AddDays(-15) }, // Phone
            new Order() { OrderId = Guid.NewGuid(), ProductId = products[2].ProductId, CustomerId = customers[2].CustomerId, EmployeeId = employees[4].EmployeeId, Quantity = 5, OrderDate = DateTime.Now.AddDays(-30) }, // Tablet
            new Order() { OrderId = Guid.NewGuid(), ProductId = products[3].ProductId, CustomerId = customers[3].CustomerId, EmployeeId = employees[5].EmployeeId, Quantity = 3, OrderDate = DateTime.Now.AddDays(-45) }, // Headphones
            new Order() { OrderId = Guid.NewGuid(), ProductId = products[1].ProductId, CustomerId = customers[8].CustomerId, EmployeeId = employees[0].EmployeeId, Quantity = 1, OrderDate = DateTime.Now.AddDays(-35) }, // Phone
            new Order() { OrderId = Guid.NewGuid(), ProductId = products[2].ProductId, CustomerId = customers[9].CustomerId, EmployeeId = employees[1].EmployeeId, Quantity = 3, OrderDate = DateTime.Now.AddDays(-50) }, // Tablet
            new Order() { OrderId = Guid.NewGuid(), ProductId = products[4].ProductId, CustomerId = customers[11].CustomerId, EmployeeId = employees[3].EmployeeId, Quantity = 1, OrderDate = DateTime.Now.AddDays(-80) }, // Smartwatch
            new Order() { OrderId = Guid.NewGuid(), ProductId = products[5].ProductId, CustomerId = customers[12].CustomerId, EmployeeId = employees[4].EmployeeId, Quantity = 3, OrderDate = DateTime.Now.AddDays(-95) }, // Camera

            // Apparel category
            new Order() { OrderId = Guid.NewGuid(), ProductId = products[7].ProductId, CustomerId = customers[0].CustomerId, EmployeeId = employees[2].EmployeeId, Quantity = 3, OrderDate = DateTime.Now }, // Shoes
            new Order() { OrderId = Guid.NewGuid(), ProductId = products[8].ProductId, CustomerId = customers[1].CustomerId, EmployeeId = employees[3].EmployeeId, Quantity = 2, OrderDate = DateTime.Now.AddDays(-15) }, // Shirt
            new Order() { OrderId = Guid.NewGuid(), ProductId = products[7].ProductId, CustomerId = customers[0].CustomerId, EmployeeId = employees[2].EmployeeId, Quantity = null, OrderDate = DateTime.Now.AddDays(-30) }, // Shoes
            new Order() { OrderId = Guid.NewGuid(), ProductId = products[8].ProductId, CustomerId = customers[1].CustomerId, EmployeeId = employees[3].EmployeeId, Quantity = null, OrderDate = DateTime.Now.AddDays(-60) }, // Shirt
            new Order() { OrderId = Guid.NewGuid(), ProductId = products[9].ProductId, CustomerId = customers[2].CustomerId, EmployeeId = employees[4].EmployeeId, Quantity = null, OrderDate = DateTime.Now.AddDays(-90) }, // Jacket
            new Order() { OrderId = Guid.NewGuid(), ProductId = products[10].ProductId, CustomerId = customers[3].CustomerId, EmployeeId = employees[5].EmployeeId, Quantity = null, OrderDate = DateTime.Now.AddDays(-120) }, // Jeans
            new Order() { OrderId = Guid.NewGuid(), ProductId = products[13].ProductId, CustomerId = customers[13].CustomerId, EmployeeId = employees[5].EmployeeId, Quantity = 2, OrderDate = DateTime.Now.AddDays(-10) }, // Belt

            // Furniture category
            new Order() { OrderId = Guid.NewGuid(), ProductId = products[14].ProductId, CustomerId = customers[0].CustomerId, EmployeeId = employees[2].EmployeeId, Quantity = 2, OrderDate = DateTime.Now }, // Desk
            new Order() { OrderId = Guid.NewGuid(), ProductId = products[15].ProductId, CustomerId = customers[1].CustomerId, EmployeeId = employees[3].EmployeeId, Quantity = 3, OrderDate = DateTime.Now.AddDays(-15) }, // Chair
            new Order() { OrderId = Guid.NewGuid(), ProductId = products[16].ProductId, CustomerId = customers[2].CustomerId, EmployeeId = employees[4].EmployeeId, Quantity = 2, OrderDate = DateTime.Now.AddDays(-30) }, // Bookshelf
            new Order() { OrderId = Guid.NewGuid(), ProductId = products[17].ProductId, CustomerId = customers[3].CustomerId, EmployeeId = employees[5].EmployeeId, Quantity = 1, OrderDate = DateTime.Now.AddDays(-45) }, // Bed
            new Order() { OrderId = Guid.NewGuid(), ProductId = products[18].ProductId, CustomerId = customers[4].CustomerId, EmployeeId = employees[2].EmployeeId, Quantity = 2, OrderDate = DateTime.Now.AddDays(-60) }, // Couch
            new Order() { OrderId = Guid.NewGuid(), ProductId = products[18].ProductId, CustomerId = customers[11].CustomerId, EmployeeId = employees[3].EmployeeId, Quantity = 2, OrderDate = DateTime.Now.AddDays(-80) }, // Couch
            new Order() { OrderId = Guid.NewGuid(), ProductId = products[19].ProductId, CustomerId = customers[12].CustomerId, EmployeeId = employees[4].EmployeeId, Quantity = 1, OrderDate = DateTime.Now.AddDays(-95) }, // Table
            new Order() { OrderId = Guid.NewGuid(), ProductId = products[14].ProductId, CustomerId = customers[0].CustomerId, EmployeeId = employees[2].EmployeeId, Quantity = null, OrderDate = DateTime.Now.AddDays(-30) }, // Desk
            new Order() { OrderId = Guid.NewGuid(), ProductId = products[15].ProductId, CustomerId = customers[1].CustomerId, EmployeeId = employees[3].EmployeeId, Quantity = null, OrderDate = DateTime.Now.AddDays(-60) }, // Chair

            // Miscellaneous category
            new Order() { OrderId = Guid.NewGuid(), ProductId = products[21].ProductId, CustomerId = customers[0].CustomerId, EmployeeId = employees[2].EmployeeId, Quantity = 3, OrderDate = DateTime.Now }, // Box
            new Order() { OrderId = Guid.NewGuid(), ProductId = products[21].ProductId, CustomerId = customers[0].CustomerId, EmployeeId = employees[2].EmployeeId, Quantity = 3, OrderDate = DateTime.Now.AddDays(-30) }, // Box
            new Order() { OrderId = Guid.NewGuid(), ProductId = products[21].ProductId, CustomerId = customers[1].CustomerId, EmployeeId = employees[3].EmployeeId, Quantity = 2, OrderDate = DateTime.Now.AddDays(-15) }, // Box
            new Order() { OrderId = Guid.NewGuid(), ProductId = products[21].ProductId, CustomerId = customers[2].CustomerId, EmployeeId = employees[4].EmployeeId, Quantity = 1, OrderDate = DateTime.Now.AddDays(-10) } // Box
        ];
        context.Orders.AddRange(orders);
        context.SaveChanges();

        // Seed SalesCache
        SalesCache[] salesCaches =
        [
            new SalesCache() { Category = "Category A", Year = 2021, TotalSales = 2341 },
            new SalesCache() { Category = "Category A", Year = 2022, TotalSales = 2032 },
            new SalesCache() { Category = "Category A", Year = 2023, TotalSales = 2561 },
            new SalesCache() { Category = "Category B", Year = 2021, TotalSales = 4123 },
            new SalesCache() { Category = "Category B", Year = 2022, TotalSales = 3254 },
            new SalesCache() { Category = "Category B", Year = 2023, TotalSales = 3865 }
        ];
        context.SalesCaches.AddRange(salesCaches);
        context.SaveChanges();
    }
}