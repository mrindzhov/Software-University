select FirstName,LastName from Employees
where LEFT(FirstName,2) ='SA'
--1
select FirstName,LastName from Employees
where LastName LIKE  '%ei%'
--2
SELECT FirstName
FROM Employees
WHERE (DepartmentID = 3 OR DepartmentID = 10)
 AND (YEAR(HireDate) BETWEEN 1995 AND 2005)
 --3
 select FirstName,LastName from Employees
where JobTitle NOT LIKE  '%engineer%'
--4
 select Name from Towns
where LEN(Name)in (5,6) order by Name
--5
 select * from Towns
 where Name LIKE('[MKBE]%') 
 order by Name
 --6
  select * from Towns
 where Name NOT LIKE('[RBD]%') 
 order by Name
 --7
 create view 
 V_EmployeesHiredAfter2000 as
 select FirstName,LastName from Employees
where (YEAR(HireDate))>2000
select*from V_EmployeesHiredAfter2000
--8
select FirstName,LastName from Employees
where LEN(LastName)=5
--9
select CountryName,IsoCode from Countries
where CountryName LIKE '%A%A%A%'
order by IsoCode
--10
SELECT 
  p.PeakName, 
  r.RiverName, 
  LOWER(p.PeakName + SUBSTRING(r.RiverName, 2, LEN(r.RiverName))) AS Mix
FROM Peaks p, Rivers r
WHERE RIGHT(p.PeakName, 1) = LEFT(r.RiverName, 1)
ORDER BY Mix
--11
SELECT TOP 50 Name AS Game, SUBSTRING(CONVERT(VARCHAR, Start, 120), 1, 10)
FROM Games
WHERE YEAR(Start) >= 2011 and YEAR(Start) <= 2012
ORDER BY Start, Game
--12
Select Username,RIGHT(Email, LEN(Email) - CHARINDEX('@', Email))  as 'Email Provider' from Users
order by [Email Provider],Username
--13
Select Username,IpAddress from Users
Where IpAddress LIKE '___.1%.%.___' 
order by Username
--14
Select
 Name as Game,
 CASE 
	 WHEN DATEPART(HOUR, Start) >= 0 and DATEPART(HOUR, Start) < 12 THEN 'Morning'
	 WHEN DATEPART(HOUR, Start) >= 12and DATEPART(HOUR, Start) < 18 THEN 'Afternoon'
	 WHEN DATEPART(HOUR, Start) >= 18 and DATEPART(HOUR, Start) < 24 THEN 'Evening'
 End as 'Part of the Day',
 CASE 
	WHEN Duration<=3 THEN 'Extra Short'
	WHEN Duration between 4 and 6 THEN 'Short'
	WHEN Duration > 6 THEN 'Long'
	WHEN Duration is NULL THEN 'Extra Long'
End	as'Duration' 
from Games 
order by Game,Duration,[Part of the Day]
--15
create database mydb
use mydb
drop table Orders;
CREATE TABLE Orders
(
Id INT NOT NULL,
ProductName VARCHAR(50) NOT NULL,
OrderDate DATETIME NOT NULL
CONSTRAINT PK_Orders PRIMARY KEY (Id)
)

INSERT INTO Orders (Id, ProductName, OrderDate) VALUES (1, 'Butter', '20160919');
INSERT INTO Orders (Id, ProductName, OrderDate) VALUES (2, 'Milk', '20160930');
INSERT INTO Orders (Id, ProductName, OrderDate) VALUES (3, 'Cheese', '20160904');
INSERT INTO Orders (Id, ProductName, OrderDate) VALUES (4, 'Bread', '20151220');
INSERT INTO Orders (Id, ProductName, OrderDate) VALUES (5, 'Tomatoes', '20150101');
INSERT INTO Orders (Id, ProductName, OrderDate) VALUES (6, 'Tomatoe2', '20150201');
INSERT INTO Orders (Id, ProductName, OrderDate) VALUES (7, 'Tomatoess', '20150401');
INSERT INTO Orders (Id, ProductName, OrderDate) VALUES (8, 'Tomatoe3', '20150128');
INSERT INTO Orders (Id, ProductName, OrderDate) VALUES (9, 'Tomatoe4', '20150628');
INSERT INTO Orders (Id, ProductName, OrderDate) VALUES (10, 'Tomatoe44s', '20150630');
INSERT INTO Orders (Id, ProductName, OrderDate) VALUES (11, 'Tomatoefggs', '20150228');
INSERT INTO Orders (Id, ProductName, OrderDate) VALUES (12, 'Tomatoesytu', '20160228');
INSERT INTO Orders (Id, ProductName, OrderDate) VALUES (13, 'Toyymatddoehys', '20151231');
INSERT INTO Orders (Id, ProductName, OrderDate) VALUES (14, 'Tom443atoes', '20151215');
INSERT INTO Orders (Id, ProductName, OrderDate) VALUES (15, 'Tomat65434foe23gfhgsPep', '20151004');

SELECT
ProductName,
OrderDate,
DATEADD(DAY, 3, OrderDate) AS "Pay due",
DATEADD(MONTH, 1, OrderDate) AS "Order due"
FROM Orders;
--16
CREATE TABLE People
(
Id INT NOT NULL,
Name VARCHAR(50) NOT NULL,
Birthday DATETIME NOT NULL
)

INSERT INTO People (Id, Name, Birthday) VALUES (1, 'Victor', '20001207');
INSERT INTO People (Id, Name, Birthday) VALUES (2, 'Steven', '19920910');
INSERT INTO People (Id, Name, Birthday) VALUES (3, 'Stephen', '19100919');
INSERT INTO People (Id, Name, Birthday) VALUES (4, 'John', '20100106');

SELECT 
	Name,
	Birthday,
	DATEDIFF(YEAR, Birthday, GETDATE()) as "Age in Years",
	DATEDIFF(MONTH, Birthday, GETDATE()) as "Age in Months",
	DATEDIFF(DAY, Birthday, GETDATE()) as "Age in Days",
	DATEDIFF(MINUTE, Birthday, GETDATE()) as "Age in Minutes"
FROM People;
--17