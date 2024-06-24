USE CapDB;

-- Simple query where after doing some of the later tasks, I assumed you would want to check for null and
-- not include those records.
SELECT 
    o.order_id,
    p.name AS product_name,
    c.name AS customer_name,
    s.name AS sales_employee_name,
    o.order_date
FROM 
    Orders o
JOIN 
    Products p ON o.product_id = p.product_id
JOIN 
    Customers c ON o.customer_id = c.customer_id
JOIN 
    SalesEmployees s ON o.employee_id = s.employee_id
WHERE 
    o.order_date >= DATEADD(day, -30, GETDATE())
    AND o.quantity IS NOT NULL
ORDER BY 
    o.order_date DESC;
