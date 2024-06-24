USE CapDB;

-- Simple query where after doing some of the later tasks, I assumed you would want to check for null and
-- not include those records.
SELECT 
    p.category,
    SUM(p.price * o.quantity) AS total_sales
FROM 
    Orders o
JOIN 
    Products p ON o.product_id = p.product_id
WHERE 
    o.order_date >= DATEADD(month, -1, GETDATE())
    AND o.quantity IS NOT NULL
GROUP BY 
    p.category
ORDER BY 
    total_sales DESC;
