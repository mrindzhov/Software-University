select * from Departments
---2
select Name from Departments
---3
select FirstName,LastName,Salary from Employees
---4
select FirstName,MiddleName,LastName from Employees
---5
select FirstName+'.'+LastName+'@softuni.bg'as 'Full Email Adress' from Employees 
---6
select distinct Salary from Employees 
---7
select * from Employees 
where JobTitle='Sales Representative'
---8
select FirstName,LastName,JobTitle from Employees 
where Salary>=20000 and Salary<=30000
---9
select FirstName+' '+MiddleName+' '+LastName as 'Full Name' from Employees 
where Salary in (25000, 14000, 12500,23600)
---10
select FirstName,LastName from Employees 
where ManagerID is NULL
---11
select FirstName,LastName,Salary from Employees 
where Salary>=50000 order by Salary desc
---12
select top(5) FirstName,LastName from Employees 
order by Salary desc
---13
select FirstName,LastName from Employees 
where DepartmentID!=4
---14
select*from Employees 
order by Salary desc,FirstName asc,LastName desc,MiddleName asc
---15
create view V_EmployeesSalaries as 
select FirstName,LastName,Salary from Employees
SELECT * FROM V_EmployeesSalaries
---16
create view V_EmployeeNameJobTitle  as 
select FirstName+' '+Isnull(MiddleName,'') +' '+LastName as 'Full Name',JobTitle from Employees 
SELECT * FROM V_EmployeeNameJobTitle
---17
Select distinct JobTitle from Employees
---18
select top(10) * from Projects order by StartDate, Name
---19
select top(7) FirstName,LastName,HireDate from Employees order by HireDate desc
---20
update Employees 
set Salary=Salary*1.12
where DepartmentId in (select DepartmentID 
from Departments where Name in('Engineering','Tool Design','Marketing','Information Services'))
select Salary from Employees 
---21
Select PeakName from Peaks order by PeakName asc
---22
Select Top(30) CountryName,Population from Countries 
where ContinentCode='EU'
order by Population desc
---23
select CountryName,CountryCode,CASE CurrencyCode
    WHEN 'EUR' THEN 'Euro' 
    ELSE 'Not Euro' 
	End  from Countries order by CountryName
---24
SELECT Name FROM Characters order by Name 
---25