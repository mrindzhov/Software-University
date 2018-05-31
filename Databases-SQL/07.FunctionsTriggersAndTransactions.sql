-------------------------------------------------------------------------
--SoftUni Databases Basics MSSQL - Functions, Triggers and Transactions--
--Solutions for all exercises                                          --
-------------------------------------------------------------------------

--PART I: SoftUni Database Queries
USE SoftUni
GO

--Problem 1. Employees with Salary Above 35000
DROP PROCEDURE usp_GetEmployeesSalaryAbove35000
GO
CREATE PROCEDURE usp_GetEmployeesSalaryAbove35000
AS
SELECT FirstName, LastName FROM Employees
WHERE Salary > 35000
GO

EXEC usp_GetEmployeesSalaryAbove35000

--Problem 2. Employees with Salary Above Number
DROP PROCEDURE usp_GetEmployeesSalaryAboveNumber
GO
CREATE PROCEDURE usp_GetEmployeesSalaryAboveNumber @number MONEY
AS
SELECT FirstName, LastName FROM Employees
WHERE Salary >= @number
GO

EXEC usp_GetEmployeesSalaryAboveNumber 10000.234

--Problem 3. Towns Starting With
DROP PROCEDURE usp_GetTownsStartingWith
GO
CREATE PROCEDURE usp_GetTownsStartingWith @prefix VARCHAR(MAX)
AS
SELECT [Name] FROM Towns
WHERE Name LIKE CONCAT(@prefix, '%')
GO

EXEC usp_GetTownsStartingWith sofia

--Problem 4. Employees from Town
DROP PROCEDURE usp_GetEmployeesFromTown
GO
CREATE PROCEDURE usp_GetEmployeesFromTown @townName VARCHAR(MAX)
AS
	SELECT FirstName, LastName FROM Employees
	JOIN Addresses ON Employees.AddressID = Addresses.AddressID
	JOIN Towns ON Addresses.TownID = Towns.TownID
	WHERE Towns.Name = @townName
GO
select * from towns
EXEC usp_GetEmployeesFromTown [index]

--Problem 5. Salary Level Function
IF OBJECT_ID ('ufn_GetSalaryLevel') IS NOT NULL  
    DROP FUNCTION ufn_GetSalaryLevel;  
GO  
CREATE FUNCTION ufn_GetSalaryLevel(@salary INT)
RETURNS NVARCHAR(10)
AS
BEGIN
DECLARE @salaryLevel VARCHAR(10);
	IF (@salary < 30000)
	BEGIN
		SET @salaryLevel = 'Low';
	END;
	ELSE IF(@salary >= 30000 AND @salary <= 50000)
	BEGIN
		SET @salaryLevel = 'Average';
	END;
	ELSE
	BEGIN
		SET @salaryLevel = 'High';
	END;
	RETURN @salaryLevel;
END;
GO

SELECT FirstName, LastName, Salary, dbo.ufn_GetSalaryLevel(Salary) FROM Employees
WHERE Salary < 30000
GO

--Problem 6. Employees by Salary Level
CREATE PROCEDURE usp_GetEmployeesBySalaryLevel @salaryLevel VARCHAR(10)
AS
	SELECT FirstName, LastName FROM Employees
	WHERE dbo.ufn_GetSalaryLevel(Salary) = @salaryLevel
GO

EXEC usp_GetEmployeesBySalaryLevel 'high'
GO
--Problem 7. Define Function
CREATE FUNCTION ufn_IsWordComprised(@setOfLetters VARCHAR(MAX), @word VARCHAR(MAX))
RETURNS BIT
AS
BEGIN
	DECLARE @counter INT = 1;
	WHILE @counter < LEN(@word)
	BEGIN
		DECLARE @char VARCHAR = SUBSTRING(@word, @counter, 1);
		IF(CHARINDEX(@char, @setOfLetters, 1) = 0)
		BEGIN
			RETURN 0
		END
		SET @counter = @counter + 1
	END
	RETURN 1
END
GO

SELECT [Name] FROM Towns
WHERE dbo.ufn_IsWordComprised('afiso', [Name]) = 0

--Problem 8. *Delete Employees and Departments
GO
CREATE TRIGGER t_EmployeesDelete
on Employees
INSTEAD OF DELETE
AS
    UPDATE Employees SET ManagerID = NULL WHERE ManagerID IN (SELECT EmployeeID FROM deleted)
	UPDATE Departments SET ManagerID = NULL WHERE ManagerID IN (SELECT EmployeeID FROM deleted)
    DELETE FROM Employees WHERE EmployeeID in (SELECT EmployeeID FROM deleted)
GO

DELETE FROM EmployeesProjects
WHERE EmployeeID IN (
          SELECT EmployeeID 
          FROM Employees
          WHERE DepartmentID IN (7, 8)
          )

ALTER TABLE Departments ALTER COLUMN ManagerID INT NULL
/* Instead of using trigger - we can use the queries below.
UPDATE Employees
 SET ManagerID = NULL
 WHERE ManagerID IN 
 (
   SELECT EmployeeId FROM Employees
   WHERE DepartmentID IN (7,8)
 )

UPDATE Departments
 SET ManagerID = NULL
 WHERE ManagerID IN 
 (
   SELECT EmployeeId FROM Employees
   WHERE DepartmentID IN (7,8)
 )
 */

DELETE FROM Employees 
 WHERE DepartmentID IN (7,8)

DELETE FROM Departments
 WHERE DepartmentID IN (7, 8)

SELECT COUNT(*) FROM Employees WHERE DepartmentID = 7 OR DepartmentID = 8
SELECT COUNT(*) FROM Departments WHERE DepartmentID = 7 OR DepartmentID = 8

DROP TRIGGER t_EmployeesDelete

 -- Problem 9. Employees with Three Projects 
GO
CREATE PROCEDURE udp_AssignProject (@EmployeeID INT, @ProjectID INT)
AS
BEGIN
DECLARE @maxEmployeeProjectsCount INT = 3
DECLARE @employeeProjectsCount INT
SET @employeeProjectsCount = (SELECT COUNT(*) 
		        FROM [dbo].[EmployeesProjects] AS ep
		       WHERE ep.EmployeeId = @EmployeeID)
  BEGIN TRAN
  INSERT INTO [dbo].[EmployeesProjects]  (EmployeeID, ProjectID) VALUES (@EmployeeID, @ProjectID)
  
  IF(@employeeProjectsCount >= @maxEmployeeProjectsCount)
    BEGIN
     RAISERROR('The employee has too many projects!', 16, 1)
     ROLLBACK
    END
  ELSE
     COMMIT
END

EXEC udp_AssignProject 2,1
EXEC udp_AssignProject 2,2
EXEC udp_AssignProject 2,3
BEGIN TRY  
 EXEC udp_AssignProject 2,4
END TRY  
BEGIN CATCH  
   SELECT error_message()
END CATCH;

SELECT COUNT(*) FROM EmployeesProjects WHERE EmployeeId = 2

DROP PROCEDURE udp_AssignProject
DELETE FROM EmployeesProjects WHERE EmployeeID = 2
--PART II: Bank Database Queries
DROP DATABASE Bank
GO
CREATE DATABASE Bank
GO
USE Bank
GO
CREATE TABLE AccountHolders
(
Id INT NOT NULL,
FirstName VARCHAR(50) NOT NULL,
LastName VARCHAR(50) NOT NULL,
SSN CHAR(10) NOT NULL
CONSTRAINT PK_AccountHolders PRIMARY KEY (Id)
)

CREATE TABLE Accounts
(
Id INT NOT NULL,
AccountHolderId INT NOT NULL,
Balance MONEY DEFAULT 0
CONSTRAINT PK_Accounts PRIMARY KEY (Id)
CONSTRAINT FK_Accounts_AccountHolders FOREIGN KEY (AccountHolderId) REFERENCES AccountHolders(Id)
)

INSERT INTO AccountHolders (Id, FirstName, LastName, SSN) VALUES (1, 'Susan', 'Cane', '1234567890');
INSERT INTO AccountHolders (Id, FirstName, LastName, SSN) VALUES (2, 'Kim', 'Novac', '1234567890');
INSERT INTO AccountHolders (Id, FirstName, LastName, SSN) VALUES (3, 'Jimmy', 'Henderson', '1234567890');
INSERT INTO AccountHolders (Id, FirstName, LastName, SSN) VALUES (4, 'Steve', 'Stevenson', '1234567890');
INSERT INTO AccountHolders (Id, FirstName, LastName, SSN) VALUES (5, 'Bjorn', 'Sweden', '1234567890');
INSERT INTO AccountHolders (Id, FirstName, LastName, SSN) VALUES (6, 'Kiril', 'Petrov', '1234567890');
INSERT INTO AccountHolders (Id, FirstName, LastName, SSN) VALUES (7, 'Petar', 'Kirilov', '1234567890');
INSERT INTO AccountHolders (Id, FirstName, LastName, SSN) VALUES (8, 'Michka', 'Tsekova', '1234567890');
INSERT INTO AccountHolders (Id, FirstName, LastName, SSN) VALUES (9, 'Zlatina', 'Pateva', '1234567890');
INSERT INTO AccountHolders (Id, FirstName, LastName, SSN) VALUES (10, 'Monika', 'Miteva', '1234567890');
INSERT INTO AccountHolders (Id, FirstName, LastName, SSN) VALUES (11, 'Zlatko', 'Zlatyov', '1234567890');
INSERT INTO AccountHolders (Id, FirstName, LastName, SSN) VALUES (12, 'Petko', 'Petkov Junior', '1234567890');

INSERT INTO Accounts (Id, AccountHolderId, Balance) VALUES (1, 1, 123.12);
INSERT INTO Accounts (Id, AccountHolderId, Balance) VALUES (2, 3, 4354.23);
INSERT INTO Accounts (Id, AccountHolderId, Balance) VALUES (3, 12, 6546543.23);
INSERT INTO Accounts (Id, AccountHolderId, Balance) VALUES (4, 9, 15345.64);
INSERT INTO Accounts (Id, AccountHolderId, Balance) VALUES (5, 11, 36521.20);
INSERT INTO Accounts (Id, AccountHolderId, Balance) VALUES (6, 8, 5436.34);
INSERT INTO Accounts (Id, AccountHolderId, Balance) VALUES (7, 10, 565649.20);
INSERT INTO Accounts (Id, AccountHolderId, Balance) VALUES (8, 11, 999453.50);
INSERT INTO Accounts (Id, AccountHolderId, Balance) VALUES (9, 1, 5349758.23);
INSERT INTO Accounts (Id, AccountHolderId, Balance) VALUES (10, 2, 543.30);
INSERT INTO Accounts (Id, AccountHolderId, Balance) VALUES (11, 3, 10.20);
INSERT INTO Accounts (Id, AccountHolderId, Balance) VALUES (12, 7, 245656.23);
INSERT INTO Accounts (Id, AccountHolderId, Balance) VALUES (13, 5, 5435.32);
INSERT INTO Accounts (Id, AccountHolderId, Balance) VALUES (14, 4, 1.23);
INSERT INTO Accounts (Id, AccountHolderId, Balance) VALUES (15, 6, 0.19);
INSERT INTO Accounts (Id, AccountHolderId, Balance) VALUES (16, 2, 5345.34);
INSERT INTO Accounts (Id, AccountHolderId, Balance) VALUES (17, 11, 76653.20);
INSERT INTO Accounts (Id, AccountHolderId, Balance) VALUES (18, 1, 235469.89);

--Problem 10. Find Full Name
GO
CREATE PROC usp_GetHoldersFullName 
AS
	SELECT FirstName + ' ' + LastName FROM AccountHolders
GO

EXEC usp_GetHoldersFullName
GO
--Problem 11. People with Balance Higher Than
GO
CREATE PROCEDURE usp_GetHoldersWithBalanceHigherThan @balance MONEY
AS
	SELECT FirstName, LastName FROM AccountHolders
	JOIN Accounts ON Accounts.AccountHolderId = AccountHolders.Id
	GROUP BY FirstName, LastName
	HAVING SUM(Balance) > @balance
GO

EXEC usp_GetHoldersWithBalanceHigherThan 7000
GO

--Problem 12. Future Value Function
GO
CREATE FUNCTION ufn_CalculateFutureValue(@sum MONEY, @rate FLOAT, @years FLOAT)
RETURNS MONEY
AS
BEGIN
	DECLARE @fv MONEY = @sum * POWER((1 + @rate), @years)
	RETURN @fv
END
GO
SELECT dbo.ufn_CalculateFutureValue(1000, 0.10, 5)
SELECT dbo.ufn_CalculateFutureValue(1000, 0.08, 5) 
SELECT dbo.ufn_CalculateFutureValue(1000, 0.04, 2)
SELECT dbo.ufn_CalculateFutureValue(1000.21, 0.02, 1) 
SELECT dbo.ufn_CalculateFutureValue(1000.98, 0.05, 3) 
GO

--Problem 13. Calculating Interest
GO
CREATE PROC usp_CalculateFutureValueForAccount @accountID INT, @rate FLOAT
AS
	SELECT 
		acc.Id,
		FirstName,
		LastName,
		Balance AS [Current Balance],
		dbo.ufn_CalculateFutureValue(Balance, @rate, 5) AS [Balance in 5 years]
	FROM Accounts acc
	JOIN AccountHolders ah ON acc.AccountHolderId = ah.Id
	WHERE acc.Id = @accountID
GO

EXEC Bank.dbo.usp_CalculateFutureValueForAccount 1, 0.1
GO

--Problem 14. Deposit Money Procedure
CREATE PROCEDURE usp_DepositMoney @account INT, @moneyAmount MONEY
AS
BEGIN
	BEGIN TRANSACTION;
	
	UPDATE Accounts SET Balance = Balance + @moneyAmount
	WHERE Id = @account;
	IF @@ROWCOUNT <> 1
	BEGIN
		ROLLBACK;
		RAISERROR('Invalid account!', 16, 1);
		RETURN;
	END;  

	COMMIT;
END
GO

EXEC usp_DepositMoney 1, 10
select * from Accounts
WHERE id = 1

EXEC usp_DepositMoney 2, 10.1
select * from Accounts
WHERE id = 2

EXEC usp_DepositMoney 3, 12.43245656
select * from Accounts
WHERE id = 3

--Problem 15. Withdraw Money Procedures
GO
CREATE PROCEDURE usp_WithdrawMoney @account INT, @moneyAmount MONEY
AS
BEGIN
	BEGIN TRANSACTION;
	
	UPDATE Accounts SET Balance = Balance - @moneyAmount
	WHERE Id = @account;
	IF @@ROWCOUNT <> 1
	BEGIN
		ROLLBACK;
		RAISERROR('Invalid account!', 16, 1);
		RETURN;
	END;  

	COMMIT;
END
GO
EXEC usp_WithdrawMoney 1, 10
select * from Accounts
WHERE id = 1

EXEC usp_WithdrawMoney 2, 10.1
select * from Accounts
WHERE id = 2

EXEC usp_WithdrawMoney 3, 12.43245656
select * from Accounts
WHERE id = 3
EXEC usp_WithdrawMoney 4, 0
select * from Accounts
WHERE id = 4

EXEC usp_DepositMoney 1, 12.3
EXEC usp_WithdrawMoney 1, 12.0001
SELECT * FROM Accounts WHERE id = 1
GO
--Problem 16. Money Transfer
CREATE PROCEDURE usp_TransferMoney @fromAccount INT, @toAccount INT, @moneyAmount MONEY
AS
BEGIN
	BEGIN TRANSACTION;

	IF @moneyAmount < 0
	BEGIN
		ROLLBACK;
		RAISERROR('Money amount cannot be negative', 16, 1);
		RETURN;
	END;

	EXEC dbo.usp_WithdrawMoney @fromAccount, @moneyAmount;

	EXEC dbo.usp_DepositMoney @toAccount, @moneyAmount;

	COMMIT;
END
GO
EXEC usp_TransferMoney 1, 2, 10
SELECT * FROM Accounts WHERE Id = 1
SELECT * FROM Accounts WHERE Id = 2

EXEC usp_TransferMoney 2, 1, 10
DROP PROC usp_TransferMoney
--Problem 17. Create Table Logs
CREATE TABLE Logs(
LogId INT IDENTITY NOT NULL,
AccountId INT NOT NULL,
OldSum MONEY,
NewSum Money
);

CREATE TRIGGER t_Account ON Accounts AFTER UPDATE
AS
BEGIN
		DECLARE @accountId INT = (SELECT Id FROM inserted);
		DECLARE @oldSum MONEY = (SELECT Balance FROM deleted);
		DECLARE @newSum MONEY = (SELECT Balance FROM inserted);
		INSERT INTO Logs (AccountId, OldSum, NewSum) VALUES (@accountId, @oldSum, @newSum);
END
GO

EXEC usp_DepositMoney 1, 10
EXEC usp_WithdrawMoney 1, 10
SELECT * FROM Logs

DROP TRIGGER t_Account
--Problem 18. Create Table Emails
CREATE TABLE NotificationEmails
(
Id INT IDENTITY NOT NULL,
Recipient INT NOT NULL,
Subject VARCHAR(50),
Body VARCHAR(300)
CONSTRAINT PK_NotificationEmails PRIMARY KEY (Id)
)
GO

CREATE TRIGGER t_CreateEmail ON Logs AFTER INSERT
AS
BEGIN
	DECLARE @recipient INT = (SELECT AccountId from inserted);
	DECLARE @oldSum MONEY = (SELECT OldSum from inserted);
	DECLARE @newSum MONEY = (SELECT NewSum from inserted);
	DECLARE @subject VARCHAR(50) = CONCAT('Balance change for account: ', @recipient) 
	DECLARE @body VARCHAR(300) = CONCAT('On ', GETDATE(), ' your balance was changed from ', @oldSum, ' to ', @newSum, '.')

	INSERT INTO NotificationEmails (Recipient, Subject, Body) VALUES (@recipient, @subject, @body);
END
GO
EXEC usp_DepositMoney 1, 10
SELECT * FROM Logs
SELECT * FROM NotificationEmails
--PART III: Diablo Database Queries
USE Diablo 
GO

--Problem 19. Scalar Function: Cash in User Games Odd Rows
create function ufn_CashInUsersGames(@gameName nvarchar(max))
returns table
as return
with prices as (
	select Cash, (ROW_NUMBER() OVER(ORDER BY ug.Cash desc)) as RowNum from UsersGames ug
	join Games g on ug.GameId = g.Id
	where g.Name = @gameName
)
select SUM(Cash) [SumCash] FROM prices WHERE RowNum % 2 = 1
GO

select * from ufn_CashInUsersGames('Bali')
union
select * from ufn_CashInUsersGames('Lily Stargazer')
union
select * from ufn_CashInUsersGames('Love in a mist')
union
select * from ufn_CashInUsersGames('Mimosa')
union
select * from ufn_CashInUsersGames('Ming fern')
--Problem 20. Trigger
GO
CREATE TRIGGER tr_UserGameItems on UserGameItems
INSTEAD OF INSERT
AS
	INSERT INTO UserGameItems
	SELECT ItemId, UserGameId FROM inserted
	WHERE
		ItemId in (
			SELECT Id 
			FROM Items 
			WHERE MinLevel <= (
				SELECT [Level]
				FROM UsersGames 
				WHERE Id = UserGameId
			)
		)
GO

-- Add bonus cash for users
UPDATE UsersGames
SET Cash = Cash + 50000 + (SELECT SUM(i.Price) FROM Items i JOIN UserGameItems ugi ON ugi.ItemId = i.Id WHERE ugi.UserGameId = UsersGames.Id)
WHERE UserId IN (
	SELECT Id 
	FROM Users 
	WHERE Username IN ('loosenoise', 'baleremuda', 'inguinalself', 'buildingdeltoid', 'monoxidecos')
)
AND GameId = (SELECT Id FROM Games WHERE Name = 'Bali')

-- Buy items for users

INSERT INTO UserGameItems (UserGameId, ItemId)
SELECT  UsersGames.Id, i.Id 
FROM UsersGames, Items i
WHERE UserId in (
	SELECT Id 
	FROM Users 
	WHERE Username IN ('loosenoise', 'baleremuda', 'inguinalself', 'buildingdeltoid', 'monoxidecos')
) AND GameId = (SELECT Id FROM Games WHERE Name = 'Bali' ) AND ((i.Id > 250 AND i.Id < 300) OR (i.Id > 500 AND i.Id < 540))


-- Get cash from users
UPDATE UsersGames
SET Cash = Cash - (SELECT SUM(i.Price) FROM Items i JOIN UserGameItems ugi ON ugi.ItemId = i.Id WHERE ugi.UserGameId = UsersGames.Id)
WHERE UserId IN (
	SELECT Id 
	FROM Users 
	WHERE Username IN ('loosenoise', 'baleremuda', 'inguinalself', 'buildingdeltoid', 'monoxidecos')
)
AND GameId = (SELECT Id FROM Games where Name = 'Bali')


SELECT u.Username, g.Name, ug.Cash, i.Name [Item Name] FROM UsersGames ug
JOIN Games g ON ug.GameId = g.Id
JOIN Users u ON ug.UserId = u.Id
JOIN UserGameItems ugi ON ugi.UserGameId = ug.Id
JOIN Items i ON i.Id = ugi.ItemId
WHERE g.Name = 'Bali'
ORDER BY Username, [Item Name]

--Problem 21. Massive Shopping
SET XACT_ABORT ON 
BEGIN TRANSACTION [Tran1]

BEGIN TRY
	UPDATE 
		UsersGames 
	SET 
		Cash = Cash - (
			SELECT SUM(Price) FROM Items WHERE MinLevel BETWEEN 11 AND 12
		) 
	WHERE Id = 110

	INSERT INTO UserGameItems (UserGameId, ItemId)
	SELECT 110, Id FROM Items WHERE MinLevel BETWEEN 11 AND 12

COMMIT TRANSACTION [Tran1]

END TRY
BEGIN CATCH
  ROLLBACK TRANSACTION [Tran1]
END CATCH 
GO

BEGIN TRANSACTION [Tran2]

BEGIN TRY
	UPDATE 
		UsersGames 
	SET 
		Cash = Cash - (
			SELECT SUM(Price) FROM Items WHERE MinLevel BETWEEN 19 AND 21
		) 
	WHERE Id = 110

	INSERT INTO UserGameItems (UserGameId, ItemId)
	SELECT 110, Id FROM Items WHERE MinLevel BETWEEN 19 AND 21

COMMIT TRANSACTION [Tran2]
END TRY
BEGIN CATCH
  ROLLBACK TRANSACTION [Tran2]
END CATCH
GO

SELECT Items.Name [Item Name] 
FROM Items 
INNER JOIN UserGameItems ON Items.Id = UserGameItems.ItemId 
WHERE UserGameId = 110 
ORDER BY [Item Name]

--Problem 21. Number of Users for Email Provider
select 
	SUBSTRING(Email, CHARINDEX('@', Email) + 1, LEN(Email) - CHARINDEX('@', Email)) as [Email Provider],
	COUNT(Username) [Number Of Users]
from Users
group by SUBSTRING(Email, CHARINDEX('@', Email) + 1, LEN(Email) - CHARINDEX('@', Email))
order by COUNT(Username) desc, [Email Provider]

--Problem 23. All Users in Games
select g.Name as Game, gt.Name as [Game Type], u.Username, ug.Level, ug.Cash, c.Name as Character from Games g
join GameTypes gt on gt.Id = g.GameTypeId
join UsersGames ug on ug.GameId = g.Id
join Users u on ug.UserId = u.Id
join Characters c on c.Id = ug.CharacterId
order by Level desc, Username, Game

--Problem 24. Users in Games with Their Items
select u.Username, g.Name as Game, COUNT(i.Id) as [Items Count], SUM(i.Price) as [Items Price] 
from Users u
join UsersGames ug on ug.UserId = u.Id
join Games g on ug.GameId = g.Id
join Characters c on ug.CharacterId = c.Id
join UserGameItems ugi on ugi.UserGameId = ug.Id
join Items i on i.Id = ugi.ItemId
group by u.Username, g.Name
having COUNT(i.Id) >= 10
order by [Items Count] desc, [Items Price] desc, Username

--Problem 25. * User in Games with Their Statistics
select 
	u.Username, 
	g.Name as Game, 
	MAX(c.Name) Character,
	SUM(its.Strength) + MAX(gts.Strength) + MAX(cs.Strength) as Strength,
	SUM(its.Defence) + MAX(gts.Defence) + MAX(cs.Defence) as Defence,
	SUM(its.Speed) + MAX(gts.Speed) + MAX(cs.Speed) as Speed,
	SUM(its.Mind) + MAX(gts.Mind) + MAX(cs.Mind) as Mind,
	SUM(its.Luck) + MAX(gts.Luck) + MAX(cs.Luck) as Luck
from Users u
join UsersGames ug on ug.UserId = u.Id
join Games g on ug.GameId = g.Id
join GameTypes gt on gt.Id = g.GameTypeId
join [Statistics] gts on gts.Id = gt.BonusStatsId
join Characters c on ug.CharacterId = c.Id
join [Statistics] cs on cs.Id = c.StatisticId
join UserGameItems ugi on ugi.UserGameId = ug.Id
join Items i on i.Id = ugi.ItemId
join [Statistics] its on its.Id = i.StatisticId
group by u.Username, g.Name
order by Strength desc, Defence desc, Speed desc, Mind desc, Luck desc

--Problem 26. All Items with Greater than Average Statistics
select 
	i.Name, 
	i.Price, 
	i.MinLevel,
	s.Strength,
	s.Defence,
	s.Speed,
	s.Luck,
	s.Mind
from Items i
join [Statistics] s on s.Id = i.StatisticId
where s.Mind > (x`
	select AVG(s.Mind) from Items i 
	join [Statistics] s on s.Id = i.StatisticId
) and s.Luck > (
	select AVG(s.Luck) from Items i 
	join [Statistics] s on s.Id = i.StatisticId
) and s.Speed > (
	select AVG(s.Speed) from Items i 
	join [Statistics] s on s.Id = i.StatisticId
) 
ORDER BY i.Name

--Problem 27. Display All Items with information about Forbidden Game Type
select i.Name as Item, Price, MinLevel, gt.Name as [Forbidden Game Type] from Items i
left join GameTypeForbiddenItems gtf on gtf.ItemId = i.Id
left join GameTypes gt on gt.Id = gtf.GameTypeId
order by [Forbidden Game Type] desc, Item 

--Problem 28. Buy Items for User in Game
INSERT INTO UserGameItems(ItemId, UserGameId)
VALUES 
	(
		(select Id from Items where Name = 'Blackguard'), 
		(select ug.Id from UsersGames ug 
			join Users u on u.Id = ug.UserId
			join Games g on g.Id = ug.GameId
			where u.Username = 'Alex' and g.Name = 'Edinburgh')
	)

update UsersGames
set Cash = Cash - (select Price from Items where Name = 'Blackguard')
where Id = (select ug.Id from UsersGames ug 
			join Users u on u.Id = ug.UserId
			join Games g on g.Id = ug.GameId
			where u.Username = 'Alex' and g.Name = 'Edinburgh')

insert into UserGameItems(ItemId, UserGameId)
values 
	(
		(select Id from Items where Name = 'Bottomless Potion of Amplification'), 
		(select ug.Id from UsersGames ug 
			join Users u on u.Id = ug.UserId
			join Games g on g.Id = ug.GameId
			where u.Username = 'Alex' and g.Name = 'Edinburgh')
	)

update UsersGames
set Cash = Cash - (select Price from Items where Name = 'Bottomless Potion of Amplification')
where Id = (select ug.Id from UsersGames ug 
	join Users u on u.Id = ug.UserId
	join Games g on g.Id = ug.GameId
	where u.Username = 'Alex' and g.Name = 'Edinburgh')

insert into UserGameItems(ItemId, UserGameId)
values (
		(select Id from Items where Name = 'Eye of Etlich (Diablo III)'), 
		(select ug.Id from UsersGames ug 
			join Users u on u.Id = ug.UserId
			join Games g on g.Id = ug.GameId
			where u.Username = 'Alex' and g.Name = 'Edinburgh')
	)

update UsersGames
set Cash = Cash - (select Price from Items where Name = 'Eye of Etlich (Diablo III)')
where Id = (select ug.Id from UsersGames ug 
	join Users u on u.Id = ug.UserId
	join Games g on g.Id = ug.GameId
	where u.Username = 'Alex' and g.Name = 'Edinburgh')

insert into UserGameItems(ItemId, UserGameId)
values (
		(select Id from Items where Name = 'Gem of Efficacious Toxin'), 
		(select ug.Id from UsersGames ug 
			join Users u on u.Id = ug.UserId
			join Games g on g.Id = ug.GameId
			where u.Username = 'Alex' and g.Name = 'Edinburgh')
	)

update UsersGames
set Cash = Cash - (select Price from Items where Name = 'Gem of Efficacious Toxin')
where Id = (select ug.Id from UsersGames ug 
	join Users u on u.Id = ug.UserId
	join Games g on g.Id = ug.GameId
	where u.Username = 'Alex' and g.Name = 'Edinburgh')

insert into UserGameItems(ItemId, UserGameId)
values (
		(select Id from Items where Name = 'Golden Gorget of Leoric'), 
		(select ug.Id from UsersGames ug 
			join Users u on u.Id = ug.UserId
			join Games g on g.Id = ug.GameId
			where u.Username = 'Alex' and g.Name = 'Edinburgh')
	)

update UsersGames
set Cash = Cash - (select Price from Items where Name = 'Golden Gorget of Leoric')
where Id = (select ug.Id from UsersGames ug 
	join Users u on u.Id = ug.UserId
	join Games g on g.Id = ug.GameId
	where u.Username = 'Alex' and g.Name = 'Edinburgh')

	
insert into UserGameItems(ItemId, UserGameId)
values (
		(select Id from Items where Name = 'Hellfire Amulet'), 
		(select ug.Id from UsersGames ug 
			join Users u on u.Id = ug.UserId
			join Games g on g.Id = ug.GameId
			where u.Username = 'Alex' and g.Name = 'Edinburgh')
	)

update UsersGames
set Cash = Cash - (select Price from Items where Name = 'Hellfire Amulet')
where Id = (select ug.Id from UsersGames ug 
	join Users u on u.Id = ug.UserId
	join Games g on g.Id = ug.GameId
	where u.Username = 'Alex' and g.Name = 'Edinburgh')

select u.Username, g.Name, ug.Cash, i.Name [Item Name] from UsersGames ug
join Games g on ug.GameId = g.Id
join Users u on ug.UserId = u.Id
join UserGameItems ugi on ugi.UserGameId = ug.Id
join Items i on i.Id = ugi.ItemId
where g.Name = 'Edinburgh'
order by i.Name

--PART IV – Queries for Geography Database
USE [Geography]
GO
--Problem 29. Peaks and Mountains
SELECT 
  PeakName, MountainRange as Mountain, Elevation
FROM 
  Peaks p 
  JOIN Mountains m ON p.MountainId = m.Id
ORDER BY Elevation DESC, PeakName

--Problem 30. Peaks with Their Mountain, Country and Continent
SELECT 
  PeakName, MountainRange as Mountain, c.CountryName, cn.ContinentName
FROM 
  Peaks p
  JOIN Mountains m ON p.MountainId = m.Id
  JOIN MountainsCountries mc ON m.Id = mc.MountainId
  JOIN Countries c ON c.CountryCode = mc.CountryCode
  JOIN Continents cn ON cn.ContinentCode = c.ContinentCode
ORDER BY PeakName, CountryName

--Problem 31. Rivers by Country
SELECT
  c.CountryName, ct.ContinentName,
  COUNT(r.RiverName) AS RiversCount,
  ISNULL(SUM(r.Length), 0) AS TotalLength
FROM
  Countries c
  LEFT JOIN Continents ct ON ct.ContinentCode = c.ContinentCode
  LEFT JOIN CountriesRivers cr ON c.CountryCode = cr.CountryCode
  LEFT JOIN Rivers r ON r.Id = cr.RiverId
GROUP BY c.CountryName, ct.ContinentName
ORDER BY RiversCount DESC, TotalLength DESC, CountryName

--Problem 32. Count of Countries by Currency
SELECT
  cur.CurrencyCode,
  MIN(cur.Description) AS Currency,
  COUNT(c.CountryName) AS NumberOfCountries
FROM
  Currencies cur
  LEFT JOIN Countries c ON cur.CurrencyCode = c.CurrencyCode
GROUP BY cur.CurrencyCode
ORDER BY NumberOfCountries DESC, Currency ASC

--Problem 33. Population and Area by Continent
SELECT
  ct.ContinentName,
  SUM(CONVERT(numeric, c.AreaInSqKm)) AS CountriesArea,
  SUM(CONVERT(numeric, c.Population)) AS CountriesPopulation
FROM
  Countries c
  LEFT JOIN Continents ct ON ct.ContinentCode = c.ContinentCode
GROUP BY ct.ContinentName
ORDER BY CountriesPopulation DESC

--Problem 34. Monasteries by Country
CREATE TABLE Monasteries(
  Id INT PRIMARY KEY IDENTITY,
  Name NVARCHAR(50),
  CountryCode CHAR(2)
  CONSTRAINT FK_Monasteries_Countries FOREIGN KEY (CountryCode) REFERENCES Countries(CountryCode)
)


INSERT INTO Monasteries(Name, CountryCode) VALUES
('Rila Monastery “St. Ivan of Rila”', 'BG'), 
('Bachkovo Monastery “Virgin Mary”', 'BG'),
('Troyan Monastery “Holy Mother''s Assumption”', 'BG'),
('Kopan Monastery', 'NP'),
('Thrangu Tashi Yangtse Monastery', 'NP'),
('Shechen Tennyi Dargyeling Monastery', 'NP'),
('Benchen Monastery', 'NP'),
('Southern Shaolin Monastery', 'CN'),
('Dabei Monastery', 'CN'),
('Wa Sau Toi', 'CN'),
('Lhunshigyia Monastery', 'CN'),
('Rakya Monastery', 'CN'),
('Monasteries of Meteora', 'GR'),
('The Holy Monastery of Stavronikita', 'GR'),
('Taung Kalat Monastery', 'MM'),
('Pa-Auk Forest Monastery', 'MM'),
('Taktsang Palphug Monastery', 'BT'),
('Sumela Monastery', 'TR')

ALTER TABLE Countries
ADD IsDeleted BIT NOT NULL
DEFAULT 0

UPDATE Countries
SET IsDeleted = 1
WHERE CountryCode IN (
	SELECT c.CountryCode
	FROM Countries c
	  JOIN CountriesRivers cr ON c.CountryCode = cr.CountryCode
	  JOIN Rivers r ON r.Id = cr.RiverId
	GROUP BY c.CountryCode
	HAVING COUNT(r.Id) > 3
)

SELECT 
  m.Name AS Monastery, c.CountryName AS Country
FROM 
  Countries c
  JOIN Monasteries m ON m.CountryCode = c.CountryCode
WHERE c.IsDeleted = 0
ORDER BY m.Name

--Problem 35. Monasteries by Continents and Countries
UPDATE Countries
SET CountryName = 'Burma'
WHERE CountryName = 'Myanmar'

INSERT INTO Monasteries(Name, CountryCode) VALUES
('Hanga Abbey', (SELECT CountryCode FROM Countries WHERE CountryName = 'Tanzania'))
INSERT INTO Monasteries(Name, CountryCode) VALUES
('Myin-Tin-Daik', (SELECT CountryCode FROM Countries WHERE CountryName = 'Maynmar'))

SELECT ct.ContinentName, c.CountryName, COUNT(m.Id) AS MonasteriesCount
FROM Continents ct
  LEFT JOIN Countries c ON ct.ContinentCode = c.ContinentCode
  LEFT JOIN Monasteries m ON m.CountryCode = c.CountryCode
WHERE c.IsDeleted = 0
GROUP BY ct.ContinentName, c.CountryName
ORDER BY MonasteriesCount DESC, c.CountryName