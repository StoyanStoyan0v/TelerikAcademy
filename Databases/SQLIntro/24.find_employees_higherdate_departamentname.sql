--Right Join
SELECT e.FirstName + ' ' + e.LastName AS [Employee Full Name],
e.HireDate, d.Name AS [Departament Name]
FROM [TelerikAcademy].[dbo].[Employees] e
	INNER JOIN [TelerikAcademy].[dbo].Departments d
		ON e.DepartmentID = d.DepartmentID
			WHERE d.Name IN ('Sales','Finance') AND YEAR(e.HireDate) BETWEEN 1995 AND 2005
			

			

		
	
		