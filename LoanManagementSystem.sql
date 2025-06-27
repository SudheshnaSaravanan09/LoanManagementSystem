create database LoanManagementSystem

create table Customers
(CustomerId int identity Primary key,
Name varchar(100),
Email varchar(100),
PhoneNumber varchar(100),
Address varchar(100),
CreditScore int
)

create table Loans
(LoanId int identity(101,1) Primary key,
CustomerId int foreign key references Customers(CustomerId),
PrincipalAmount decimal,
InterestRate decimal,
LoanTerm int,
LoanType varchar(100),
LoanStatus varchar(100)
)

insert into Customers values ('Arjun','arjun@gmail.com','8795421587','14, 123 Street, Chennai',690),
('Amanda','amanda@gmail.com','6987985421','3/B, Vermont Street, Banglore',450),
('Zarah','zarah@gmail.com','7842530019','21, Formenta Avenue, Chennai',700),
('Jay','jay@gmail.com','6548226974','15/A, 345 Street, Banglore',290)

insert into Loans values(3,500000,3,24,'HouseLoan','Pending'),
(1,50000,2,6,'CarLoan','Approved'),
(3,35000,4,3,'CarLoan','Approved'),
(4,100000,4,18,'HouseLoan','Pending'),
(2,80000,5,12,'CarLoan','Approved')

select * from Customers
select * from Loans