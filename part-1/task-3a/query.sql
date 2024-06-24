USE CapDB;

-- Simple 10% multiplier in a transaction with roll-back if it encounters any NULL values or errors.
BEGIN TRANSACTION;

UPDATE 
    Products
SET 
    price = price * 1.10
WHERE 
    category = 'Electronics';

COMMIT TRANSACTION;
