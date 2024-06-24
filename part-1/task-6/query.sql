USE CapDB;

-- This query is a little different than the others because it used sample records from
-- the assessment that didn't really jive with what I had been working with so far,
-- so I hope I didn't miss something by using the example literally.
SELECT 
    category,
    MAX(CASE WHEN year = 2021 THEN totalSales ELSE 0 END) AS 'Year 1',
    MAX(CASE WHEN year = 2022 THEN totalSales ELSE 0 END) AS 'Year 2',
    MAX(CASE WHEN year = 2023 THEN totalSales ELSE 0 END) AS 'Year 3'
FROM 
    SalesCache
GROUP BY 
    category;
