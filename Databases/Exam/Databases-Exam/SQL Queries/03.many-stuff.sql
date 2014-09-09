USE Company

SELECT e.FirstName + ' ' +e.LastName AS [Emp. Full Name], 
	p.ProjectName, d.DepartmentName,
	p.StartingDate,p.EndingDate,q.[Projects in this time range]
FROM Employees e
JOIN Employees_Projects ep
	ON e.Id = ep.EmployeeId
JOIN Projects p
	ON ep.ProjectId = p.Id 
JOIN Departments d
	ON d.Id = e.DepartmentId
JOIN (SELECT p.StartingDate, p.EndingDate,
	COUNT(*) AS[Projects in this time range]
FROM Employees e
JOIN Employees_Projects ep
	ON e.Id = ep.EmployeeId
JOIN Projects p
	ON ep.ProjectId = p.Id 
JOIN Departments d
	ON d.Id=e.DepartmentId
GROUP BY p.EndingDate,p.StartingDate) q
	ON q.EndingDate = p.EndingDate
WHERE q.EndingDate=p.EndingDate
ORDER BY e.Id, p.Id




	