USE CapDB;

-- Create Customers table
CREATE TABLE Customers (
    customer_id INT PRIMARY KEY IDENTITY(1,1),
    name NVARCHAR(100),
    email NVARCHAR(100),
    region NVARCHAR(50)
);

-- Create Products table
CREATE TABLE Products (
    product_id INT PRIMARY KEY IDENTITY(1,1),
    name NVARCHAR(100),
    price DECIMAL(10, 2),
    category NVARCHAR(50)
);

-- Create SalesEmployees table
CREATE TABLE SalesEmployees (
    employee_id INT PRIMARY KEY IDENTITY(1,1),
    name NVARCHAR(100),
    region NVARCHAR(50),
    manager_id INT NULL
);

-- Create Orders table
CREATE TABLE Orders (
    order_id INT PRIMARY KEY IDENTITY(1,1),
    product_id INT,
    customer_id INT,
    employee_id INT,
    quantity INT,
    order_date DATE,
    FOREIGN KEY (product_id) REFERENCES Products(product_id),
    FOREIGN KEY (customer_id) REFERENCES Customers(customer_id),
    FOREIGN KEY (employee_id) REFERENCES SalesEmployees(employee_id)
);

-- Create SalesCache table
CREATE TABLE SalesCache (
    category NVARCHAR(50),
    year INT,
    totalSales DECIMAL(10, 2)
);

GO

-- Create Stored Procedure sp_CancelOrder
CREATE PROCEDURE sp_CancelOrder
    @order_id INT
AS
BEGIN
    DELETE FROM Orders
    WHERE order_id = @order_id
    AND order_date < DATEADD(day, -90, GETDATE())
    AND quantity IS NULL;
END;

GO
