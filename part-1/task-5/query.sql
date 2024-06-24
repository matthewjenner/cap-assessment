USE CapDB;

-- Easiest way without a cursor was to do a nested select and increment a placeholder. If any real metadata
-- would be needed in addition to a count, this method may not be the best as it is a bit fragile.
WITH EmployeeHierarchy AS (
    SELECT 
        employee_id,
        manager_id,
        1 AS level
    FROM 
        SalesEmployees
    WHERE 
        manager_id IS NOT NULL
    UNION ALL
    SELECT 
        e.employee_id,
        e.manager_id,
        eh.level + 1
    FROM 
        SalesEmployees e
    JOIN 
        EmployeeHierarchy eh ON e.manager_id = eh.employee_id
)
SELECT 
    e.manager_id AS top_level_manager_id,
    COUNT(DISTINCT e.employee_id) AS total_employees
FROM 
    EmployeeHierarchy e
JOIN 
    SalesEmployees m ON e.manager_id = m.employee_id
WHERE 
    m.manager_id IS NULL
GROUP BY 
    e.manager_id
HAVING 
    COUNT(DISTINCT e.employee_id) > 0;
