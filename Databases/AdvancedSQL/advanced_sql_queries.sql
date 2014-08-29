/* 01. Write a SQL query to find the names and salaries of the employees that take 
       the minimal salary in the company. Use a nested SELECT statement.
*/
SELECT FirstName + ' ' + LastName AS [Full Name], Salary
FROM [TelerikAcademy].[dbo].[Employees]
WHERE Salary =
	(SELECT MIN(Salary) FROM [TelerikAcademy].[dbo].[Employees])

/* 02. Write a SQL query to find the names and salaries of the employees that have 
	   a salary that is up to 10% higher than the minimal salary for the company.
*/
SELECT FirstName + ' ' + LastName AS [Full Name], Salary
FROM [TelerikAcademy].[dbo].[Employees]
WHERE Salary <=
	(SELECT MIN(Salary)*1.1 FROM [TelerikAcademy].[dbo].[Employees])

/* 03. Write a SQL query to find the full name, salary and department of the employees 
	   that take the minimal salary in their department. Use a nested SELECT statement.
*/
SELECT e.FirstName + ' ' + e.LastName AS [Full Name], e.Salary, d.Name 
FROM [TelerikAcademy].[dbo].[Employees] e
	INNER JOIN [TelerikAcademy].[dbo].[Departments] d
	ON e.DepartmentID = d.DepartmentID
WHERE Salary =
	(SELECT MIN(Salary) FROM [TelerikAcademy].[dbo].[Employees] m
	WHERE m.DepartmentID = d.DepartmentID)

--04.Write a SQL query to find the average salary in the department #1.
SELECT AVG(Salary) AS [Avarage Salary in Departament #1]
FROM [TelerikAcademy].[dbo].[Employees]
WHERE DepartmentID = 1

--05.WrWrite a SQL query to find the average salary  in the "Sales" department.
SELECT AVG(Salary) AS [Avarage Salary in Sales Departament]
FROM [TelerikAcademy].[dbo].[Employees] e
	INNER JOIN [TelerikAcademy].[dbo].[Departments] d
		ON e.DepartmentID = d.DepartmentID
WHERE d.Name = 'Sales'

--06.Write a SQL query to find the number of employees in the "Sales" department.
SELECT COUNT(e.EmployeeID) AS [Count of employees in Sales departament]
FROM [TelerikAcademy].[dbo].[Employees] e
	INNER JOIN [TelerikAcademy].[dbo].[Departments] d
		ON e.DepartmentID = d.DepartmentID
WHERE d.Name = 'Sales'

--07.Write a SQL query to find the number of all employees that have manager.
SELECT COUNT(EmployeeID) AS [Employees with manager]
FROM [TelerikAcademy].[dbo].[Employees] 
WHERE ManagerID IS NOT NULL

--08.Write a SQL query to find the number of all employees that have no manager.
SELECT COUNT(EmployeeID) AS [Employees with no manager]
FROM [TelerikAcademy].[dbo].[Employees] 
WHERE ManagerID IS NULL

--09.Write a SQL query to find all departments and the average salary for each of them.
SELECT d.Name AS [Departament Name], AVG(e.Salary) AS [Avarage Departament Salary]
FROM [TelerikAcademy].[dbo].[Employees] e
	INNER JOIN [TelerikAcademy].[dbo].[Departments] d
		ON e.DepartmentID = d.DepartmentID
GROUP BY d.Name

--10.Write a SQL query to find the count of all employees in each department and for each town.
SELECT d.Name AS [Departament Name],t.Name as[Town Name], COUNT(e.EmployeeID) AS [Count of Employees]
FROM [TelerikAcademy].[dbo].[Employees] e
	INNER JOIN [TelerikAcademy].[dbo].[Departments] d
		ON e.DepartmentID = d.DepartmentID
	INNER JOIN [TelerikAcademy].[dbo].[Addresses] a
		ON e.AddressID = a.AddressID
	INNER JOIN [TelerikAcademy].[dbo].[Towns] t
		ON a.TownID = t.TownID
GROUP BY d.Name,t.Name
ORDER BY d.Name

/*11.Write a SQL query to find all managers that have exactly 5 employees. 
	 Display their first name and last name.
*/
SELECT m.FirstName + ' ' + m.LastName, COUNT(*) AS [Employees Count]
FROM [TelerikAcademy].[dbo].[Employees] m
	INNER JOIN [TelerikAcademy].[dbo].[Employees] e
		ON m.EmployeeID = e.ManagerID
GROUP BY m.FirstName + ' ' + m.LastName
HAVING COUNT(*) = 5

/*12.Write a SQL query to find all employees along with their managers.
 For employees that do not have manager display the value "(no manager)".
 */
SELECT e.FirstName + ' ' + e.LastName, ISNULL(m.FirstName + ' ' + m.LastName,'No manager')
FROM [TelerikAcademy].[dbo].[Employees] e
	LEFT JOIN [TelerikAcademy].[dbo].[Employees] m
		ON e.ManagerID = m.EmployeeID
ORDER BY e.LastName

/*13.Write a SQL query to find the names of all employees whose last 
	 name is exactly 5 characters long. Use the built-in LEN(str) function.
*/
SELECT  FirstName + ' ' + LastName, LEN(LastName) AS [Last Name Length]
FROM [TelerikAcademy].[dbo].[Employees] 
WHERE LEN(LastName) = 5

/*14.Write a SQL query to display the current date and time in the following 
	 format "day.month.year hour:minutes:seconds:milliseconds". Search in  Google to find
	 how to format dates in SQL Server.
*/
SELECT CONVERT(varchar(16),GETDATE(),104) + ' ' + CONVERT(varchar(16),GETDATE(),114) AS [Current Time];

/* 15. Write a SQL statement to create a table Users. Users should have username, password,
   full name and last login time. Choose appropriate data types for the table fields. 
   Define a primary key column with a primary key constraint. Define the primary key column 
   as identity to facilitate inserting records. Define unique constraint to avoid repeating usernames. 
   Define a check constraint to ensure the password is at least 5 characters long.
*/
USE TelerikAcademy
CREATE TABLE Users(
	UserId int IDENTITY,
	Username nvarchar(20) NOT NULL,
	Pass nvarchar(20) NOT NULL,
	FullName nvarchar(50) NOT NULL,	
	CONSTRAINT PK_Users PRIMARY KEY(UserId),
	CONSTRAINT UN_Users UNIQUE(Username),
	CONSTRAINT CHECK_Pass CHECK(LEN(Pass)>=5)
)

ALTER TABLE Users ADD LastLoginTime datetime

INSERT INTO Users(Username,Pass,FullName,LastLoginTime)
VALUES('pesho','12345','Pesho Georgiev', GETDATE());
INSERT INTO Users(Username,Pass,FullName,LastLoginTime)
VALUES('ivan','12345','Ivan Georgiev', GETDATE());
INSERT INTO Users(Username,Pass,FullName,LastLoginTime)
VALUES('stamat','12345','Stamat Georgiev', GETDATE());
GO

/*16. Write a SQL statement to create a view that displays the users from the Users
    table that have been in the system today. Test if the view works correctly.
*/
CREATE VIEW [Get Users] AS
SELECT TOP 10 * FROM Users
WHERE Convert(varchar(20),LastLoginTime,112) = Convert(varchar(20),GETDATE(),112)
GO
/*17.Write a SQL statement to create a table Groups. Groups should have unique
	  name (use unique constraint). Define primary key and identity column.
*/

USE TelerikAcademy
CREATE TABLE Groups(
	GroupId int IDENTITY,
	GroupName nvarchar(20) NOT NULL,		
	CONSTRAINT PK_GroupID PRIMARY KEY(GroupId),
	CONSTRAINT UN_GroupName UNIQUE(GroupName),
)
GO
/*18.Write a SQL statement to add a column GroupID to the table Users. Fill some data 
	 in this new column and as well in the Groups table. Write a SQL statement to add a 
	 foreign key constraint between tables Users and Groups tables.
*/

ALTER TABLE Users ADD GroupID int
GO

ALTER TABLE Users
ADD FOREIGN KEY (GroupID)
REFERENCES Groups(GroupId)
GO

INSERT INTO Groups(GroupName)
VALUES('Mysteries');
INSERT INTO Groups(GroupName)
VALUES('Security');
GO

UPDATE Users
SET GroupID = 1
WHERE UserId =1;
UPDATE Users
SET GroupID = 1
WHERE UserId =2;
UPDATE Users
SET GroupID = 2
WHERE UserId =3;
GO

--19. Write SQL statements to insert several records in the Users and Groups tables.
INSERT INTO Groups(GroupName)
VALUES('Special Things');
INSERT INTO Groups(GroupName)
VALUES('Management');
INSERT INTO Groups(GroupName)
VALUES('Creative');
GO

INSERT INTO Users(Username,Pass,FullName,LastLoginTime,GroupID)
VALUES('boyko','12345','Boyko Georgiev', GETDATE(),5);
INSERT INTO Users(Username,Pass,FullName,LastLoginTime,GroupID)
VALUES('gosho','12345','Gosho Georgiev', GETDATE(),5);
INSERT INTO Users(Username,Pass,FullName,LastLoginTime,GroupID)
VALUES('miro','12345','Miroslav Georgiev', GETDATE(),4);
INSERT INTO Users(Username,Pass,FullName,LastLoginTime,GroupID)
VALUES('petya','12345','Petya Petrova', GETDATE(),3);
GO

--20. Write SQL statements to update some of the records in the Users and Groups tables.
UPDATE Groups
SET GroupName = 'Developement'
WHERE GroupName = 'Creative'
GO

UPDATE Users
SET LastLoginTime = '2008-08-23 19:28:40.840'
WHERE Username IN ('pesho','stamat','gosho')
GO

--21.Write SQL statements to delete some of the records from the Users and Groups tables.
DELETE FROM Users
WHERE FullName = 'Miroslav Georgiev'
GO

DELETE FROM Groups
WHERE GroupName = 'Management'
GO

/*22.Write SQL statements to insert in the Users table the names of all employees 
	 from the Employees table. Combine the first and last names as a full name.
	 For username use the first letter of the first name + the last name (in lowercase). 
	 Use the same for the password, and NULL for last login time.
*/

INSERT INTO Users (Username,Pass,FullName)
SELECT LOWER(SUBSTRING(FirstName, 0, 4) + LastName), LOWER(SUBSTRING(FirstName, 0, 4) + LastName), FirstName + ' ' + LastName
FROM [TelerikAcademy].[dbo].[Employees]


--23.Write a SQL statement that changes the password to NULL for all users that have not been in the system since 10.03.2010.
UPDATE Users
SET LastLoginTime = NULL
WHERE LastLoginTime < CONVERT(datetime, '10.06.2009',104)

--24.Write a SQL statement that deletes all users without passwords (NULL password).
--Password is not nullable in my case so there is nothing to be deleted.
DELETE FROM Users
WHERE Pass is NULL

--25.Write a SQL query to display the average employee salary by department and job title.
SELECT d.Name,e.JobTitle, AVG(e.Salary) AS [Average Salary]
FROM [TelerikAcademy].[dbo].[Employees] e
	INNER JOIN [TelerikAcademy].[dbo].[Departments] d
		ON e.DepartmentID = d.DepartmentID
GROUP BY d.Name, e.JobTitle
ORDER BY [Average Salary] DESC

/*26.Write a SQL query to display the minimal employee salary by department and job title 
along with the name of some of the employees that take it.
*/
SELECT ms.Name, ms.JobTitle, ms.MinSalary, emp.FirstName + ' ' + emp.LastName as Name
FROM (SELECT d.Name, d.DepartmentID, e.JobTitle, MIN(e.Salary) AS MinSalary 
	FROM [TelerikAcademy].[dbo].[Employees] e
		INNER JOIN [TelerikAcademy].[dbo].[Departments] d 
			ON d.DepartmentID = e.DepartmentID
		GROUP BY d.Name, d.DepartmentID, e.JobTitle) ms
	INNER JOIN [TelerikAcademy].[dbo].[Employees] emp 
		ON emp.Salary =  ms.MinSalary AND emp.JobTitle = ms.JobTitle AND emp.DepartmentID = ms.DepartmentID

--27.Write a SQL query to display the town where maximal number of employees work.
SELECT TOP 1 t.Name, COUNT(*) AS [Living Employees]
FROM [TelerikAcademy].[dbo].[Employees] e
	INNER JOIN [TelerikAcademy].[dbo].[Addresses] a
		ON e.AddressID = a.AddressID
	INNER JOIN [TelerikAcademy].[dbo].[Towns] t
		ON a.TownID = t.TownID
GROUP BY t.Name
ORDER BY [Living Employees] DESC

--28.Write a SQL query to display the number of managers from each town.
SELECT t.Name, COUNT(DISTINCT(e.ManagerID))
FROM [TelerikAcademy].[dbo].[Employees] e
	LEFT JOIN [TelerikAcademy].[dbo].[Employees] m
		ON m.EmployeeID = e.ManagerID
	INNER JOIN [TelerikAcademy].[dbo].[Addresses] a
		ON m.AddressID = a.AddressID
	INNER JOIN [TelerikAcademy].[dbo].[Towns] t
		ON a.TownID = t.TownID
GROUP BY t.Name


/*29.Write a SQL to create table WorkHours to store work reports for each employee (employee id, date, task, hours, comments). 
	 Don't forget to define  identity, primary key and appropriate foreign key. 
	 Issue few SQL statements to insert, update and delete of some data in the table.
	 Define a table WorkHoursLogs to track all changes in the WorkHours table with triggers. 
	 For each change keep the old record data, the new record data and the command (insert / update / delete).
*/
USE TelerikAcademy
CREATE TABLE WorkHours
(
  WorkHourEntryID int IDENTITY,
  EntryDate date NOT NULL,
  Task nvarchar(100) NOT NULL,
  EntryHours int NOT NULL,
  EntryComments nvarchar(200),
  EmployeeID int NOT NULL,
  CONSTRAINT PK_WorkHourEntryID PRIMARY KEY(WorkHourEntryID),
  CONSTRAINT CC_Hours CHECK (EntryHours>0 AND EntryHours<=24)
)
GO

ALTER TABLE [dbo].[WorkHours]  WITH CHECK ADD  CONSTRAINT [FK_WorkHours_Employees] FOREIGN KEY([EmployeeID])
REFERENCES [dbo].[Employees] ([EmployeeID])
GO

USE TelerikAcademy
CREATE TABLE WorkHoursLogs
(
  LogID int IDENTITY,
  WorkHourEntryIDNew int,
  EntryDateNew date,
  TaskNew nvarchar(100),
  EntryHoursNew int,
  EntryCommentsNew nvarchar(200),
  EmployeeIDNew int,
  CommandType nvarchar(10),
  CONSTRAINT PK_LogID PRIMARY KEY(LogID),
)
GO

CREATE TRIGGER tr_WorkHoursInsert ON WorkHours FOR INSERT
AS
  INSERT INTO WorkHoursLogs (WorkHourEntryIDNew,EntryDateNew,TaskNew,EntryHoursNew,EntryCommentsNew,
  EmployeeIDNew,CommandType)
  SELECT i.WorkHourEntryID, i.EntryDate, i.Task, i.EntryHours, i.EntryComments, i.EmployeeID,'insert'
  FROM WorkHours w INNER JOIN inserted i on w.WorkHourEntryID = i.WorkHourEntryID
GO

CREATE TRIGGER tr_WorkHoursUpdate ON WorkHours FOR UPDATE
AS
  INSERT INTO WorkHoursLogs (WorkHourEntryIDNew,EntryDateNew,TaskNew,EntryHoursNew,EntryCommentsNew,
  EmployeeIDNew,CommandType)
  SELECT i.WorkHourEntryID, i.EntryDate, i.Task, i.EntryHours, i.EntryComments, i.EmployeeID,'update'
  FROM deleted d INNER JOIN inserted i on d.WorkHourEntryID = i.WorkHourEntryID
GO

CREATE TRIGGER tr_WorkHoursDelete ON WorkHours FOR DELETE
AS
  INSERT INTO WorkHoursLogs (WorkHourEntryIDNew,EntryDateNew,TaskNew,EntryHoursNew,EntryCommentsNew,
  EmployeeIDNew,CommandType)
  SELECT d.WorkHourEntryID, d.EntryDate, d.Task, d.EntryHours, d.EntryComments, d.EmployeeID,'delete'
  FROM deleted d
GO

INSERT INTO WorkHours (EntryDate, Task, EntryHours, EntryComments, EmployeeID)
VALUES (CONVERT(date, '20140712', 112), 'Nothing', 8, 'hello', 1),
(CONVERT(date, '20140511', 112), 'Nothing', 4, NULL, 3),
(CONVERT(date, '20140713', 112), 'More Nothing', 4, 'do nothing', 1),
(CONVERT(date, '20140611', 112), 'Nothing', 12, 'more Nothing', 2),
(CONVERT(date, '20140530', 112), 'Nothing', 5, NULL , 4)
GO

UPDATE WorkHours
SET EntryHours = 8, Task = 'Nothing again', EntryComments = 'i am tired of doing nothing'
WHERE EmployeeID=1 AND EntryDate = CONVERT(date, '20140713', 112)
GO

DELETE FROM WorkHours
WHERE EmployeeID = 4

/*30.Start a database transaction, delete all employees from the 'Sales' department along with all dependent 
	 records from the pother tables. At the end rollback the transaction.
*/
BEGIN TRAN
ALTER TABLE [TelerikAcademy].[dbo].[Departments]  DROP [FK_Departments_Employees]
DELETE FROM [TelerikAcademy].[dbo].[Employees]
WHERE DepartmentID = 
	(SELECT DepartmentID
	 FROM [TelerikAcademy].[dbo].[Departments] 
	 WHERE Name ='Sales')
DELETE FROM [TelerikAcademy].[dbo].[Departments]
WHERE Name = 'Sales'
ROLLBACK TRAN
GO

--31.Start a database transaction and drop the table EmployeesProjects. Now how you could restore back the lost table data?
BEGIN TRAN
DROP TABLE [TelerikAcademy].[dbo].[EmployeesProjects]
ROLLBACK TRAN


BEGIN TRAN
SELECT * INTO #TempTable FROM [TelerikAcademy].[dbo].[EmployeesProjects]
DROP TABLE [TelerikAcademy].[dbo].[EmployeesProjects]
COMMIT

USE TelerikAcademy
CREATE TABLE [dbo].[EmployeesProjects](
	[EmployeeID] [int] NOT NULL,
	[ProjectID] [int] NOT NULL,
 CONSTRAINT [PK_EmployeesProjects] PRIMARY KEY CLUSTERED 
(
	[EmployeeID] ASC,
	[ProjectID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[EmployeesProjects]  WITH CHECK ADD  CONSTRAINT [FK_EmployeesProjects_Employees] FOREIGN KEY([EmployeeID])
REFERENCES [dbo].[Employees] ([EmployeeID])
GO

ALTER TABLE [dbo].[EmployeesProjects] CHECK CONSTRAINT [FK_EmployeesProjects_Employees]

ALTER TABLE [dbo].[EmployeesProjects]  WITH CHECK ADD  CONSTRAINT [FK_EmployeesProjects_Projects] FOREIGN KEY([ProjectID])
REFERENCES [dbo].[Projects] ([ProjectID])

ALTER TABLE [dbo].[EmployeesProjects] CHECK CONSTRAINT [FK_EmployeesProjects_Projects]

INSERT INTO EmployeesProjects
SELECT * FROM #TempTable
