--Right Join
SELECT e.FirstName + ' ' + e.LastName AS [Employee Full Name],
m.FirstName + ' ' + m.LastName AS [Manager Full Name]
FROM [TelerikAcademy].[dbo].[Employees] m
	RIGHT JOIN [TelerikAcademy].[dbo].[Employees] e
		ON e.ManagerID = m.EmployeeID

--Left Join
SELECT e.FirstName + ' ' + e.LastName AS [Employee Full Name],
m.FirstName + ' ' + m.LastName AS [Manager Full Name]
FROM [TelerikAcademy].[dbo].[Employees] e
	LEFT JOIN [TelerikAcademy].[dbo].[Employees] m
		ON e.ManagerID = m.EmployeeID
			

		
	
		