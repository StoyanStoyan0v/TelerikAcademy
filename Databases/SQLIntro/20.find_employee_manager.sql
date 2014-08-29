SELECT e.FirstName + ' ' + e.LastName AS [Employee Full Name],
m.FirstName + ' ' + m.LastName AS [Manager Full Name]
FROM [TelerikAcademy].[dbo].[Employees] e
	INNER JOIN [TelerikAcademy].[dbo].[Employees] m
		ON e.ManagerID = m.EmployeeID
			

		
	
		