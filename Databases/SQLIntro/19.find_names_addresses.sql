SELECT e.FirstName + ' ' + e.LastName AS [Full Name], a.AddressText
FROM [TelerikAcademy].[dbo].[Employees] e, [TelerikAcademy].[dbo].[Addresses] a
WHERE e.AddressID = a.AddressID
	
		