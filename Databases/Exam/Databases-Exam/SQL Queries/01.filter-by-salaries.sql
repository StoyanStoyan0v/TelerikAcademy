USE Company

SELECT FirstName, LastName, YearSalary
FROM Employees
WHERE YearSalary BETWEEN 100000 AND 150000
ORDER BY YearSalary