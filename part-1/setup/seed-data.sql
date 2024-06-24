USE CapDB;

-- Insert sample data into Customers
INSERT INTO Customers (name, email, region)
VALUES 
('James Smith', 'james.smith@example.com', 'North'),
('Mary Johnson', 'mary.johnson@example.com', 'East'),
('John Williams', 'john.williams@example.com', 'South'),
('Patricia Brown', 'patricia.brown@example.com', 'West'),
('Robert Jones', 'robert.jones@example.com', 'North'),
('Jennifer Garcia', 'jennifer.garcia@example.com', 'East'),
('Michael Martinez', 'michael.martinez@example.com', 'South'),
('Linda Rodriguez', 'linda.rodriguez@example.com', 'West'),
('William Hernandez', 'william.hernandez@example.com', 'North'),
('Elizabeth Lopez', 'elizabeth.lopez@example.com', 'East'),
('David Gonzalez', 'david.gonzalez@example.com', 'South'),
('Barbara Wilson', 'barbara.wilson@example.com', 'West'),
('Joseph Anderson', 'joseph.anderson@example.com', 'North'),
('Susan Thomas', 'susan.thomas@example.com', 'East'),
('Charles Taylor', 'charles.taylor@example.com', 'South');

-- Insert sample data into Products
INSERT INTO Products (name, price, category)
VALUES 
('Laptop', 999.99, 'Electronics'),
('Phone', 699.99, 'Electronics'),
('Tablet', 399.99, 'Electronics'),
('Headphones', 199.99, 'Electronics'),
('Smartwatch', 299.99, 'Electronics'),
('Camera', 499.99, 'Electronics'),
('Monitor', 249.99, 'Electronics'),
('Shoes', 49.99, 'Apparel'),
('Shirt', 19.99, 'Apparel'),
('Jacket', 79.99, 'Apparel'),
('Jeans', 39.99, 'Apparel'),
('Hat', 14.99, 'Apparel'),
('Socks', 9.99, 'Apparel'),
('Belt', 24.99, 'Apparel'),
('Desk', 150.00, 'Furniture'),
('Chair', 85.00, 'Furniture'),
('Bookshelf', 120.00, 'Furniture'),
('Bed', 300.00, 'Furniture'),
('Couch', 400.00, 'Furniture'),
('Table', 200.00, 'Furniture'),
('Dresser', 250.00, 'Furniture'),
('Box', 5.00, 'Miscellaneous');

-- Insert sample data into SalesEmployees
INSERT INTO SalesEmployees (name, region, manager_id)
VALUES 
('Manager A', 'North', NULL),
('Manager B', 'East', NULL),
('Employee 1', 'North', 1),
('Employee 2', 'East', 2),
('Employee 3', 'South', 1),
('Employee 4', 'West', 2),
('Employee 5', 'North', 1),
('Employee 6', 'East', 2);

-- Insert sample data into Orders
INSERT INTO Orders (product_id, customer_id, employee_id, quantity, order_date)
VALUES 
-- Electronics category
(1, 1, 3, 2, GETDATE()), -- Laptop
(2, 2, 4, 1, DATEADD(day, -15, GETDATE())), -- Phone
(3, 3, 5, 5, DATEADD(day, -30, GETDATE())), -- Tablet
(4, 4, 6, 3, DATEADD(day, -45, GETDATE())), -- Headphones
(5, 5, 3, 4, DATEADD(day, -60, GETDATE())), -- Smartwatch
(6, 6, 4, 2, DATEADD(day, -75, GETDATE())), -- Camera
(7, 7, 5, 1, DATEADD(day, -90, GETDATE())), -- Monitor
(1, 8, 6, 2, DATEADD(day, -20, GETDATE())), -- Laptop
(1, 1, 3, NULL, DATEADD(day, -30, GETDATE())), -- Laptop
(2, 2, 4, NULL, DATEADD(day, -60, GETDATE())), -- Phone
(3, 3, 5, NULL, DATEADD(day, -90, GETDATE())), -- Tablet
(4, 4, 6, NULL, DATEADD(day, -120, GETDATE())), -- Headphones
(5, 5, 3, NULL, DATEADD(day, -30, GETDATE())), -- Smartwatch
(6, 6, 4, NULL, DATEADD(day, -60, GETDATE())), -- Camera
(7, 7, 5, NULL, DATEADD(day, -90, GETDATE())), -- Monitor
(2, 9, 1, 1, DATEADD(day, -35, GETDATE())), -- Phone
(3, 10, 2, 3, DATEADD(day, -50, GETDATE())), -- Tablet
(4, 11, 3, 2, DATEADD(day, -65, GETDATE())), -- Headphones
(5, 12, 4, 1, DATEADD(day, -80, GETDATE())), -- Smartwatch
(6, 13, 5, 3, DATEADD(day, -95, GETDATE())), -- Camera
(7, 14, 6, 2, DATEADD(day, -10, GETDATE())), -- Monitor
(1, 1, 3, 2, DATEADD(day, -70, GETDATE())), -- Laptop
(2, 2, 4, 1, DATEADD(day, -85, GETDATE())), -- Phone
(3, 3, 5, 5, DATEADD(day, -55, GETDATE())), -- Tablet
(4, 4, 6, 3, DATEADD(day, -40, GETDATE())), -- Headphones
(6, 6, 4, 2, DATEADD(day, -10, GETDATE())), -- Camera
(7, 7, 5, 1, DATEADD(day, -90, GETDATE())), -- Monitor
(1, 8, 6, 2, DATEADD(day, -20, GETDATE())), -- Laptop
(2, 9, 1, 1, DATEADD(day, -35, GETDATE())), -- Phone
(3, 10, 2, 3, DATEADD(day, -50, GETDATE())), -- Tablet
(5, 12, 4, 1, DATEADD(day, -80, GETDATE())), -- Smartwatch
(6, 13, 5, 3, DATEADD(day, -95, GETDATE())), -- Camera

-- Apparel category
(8, 1, 3, 3, GETDATE()), -- Shoes
(9, 2, 4, 2, DATEADD(day, -15, GETDATE())), -- Shirt
(10, 3, 5, 2, DATEADD(day, -30, GETDATE())), -- Jacket
(11, 4, 6, 1, DATEADD(day, -45, GETDATE())), -- Jeans
(12, 5, 3, 3, DATEADD(day, -60, GETDATE())), -- Hat
(13, 6, 4, 2, DATEADD(day, -75, GETDATE())), -- Socks
(14, 7, 5, 1, DATEADD(day, -90, GETDATE())), -- Belt
(8, 8, 6, 3, DATEADD(day, -20, GETDATE())), -- Shoes
(9, 9, 1, 2, DATEADD(day, -35, GETDATE())), -- Shirt
(10, 10, 2, 1, DATEADD(day, -50, GETDATE())), -- Jacket
(11, 11, 3, 2, DATEADD(day, -65, GETDATE())), -- Jeans
(12, 12, 4, 1, DATEADD(day, -80, GETDATE())), -- Hat
(8, 1, 3, NULL, DATEADD(day, -30, GETDATE())), -- Shoes
(9, 2, 4, NULL, DATEADD(day, -60, GETDATE())), -- Shirt
(10, 3, 5, NULL, DATEADD(day, -90, GETDATE())), -- Jacket
(11, 4, 6, NULL, DATEADD(day, -120, GETDATE())), -- Jeans
(12, 5, 3, NULL, DATEADD(day, -30, GETDATE())), -- Hat
(13, 6, 4, NULL, DATEADD(day, -60, GETDATE())), -- Socks
(14, 7, 5, NULL, DATEADD(day, -90, GETDATE())), -- Belt
(13, 13, 5, 3, DATEADD(day, -95, GETDATE())), -- Socks
(14, 14, 6, 2, DATEADD(day, -10, GETDATE())), -- Belt
(8, 1, 3, 3, DATEADD(day, -90, GETDATE())), -- Shoes
(9, 2, 4, 2, DATEADD(day, -75, GETDATE())), -- Shirt
(10, 3, 5, 2, DATEADD(day, -60, GETDATE())), -- Jacket
(11, 4, 6, 1, DATEADD(day, -45, GETDATE())), -- Jeans
(12, 5, 3, 3, DATEADD(day, -30, GETDATE())), -- Hat
(14, 7, 5, 1, DATEADD(day, -10, GETDATE())), -- Belt
(8, 8, 6, 3, DATEADD(day, -20, GETDATE())), -- Shoes
(9, 9, 1, 2, DATEADD(day, -35, GETDATE())), -- Shirt
(11, 11, 3, 2, DATEADD(day, -65, GETDATE())), -- Jeans
(12, 12, 4, 1, DATEADD(day, -80, GETDATE())), -- Hat
(13, 13, 5, 3, DATEADD(day, -95, GETDATE())), -- Socks
(14, 14, 6, 2, DATEADD(day, -10, GETDATE())), -- Belt

-- Furniture category
(15, 1, 3, 2, GETDATE()), -- Desk
(16, 2, 4, 3, DATEADD(day, -15, GETDATE())), -- Chair
(17, 3, 5, 2, DATEADD(day, -30, GETDATE())), -- Bookshelf
(18, 4, 6, 1, DATEADD(day, -45, GETDATE())), -- Bed
(19, 5, 3, 2, DATEADD(day, -60, GETDATE())), -- Couch
(20, 6, 4, 3, DATEADD(day, -75, GETDATE())), -- Table
(21, 7, 5, 2, DATEADD(day, -90, GETDATE())), -- Dresser
(15, 8, 6, 3, DATEADD(day, -20, GETDATE())), -- Desk
(16, 9, 1, 2, DATEADD(day, -35, GETDATE())), -- Chair
(17, 10, 2, 1, DATEADD(day, -50, GETDATE())), -- Bookshelf
(18, 11, 3, 3, DATEADD(day, -65, GETDATE())), -- Bed
(19, 12, 4, 2, DATEADD(day, -80, GETDATE())), -- Couch
(20, 13, 5, 1, DATEADD(day, -95, GETDATE())), -- Table
(15, 1, 3, NULL, DATEADD(day, -30, GETDATE())), -- Desk
(16, 2, 4, NULL, DATEADD(day, -60, GETDATE())), -- Chair
(17, 3, 5, NULL, DATEADD(day, -90, GETDATE())), -- Bookshelf
(18, 4, 6, NULL, DATEADD(day, -120, GETDATE())), -- Bed
(19, 5, 3, NULL, DATEADD(day, -30, GETDATE())), -- Couch
(20, 6, 4, NULL, DATEADD(day, -60, GETDATE())), -- Table
(21, 7, 5, NULL, DATEADD(day, -90, GETDATE())), -- Dresser
(21, 14, 6, 2, DATEADD(day, -10, GETDATE())), -- Dresser
(15, 1, 3, 2, DATEADD(day, -90, GETDATE())), -- Desk
(16, 2, 4, 3, DATEADD(day, -75, GETDATE())), -- Chair
(19, 5, 3, 2, DATEADD(day, -30, GETDATE())), -- Couch
(20, 6, 4, 3, DATEADD(day, -15, GETDATE())), -- Table
(21, 7, 5, 2, DATEADD(day, -10, GETDATE())), -- Dresser
(15, 8, 6, 3, DATEADD(day, -20, GETDATE())), -- Desk
(16, 9, 1, 2, DATEADD(day, -35, GETDATE())), -- Chair
(18, 11, 3, 3, DATEADD(day, -65, GETDATE())), -- Bed
(19, 12, 4, 2, DATEADD(day, -80, GETDATE())), -- Couch
(21, 14, 6, 2, DATEADD(day, -10, GETDATE())), -- Dresser

-- Miscellaneous category
(22, 1, 3, 3, GETDATE()), -- Box
(22, 2, 4, 2, DATEADD(day, -30, GETDATE())), -- Box
(22, 3, 5, 1, DATEADD(day, -60, GETDATE())), -- Box
(22, 4, 6, 3, DATEADD(day, -90, GETDATE())), -- Box
(22, 1, 3, 3, DATEADD(day, -90, GETDATE())), -- Box
(22, 2, 4, 2, DATEADD(day, -75, GETDATE())), -- Box
(22, 3, 5, 1, DATEADD(day, -60, GETDATE())), -- Box
(22, 4, 6, 3, DATEADD(day, -45, GETDATE())), -- Box
(22, 1, 3, NULL, DATEADD(day, -30, GETDATE())), -- Box
(22, 2, 4, NULL, DATEADD(day, -60, GETDATE())), -- Box
(22, 3, 5, NULL, DATEADD(day, -90, GETDATE())), -- Box
(22, 4, 6, NULL, DATEADD(day, -120, GETDATE())), -- Box
(22, 1, 3, 3, DATEADD(day, -30, GETDATE())), -- Box
(22, 2, 4, 2, DATEADD(day, -15, GETDATE())), -- Box
(22, 3, 5, 1, DATEADD(day, -10, GETDATE())); -- Box

-- Insert sample data into SalesCache
INSERT INTO SalesCache (category, year, totalSales)
VALUES 
('Category A', 2021, 2341),
('Category A', 2022, 2032),
('Category A', 2023, 2561),
('Category B', 2021, 4123),
('Category B', 2022, 3254),
('Category B', 2023, 3865);
