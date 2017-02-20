select COUNT(Id) from WizzardDeposits
--1
select Max(MagicWandSize) from WizzardDeposits
--2
select DepositGroup , Max(MagicWandSize) as 'LongestMagicWand' 
from WizzardDeposits
group by DepositGroup
--3
select top 1 With Ties DepositGroup from WizzardDeposits 
group by DepositGroup 
order by AVG(MagicWandSize)

select DepositGroup from WizzardDeposits 
group by DepositGroup
Having AVG(MagicWandSize)=(select MIN(a.av) from (select DepositGroup,AVG(MagicWandSize) as av from WizzardDeposits
group by DepositGroup) as a)
--4
 select DepositGroup , SUM(DepositAmount) as 'Total Sum' 
from WizzardDeposits as e
group by e.DepositGroup
--5
Select DepositGroup,Sum(DepositAmount) as TotalSum from WizzardDeposits
where MagicWandCreator='Ollivander family'
group by DepositGroup
--6
Select DepositGroup,Sum(DepositAmount) as TotalSum from WizzardDeposits as w
where MagicWandCreator='Ollivander family'
group by DepositGroup
having Sum(DepositAmount)<150000
order by TotalSum desc
--7
select DepositGroup,MagicWandCreator,Min(DepositCharge)as MinDepCharge 
from WizzardDeposits
group by DepositGroup,MagicWandCreator
order by MagicWandCreator,DepositGroup
--8
Select Case
When Age between 0 and 10 Then '[0-10]'
When Age between 11 and 20 Then '[11-20]'
When Age between 21 and 30 Then '[21-30]'
When Age between 31 and 40 Then '[31-40]'
When Age between 41 and 50 Then '[41-50]'
When Age between 51 and 60 Then '[51-60]'
When Age >= 60 Then '[61+]'
End as AgeGroup,COUNT(*)
 from WizzardDeposits
 group by Case
When Age between 0 and 10 Then '[0-10]'
When Age between 11 and 20 Then '[11-20]'
When Age between 21 and 30 Then '[21-30]'
When Age between 31 and 40 Then '[31-40]'
When Age between 41 and 50 Then '[41-50]'
When Age between 51 and 60 Then '[51-60]'
When Age >= 60 Then '[61+]'
End
--9
SELECT SUBSTRING(FirstName,1,1) AS FirstLetter
  FROM WizzardDeposits AS w
 WHERE DepositGroup = 'Troll Chest'
 GROUP BY SUBSTRING(FirstName,1,1)
ORDER BY FirstLetter ASC
--10
Select DepositGroup,IsDepositExpired,AVG(DepositInterest) as AverageInterest from WizzardDeposits
where DepositStartDate>'19850101'
group by DepositGroup,IsDepositExpired
order by DepositGroup desc, IsDepositExpired asc
--11
SELECT w.FirstName AS HostWizard
	  ,w.DepositAmount AS HostDeposit
	  ,LEAD(w.FirstName) OVER (ORDER BY w.ID) AS GuestWizard
	  ,LEAD(w.DepositAmount) OVER (ORDER BY w.ID) AS GuestDeposit
  INTO RichWizardPoorWizard
  FROM WizzardDeposits AS w

SELECT SUM(r.HostDeposit-r.GuestDeposit) AS SumDifference FROM RichWizardPoorWizard AS r
  DROP TABLE RichWizardPoorWizard

--12
select DepartmentID,SUM(Salary) as TotalSalary from Employees
group by DepartmentID
order by DepartmentID
--13
select DepartmentID,Min(Salary) as TotalSalary 
from Employees
where DepartmentID in (2,5,7) and HireDate> '20000101'
group by DepartmentID
order by DepartmentID
--14
select * 
INTO EmployeeAverageSalaries
from Employees
where Salary>30000
delete  from EmployeeAverageSalaries
where ManagerID=42
update EmployeeAverageSalaries 
set Salary+=5000
where DepartmentID=1 
select DepartmentID,AVg(Salary) from EmployeeAverageSalaries
group by DepartmentID
drop table EmployeeAverageSalaries
--15
select DepartmentID,Max(Salary)as MaxSalary from Employees
group by DepartmentID
having Max(Salary) NOT between 30000 and 70000
--16
select COUNT(Salary)as Count from Employees
where ManagerID is Null
--17
SELECT DISTINCT
	   DepartmentID
	  ,Salary
      ,DENSE_RANK() OVER (PARTITION BY DepartmentID ORDER BY Salary DESC) AS SalaryRank
  INTO SalaryRanks
  FROM [SoftUni].[dbo].[Employees] AS e

SELECT DepartmentID, Salary FROM SalaryRanks AS s
WHERE s.SalaryRank = 3

DROP TABLE SalaryRanks
--18
SELECT TOP 10
	e.[FirstName]
    ,e.[LastName] 
	,e.[DepartmentID]
FROM Employees AS e
INNER JOIN (SELECT [DepartmentID]
			    ,AVG([Salary]) AS AverageSalary
			FROM Employees
			GROUP BY [DepartmentID]) AS d
ON d.DepartmentID = e.DepartmentID
WHERE e.Salary > d.AverageSalary
ORDER BY e.[DepartmentID]
--19