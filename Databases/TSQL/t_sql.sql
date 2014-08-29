/*1 Create a database with two tables: Persons(Id(PK), FirstName, LastName, SSN) and Accounts(Id(PK), 
  PersonId(FK), Balance). Insert few records for testing. Write a stored procedure that selects the full names of all persons.
*/
CREATE TABLE Persons(
	PersonId int IDENTITY,
	FirstName nvarchar(20) NOT NULL,
	LastName nvarchar(20) NOT NULL,
	SSN nvarchar(10) NOT NULL,
	CONSTRAINT PK_PersonId PRIMARY KEY(PersonId)
)

CREATE TABLE Accounts(
	AccountId int IDENTITY,
	Balance money NOT NULL,
	PersonId int NOT NULL,
	CONSTRAINT FK_Person_Account FOREIGN KEY(PersonId)
	REFERENCES Persons(PersonId) 	
)

INSERT INTO Persons
VALUES ('Ivan', 'Ivanov', '1234567890'),
('Petar', 'Petrov', '1234567000')

INSERT INTO Accounts
VALUES ( 1000.54,2),
(225.99,1)
GO

CREATE PROCEDURE uspPersonsFullNames
AS
SELECT FirstName + ' ' + LastName AS [Full Name]
FROM Persons
GO

EXEC uspPersonsFullNames

/*2.Create a stored procedure that accepts a number as a parameter and returns all 
persons who have more money in their accounts than the supplied number.
*/
GO
CREATE PROCEDURE uspHigherBalanceThan @balance money = 200
AS
SELECT *
FROM Persons p 
	JOIN Accounts a
		ON p.PersonId = a.PersonId
WHERE a.Balance > @balance
GO
EXEC uspHigherBalanceThan
EXEC uspHigherBalanceThan 500

/*3.Create a stored procedure that accepts a number as a parameter and returns all 
    persons who have more money in their accounts than the supplied number.
*/
GO
CREATE PROCEDURE uspCalculateInterest (@sum money,
@yearlyInterestInPercents float, @months tinyint,
@newSum money OUTPUT)
AS
	SET @newSum = @sum + (@sum * (@yearlyInterestInPercents/100  * @months / 12))
GO

DECLARE @someNewSum money;
DECLARE @sum money = 1000;
EXEC uspCalculateInterest @sum,12,12, @someNewSum OUTPUT
SELECT @sum AS [Sum], @someNewSum AS [New Sum]

/*4.Create a stored procedure that uses the function from the previous example 
	to give an interest to a person's account for one month. 
	It should take the AccountId and the interest rate as parameters.
*/
GO
CREATE PROCEDURE uspAddInterest(@accountId int,@interestRate float)
AS
DECLARE @balance money;
SELECT @balance= acc.Balance
FROM Accounts acc
WHERE acc.AccountId = @accountId

DECLARE @newBalance money;
EXEC uspCalculateInterest @balance,@interestRate, 1,@newBalance OUTPUT;

UPDATE Accounts
SET Balance = @newBalance
WHERE AccountId = @accountId

GO
EXEC uspAddInterest 1,15;

--5.Add two more stored procedures WithdrawMoney( AccountId, money) and DepositMoney (AccountId, money) that operate in transactions.
GO
CREATE PROCEDURE uspWithDrawMoney(@accountId int, @money int)
AS
	BEGIN TRAN
	UPDATE Accounts
	SET Balance = Balance - @money
	WHERE AccountId = @accountId 
	IF((SELECT Balance FROM Accounts WHERE AccountId = @accountId)>=0)
		BEGIN
			COMMIT TRAN
		END
	ELSE
		BEGIN
			ROLLBACK TRAN
		END
GO

EXEC uspWithDrawMoney 2,100;

GO
CREATE PROCEDURE uspDepositMoney(@accountId int, @money int)
AS
	BEGIN TRAN
	UPDATE Accounts
	SET Balance = Balance + @money
	WHERE AccountId = @accountId 
	COMMIT TRAN
GO
EXEC uspDepositMoney 2,400

/*6.Create another table – Logs(LogID, AccountID, OldSum, NewSum). Add a trigger to the Accounts
    table that enters a new entry into the Logs table every time the sum on an account changes.
*/
CREATE TABLE Logged(
	LoggedId int IDENTITY,
	Person nvarchar(50),
	BalanceChange money,
	TypeOfTransaction nvarchar(20),
	CONSTRAINT PK_LogId PRIMARY KEY(LoggedId),
)
GO
DROP TRIGGER LogTransaction

GO
CREATE TRIGGER LogTransaction
ON Accounts
AFTER UPDATE
AS
IF EXISTS(SELECT * FROM DELETED)
	BEGIN
		DECLARE @personName nvarchar(50), @balanceBefore money, @balanceAfter money, @balanceChange money, @transType varchar(10)
		SELECT @personName = p.FirstName + ' ' + p.LastName, @balanceBefore = d.Balance 
		FROM DELETED d
			INNER JOIN Persons p
			 ON d.PersonId = p.PersonId

		SELECT @balanceAfter = ins.Balance 
		FROM INSERTED ins

		IF(@balanceAfter>@balanceBefore)
			BEGIN
			SELECT @transType= 'Deposited';
			SELECT @balanceChange= @balanceAfter-@balanceBefore;
			END
		ELSE
			BEGIN
			SELECT @transType= 'Withdrawn';
			 SELECT @balanceChange= @balanceBefore-@balanceAfter;
			END
		
		INSERT INTO Logged(Person,BalanceChange,TypeOfTransaction)
		VALUES (@personName,@balanceChange,@transType);
		END
GO

EXEC uspWithDrawMoney 1,500;
EXEC uspDepositMoney 2, 666;

/*7. Define a function in the database TelerikAcademy that returns all Employee's	
	 names (first or middle or last name) and all town's names that are comprised of		
	 given set of letters. Example 'oistmiahf' will return 'Sofia', 'Smith',				
	 … but not 'Rob' and 'Guy'.
*/
GO
CREATE FUNCTION [dbo].ufn_StringComprisedOf(@inputString nvarchar(50), @letterSet nvarchar(100))
  RETURNS BIT
AS
  BEGIN
	DECLARE @inputStringLenght int
	DECLARE @currentIndex int
	DECLARE @input nvarchar(50)
	DECLARE @pattern nvarchar(100)
	SET @inputStringLenght = LEN(@inputString)
	SET @currentIndex = 1
	SET @input = LOWER(@inputString)
	SET @pattern = LOWER(@letterSet)

	WHILE @currentIndex <= @inputStringLenght
	  BEGIN
		IF(CHARINDEX(SUBSTRING(@input,@currentindex,1),@pattern)=0)
		  BEGIN
			RETURN 0
		  END
		SET @currentIndex = @currentIndex +1
	  END
	RETURN 1
  END
GO

CREATE FUNCTION [dbo].ufn_EmployeesAndTownsNameComprisedOf(@letterSet nvarchar(100))
  RETURNS @reulst_table TABLE (name nvarchar(50))
AS
BEGIN

DECLARE empCursor CURSOR READ_ONLY FOR
  SELECT Name FROM (
  SELECT FirstName AS Name FROM Employees
  UNION
  SELECT MiddleName AS Name FROM Employees
  UNION
  SELECT LastName AS Name FROM Employees
  UNION
  SELECT Name AS Name FROM Towns
  ) AS Names
  WHERE Name IS NOT NULL

OPEN empCursor
DECLARE @name nvarchar(50)
FETCH NEXT FROM empCursor INTO @name

DECLARE @nameLen int, @currentIndex int

WHILE @@FETCH_STATUS = 0
  BEGIN
	IF(dbo.ufn_StringComprisedOf(@name,@letterSet)=1)
	  BEGIN
	    INSERT INTO @reulst_table
		VALUES (@name)
	  END
    FETCH NEXT FROM empCursor 
    INTO @name
  END

CLOSE empCursor
DEALLOCATE empCursor
  RETURN
END
GO

SELECT * FROM [dbo].ufn_EmployeesAndTownsNameComprisedOf('oistmiahf')
GO

/*8. Using database cursor write a T-SQL script that scans all employees and		
	 their addresses and prints all pairs of employees that live in the same town.
*/
USE [TelerikAcademy]
GO

SELECT e.EmployeeID ,e.FirstName + ISNULL(' '+ e.MiddleName, '') + ' ' + e.LastName AS EmployeeName, t.TownID, t.Name as TownName
INTO #TempEmployeesWithTowns
FROM Employees e 
	INNER JOIN Addresses a 
		on e.AddressID = a.AddressID
	INNER JOIN Towns t 
		on a.TownID = t.TownID 
CREATE UNIQUE CLUSTERED INDEX Idx_TemEmp ON #TempEmployeesWithTowns(EmployeeID)

DECLARE empCursor CURSOR READ_ONLY FOR
SELECT EmployeeID, EmployeeName, TownID,TownName
FROM #TempEmployeesWithTowns

OPEN empCursor
DECLARE @employeeID int, @employeeName varchar(150), @townID int,  @townName varchar(50)
FETCH NEXT FROM empCursor INTO @employeeID, @employeeName, @townID, @townName

CREATE TABLE #TempEmployeeFromSameTownPairs (FirstEmployeeName varchar(150), SecondEmployeeName varchar(150), TownName varchar(50))
WHILE @@FETCH_STATUS = 0
  BEGIN
	INSERT INTO #TempEmployeeFromSameTownPairs (FirstEmployeeName, SecondEmployeeName, TownName)
	SELECT @employeeName, EmployeeName, @townName FROM #TempEmployeesWithTowns e
	WHERE e.TownID = @townID AND e.EmployeeID <> @employeeID
    FETCH NEXT FROM empCursor INTO @employeeID, @employeeName, @townID, @townName           
  END
CLOSE empCursor
DEALLOCATE empCursor

SELECT TownName, FirstEmployeeName, SecondEmployeeName FROM #TempEmployeeFromSameTownPairs
ORDER BY TownName, FirstEmployeeName, SecondEmployeeName
DROP TABLE #TempEmployeeFromSameTownPairs
DROP TABLE #TempEmployeesWithTowns
GO
