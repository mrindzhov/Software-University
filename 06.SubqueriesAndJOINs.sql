select top 5 EmployeeID,JobTitle,e.AddressID,a.AddressText from Employees as e 
inner join Addresses as a
on e.AddressID=a.AddressID
order by AddressID
--1
select top 50 e.FirstName,e.LastName,t.Name as Town,a.AddressText 
from Employees as e 
	join Addresses as a on e.AddressID=a.AddressID
	join Towns as t on a.TownID=t.TownID
order by e.FirstName,e.LastName ASC
--2
select e.EmployeeID,e.FirstName,e.LastName,d.Name as DepartmentName
from Employees as e 
	join Departments as d on e.DepartmentID=d.DepartmentID
where d.Name= 'Sales'
order by e.EmployeeID
--3
select top 5 e.EmployeeID,e.FirstName,e.Salary,d.Name as DepartmentName
from Employees as e 
	join Departments as d on e.DepartmentID=d.DepartmentID
where e.Salary>15000
order by e.DepartmentID
--4
select top 3 e.EmployeeID,e.FirstName
from Employees as e 
left outer join EmployeesProjects as p on e.EmployeeID=p.EmployeeID
where p.EmployeeID is Null
--5
select e.FirstName,e.LastName,e.HireDate,d.Name as DepartmentName
from Employees as e 
	join Departments as d on e.DepartmentID=d.DepartmentID
where e.HireDate>'1999' and d.Name in('Sales','Finance') 
order by e.DepartmentID
--6
select top 5 e.EmployeeID,e.FirstName,p.Name from Employees as e 
left outer join EmployeesProjects as ep on e.EmployeeID=ep.EmployeeID
left outer join Projects as p on p.ProjectID=ep.ProjectID
where p.StartDate>'20020813' AND p.EndDate is NULL
order by e.EmployeeID
--7
select e.EmployeeID,e.FirstName,p.Name from Employees as e 
left outer join EmployeesProjects as ep on e.EmployeeID=ep.EmployeeID
left outer join Projects as p on p.ProjectID=ep.ProjectID and p.StartDate<'2005'
where e.EmployeeID=24 
--8
SELECT 
	    e1.EmployeeID
	   ,e1.FirstName
	   ,e1.ManagerID
	   ,e2.FirstName
   FROM Employees AS e1
   LEFT OUTER JOIN Employees AS e2
     ON e1.ManagerID = e2.EmployeeID
  WHERE e1.ManagerID = 3
     OR e1.ManagerID = 7
  ORDER BY e1.EmployeeID
--9
SELECT top 50
	    e1.EmployeeID
	   ,e1.FirstName+' '+e1.LastName as EmployeeName
	   ,e2.FirstName+' '+e2.LastName as ManagerName
	   ,d.Name as DepartmentName
   FROM Employees AS e1
   LEFT OUTER JOIN Employees AS e2
     ON e1.ManagerID = e2.EmployeeID
   LEFT OUTER JOIN Departments AS d
	ON e1.DepartmentID=d.DepartmentID
  ORDER BY e1.EmployeeID
  --10
select MIN(a.av) as MinAverageSalary from (
select DepartmentID,AVG(Salary) as av from Employees
group by DepartmentID) as a
--11
SELECT c.CountryCode,m.MountainRange,p.PeakName,p.Elevation
	FROM Countries as c
inner join MountainsCountries as mc 
	on mc.CountryCode=c.CountryCode
inner join Mountains as m 
	on mc.MountainId=m.Id
inner join Peaks as p 
	on m.Id=p.MountainId
	where mc.CountryCode='BG'
	and p.Elevation>2835
order by p.Elevation Desc
--12
SELECT c.CountryCode,COUNT(m.MountainRange) as MountainRanges
	FROM Countries as c
inner join MountainsCountries as mc 
	on mc.CountryCode=c.CountryCode
inner join Mountains as m 
	on mc.MountainId=m.Id
	where c.CountryCode in ('US','RU','BG')
	group by c.CountryCode
--13
SELECT top 5 c.CountryName,r.RiverName
FROM Countries as c
left join CountriesRivers as cr 
	on cr.CountryCode=c.CountryCode
left join Rivers as r 
	on cr.RiverId=r.Id
	where c.ContinentCode='AF'
	order by c.CountryName
--14 
SELECT usages.ContinentCode, usages.CurrencyCode, usages.Usages FROM
(
SELECT con.ContinentCode, cu.CurrencyCode, COUNT(cu.CurrencyCode) AS Usages FROM Continents AS con
	INNER JOIN Countries AS c ON c.ContinentCode = con.ContinentCode
	INNER JOIN Currencies AS cu ON cu.CurrencyCode = c.CurrencyCode
GROUP BY con.ContinentCode, cu.CurrencyCode
) AS usages
	INNER JOIN (SELECT usages.ContinentCode, MAX(usages.Usages) AS maxUsage FROM 
		(
		SELECT con.ContinentCode, cu.CurrencyCode, COUNT(cu.CurrencyCode) AS Usages FROM Continents AS con
			INNER JOIN Countries AS c ON c.ContinentCode = con.ContinentCode
			INNER JOIN Currencies AS cu ON cu.CurrencyCode = c.CurrencyCode
		GROUP BY con.ContinentCode, cu.CurrencyCode
		HAVING COUNT(cu.CurrencyCode) > 1
		) as usages
		GROUP BY usages.ContinentCode
	) AS maxUsages ON maxUsages.ContinentCode = usages.ContinentCode AND maxUsages.maxUsage = usages.Usages
ORDER BY usages.ContinentCode
--15
SELECT cu.ContinentCode, cu.CurrencyCode, cu.Usages FROM
(
	SELECT 
	con.ContinentCode, 
	cu.CurrencyCode, 
	COUNT(cu.CurrencyCode) AS Usages,
	DENSE_RANK() OVER(PARTITION BY(con.ContinentCode) 
	ORDER BY COUNT(cu.CurrencyCode) DESC) AS Rank
	FROM Continents AS con
		INNER JOIN Countries AS c 
		ON c.ContinentCode = con.ContinentCode
		INNER JOIN Currencies AS cu 
		ON cu.CurrencyCode = c.CurrencyCode
	GROUP BY con.ContinentCode, cu.CurrencyCode
	HAVING COUNT(cu.CurrencyCode) > 1
) AS cu
WHERE cu.Rank = 1
--15 -2
SELECT COUNT(CountryCode) AS CountryCode FROM Countries
WHERE CountryCode NOT IN (SELECT DISTINCT CountryCode
							FROM MountainsCountries)
--16
SELECT top 5 c.CountryName,MAX(p.Elevation) as HighestPeakElevation,MAX(r.Length) as LongestRiverLength FROM Countries as c
LEFT JOIN MountainsCountries as mc on mc.CountryCode=c.CountryCode
LEFT JOIN Peaks as p on p.MountainId= mc.MountainId
LEFT JOIN CountriesRivers as cr on c.CountryCode=cr.CountryCode
LEFT JOIN Rivers as r on cr.RiverId=r.Id
GROUP BY c.CountryName
ORDER BY HighestPeakElevation DESC,LongestRiverLength DESC
--17
SELECT TOP 5 *
FROM (
			SELECT
			  c.CountryName AS [Country],
			  p.PeakName AS [Highest Peak Name],
			  p.Elevation AS [Highest Peak Elevation],
			  m.MountainRange AS [Mountain]
			FROM
			  Countries c
			  LEFT JOIN MountainsCountries mc ON c.CountryCode = mc.CountryCode
			  LEFT JOIN Mountains m ON m.Id = mc.MountainId
			  LEFT JOIN Peaks p ON p.MountainId = m.Id
			WHERE p.Elevation =
			  (SELECT MAX(p.Elevation)
			   FROM MountainsCountries mc
				 LEFT JOIN Mountains m ON m.Id = mc.MountainId
				 LEFT JOIN Peaks p ON p.MountainId = m.Id
			   WHERE c.CountryCode = mc.CountryCode)
			UNION
			SELECT
			  c.CountryName AS [Country],
			  '(no highest peak)' AS [Highest Peak Name],
			  0 AS [Highest Peak Elevation],
			  '(no mountain)' AS [Mountain]
			FROM
			  Countries c
			  LEFT JOIN MountainsCountries mc ON c.CountryCode = mc.CountryCode
			  LEFT JOIN Mountains m ON m.Id = mc.MountainId
			  LEFT JOIN Peaks p ON p.MountainId = m.Id
			WHERE 
			  (SELECT MAX(p.Elevation)
			   FROM MountainsCountries mc
				 LEFT JOIN Mountains m ON m.Id = mc.MountainId
				 LEFT JOIN Peaks p ON p.MountainId = m.Id
			   WHERE c.CountryCode = mc.CountryCode) IS NULL
   ) AS c
ORDER BY Country, [Highest Peak Name]
--18
SELECT TOP 5
pk.CountryName,  
CASE
WHEN pk.PeakName IS NULL THEN '(no highest peak)'
ELSE pk.PeakName
END AS PeakName, 
CASE
WHEN pk.Elevation IS NULL THEN 0
ELSE pk.Elevation
END AS Elevation,
CASE
WHEN pk.MountainRange IS NULL THEN '(no mountain)'
ELSE pk.MountainRange
END AS MountainRange FROM (
							SELECT 
								c.CountryName, 
								p.PeakName,
								p.Elevation,
								m.MountainRange,
								DENSE_RANK() OVER (PARTITION BY c.CountryName ORDER BY p.Elevation DESC) AS Rank
							FROM Countries AS c
							LEFT JOIN MountainsCountries AS mc ON mc.CountryCode = c.CountryCode
							LEFT JOIN Mountains AS m ON m.Id = mc.MountainId
							LEFT JOIN Peaks AS p ON p.MountainId = mc.MountainId
						  ) AS pk
WHERE pk.Rank = 1
ORDER BY pk.CountryName, pk.PeakName
--18-2