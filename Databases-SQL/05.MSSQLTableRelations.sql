CREATE TABLE Passports(
PassportID INT PRIMARY KEY,
PassportNumber VARCHAR(50)
)
CREATE TABLE Persons(
PersonID INT PRIMARY KEY,
FirstName VARCHAR(50),
Salary DECIMAL(8,2),
PassportID INT
constraint Fk_Persons_Passport 
foreign key (PassportID)
references Passports(PassportID)
)
INSERT INTO Passports(PassportID, PassportNumber)
VALUES
(101, 'N34FG21B'),
(102, 'K65LO4R7'),
(103, 'ZE657QP2')
INSERT INTO Persons(PersonID, FirstName, Salary, PassportID)
VALUES
(1, 'Roberto', 43300.00, 102),
(2, 'Tom', 56100.00, 103),
(3, 'Yana', 60200.00, 101)
--1
select m.MountainRange,p.PeakName,p.Elevation 
	from Mountains as m
	join Peaks as p on
	p.MountainId=m.Id
	where m.MountainRange='Rila'
	order by Elevation desc
--9
CREATE TABLE Manufacturers(
ManufacturerID INT PRIMARY KEY,
Name VARCHAR(50),
EstablishedOn DATE
)
CREATE TABLE Models(
ModelID INT PRIMARY KEY,
Name VARCHAR(50),
ManufacturerID INT,
constraint Fk_Models_ManufacturerId 
foreign key (ManufacturerId)
references Manufacturers(ManufacturerId)
)
INSERT INTO Manufacturers (ManufacturerID, Name, EstablishedOn)
VALUES
(1, 'BMW', '07/03/1916'),
(2, 'Tesla', '01/01/2003'),
(3, 'Lada', '01/05/1966')
INSERT INTO Models(ModelID, Name, ManufacturerID)
VALUES
(101, 'X1', 1),
(102, 'i6', 1),
(103, 'Model S', 2),
(104, 'Model X', 2),
(105, 'Model 3', 2),
(106, 'Nova', 3)
--2
CREATE TABLE Students(
StudentID INT PRIMARY KEY,
Name VARCHAR(50),
)
CREATE TABLE Exams(
ExamID INT PRIMARY KEY,
Name VARCHAR(50)
)
CREATE TABLE StudentsExams(
StudentID INT,
ExamID INT,
constraint Pk_StudentsExams primary key (StudentID,ExamID),
constraint Fk_StudentsExams_Students foreign key (StudentID) references Students(StudentID),
constraint Fk_StudentsExams_Exams foreign key (ExamID) references Exams(ExamID)
)
INSERT INTO Students(StudentID, Name)
VALUES
(1, 'Mila'),                                     
(2, 'Toni'),
(3, 'Ron')
INSERT INTO Exams(ExamID, Name)
VALUES 
(101, 'Spring MVC'),
(102, 'Neo4j'),
(103, 'Oracle 11g')
INSERT INTO StudentsExams(StudentID, ExamID)
VALUES
(1, 101),
(1, 102),
(2, 101),
(3, 103),
(2, 102),
(2, 103)
--3
CREATE TABLE Teachers(
TeacherID INT PRIMARY KEY,
Name VARCHAR(50),
ManagerID INT,
CONSTRAINT FK_Teachers_Teachers FOREIGN KEY(ManagerID) REFERENCES Teachers(TeacherID)
)
INSERT INTO Teachers(TeacherID, Name, ManagerID)
VALUES
(101, 'John', NULL),
(102, 'Maya', 106),
(103, 'Silvia', 106),
(104, 'Ted', 105),
(105, 'Mark', 101),
(106, 'Greta', 101)	
--4
CREATE TABLE Cities(
	CityID int,
	Name varchar(50),
 CONSTRAINT PK_Cities PRIMARY KEY (CityID)
 )
CREATE TABLE Customers(
	CustomerID int,
	Name varchar(50),
	Birthday date,
	CityID int,
 CONSTRAINT PK_Customers PRIMARY KEY(CustomerID)
 )
CREATE TABLE Items(
	ItemID int,
	Name varchar(50),
	ItemTypeID int,
 CONSTRAINT PK_Items PRIMARY KEY (ItemID)
)
CREATE TABLE ItemTypes(
	ItemTypeID int,
	Name varchar(50),
 CONSTRAINT PK_ItemTypes PRIMARY KEY (ItemTypeID)
 )
CREATE TABLE OrderItems(
	OrderID int,
	ItemID int,
 CONSTRAINT PK_OrderItems PRIMARY KEY (OrderID,ItemID)
 )
CREATE TABLE Orders(
	OrderID int,
	CustomerID int,
 CONSTRAINT PK_Orders PRIMARY KEY (OrderID)
 ) 
ALTER TABLE Customers ADD CONSTRAINT FK_Customers_Cities FOREIGN KEY(CityID)
REFERENCES Cities (CityID)
ALTER TABLE Items ADD CONSTRAINT FK_Items_ItemTypes FOREIGN KEY(ItemTypeID)
REFERENCES ItemTypes (ItemTypeID)
ALTER TABLE OrderItems ADD CONSTRAINT FK_OrderItems_Items FOREIGN KEY(ItemID)
REFERENCES Items (ItemID)
ALTER TABLE OrderItems  ADD CONSTRAINT FK_OrderItems_Orders FOREIGN KEY(OrderID)
REFERENCES Orders (OrderID)
ALTER TABLE Orders ADD CONSTRAINT FK_Orders_Customers FOREIGN KEY(CustomerID)
REFERENCES Customers (CustomerID)
--5
