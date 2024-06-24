USE CapDB;

-- This is the cleanest way I could think to do this. To test it, I also created the stored procedure
-- which can be found in the create-schema.sql file and using the seed data, does remove >90 day null records.
DECLARE @order_id INT;

DECLARE order_cursor CURSOR FOR
SELECT 
    order_id
FROM 
    Orders
WHERE 
    order_date < DATEADD(day, -90, GETDATE()) AND quantity IS NULL;

OPEN order_cursor;
FETCH NEXT FROM order_cursor INTO @order_id;

WHILE @@FETCH_STATUS = 0
BEGIN
    EXEC sp_CancelOrder @order_id = @order_id;
    FETCH NEXT FROM order_cursor INTO @order_id;
END;

CLOSE order_cursor;
DEALLOCATE order_cursor;
