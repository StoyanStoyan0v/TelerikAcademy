USE Company
SELECT d.DepartmentName, COUNT(*) AS [Employees Count]
FROM Departments d
	JOIN Employees e
	ON e.DepartmentId = d.Id
GROUP BY d.DepartmentName
ORDER BY [Employees Count]