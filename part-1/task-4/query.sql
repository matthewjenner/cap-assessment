USE CapDB;

-- Simple select and join query using the HAVING keyword (MS SQL 2014+ I believe) for filtering
SELECT 
    p.name AS product_name,
    COUNT(o.order_id) AS number_of_orders
FROM 
    Orders o
JOIN 
    Products p ON o.product_id = p.product_id
WHERE 
    p.name != 'Box'
    AND o.quantity IS NOT NULL
GROUP BY 
    p.name
HAVING 
    COUNT(o.order_id) > 2;