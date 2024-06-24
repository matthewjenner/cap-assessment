USE CapDB;

-- Since LIMIT is not valid in MS SQL, TOP should be used as long as it is ordered appropriately.
SELECT TOP 5
    name,
    price
FROM 
    Products
WHERE 
    category = 'Electronics'
ORDER BY 
    price DESC;
