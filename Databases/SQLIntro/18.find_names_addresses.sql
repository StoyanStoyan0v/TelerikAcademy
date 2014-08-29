SELECT e.FirstName + ' ' + e.LastName AS [Full Name], a.AddressText
FROM [TelerikAcademy].[dbo].[Employees] e
	INNER JOIN [TelerikAcademy].[dbo].[Addresses] a
	ON e.AddressID = a.AddressID
		