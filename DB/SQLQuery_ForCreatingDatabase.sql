CREATE DATABASE MVCWebAPIApp

CREATE TABLE Employee (ID int PRIMARY KEY IDENTITY(1,1), FirstName varchar(20),
LastName varchar(20), ContactNumber varchar(10), Address varchar(50),
JoiningDate DATETIME DEFAULT(GETDATE()), IsActive BIT DEFAULT(1))

INSERT INTO Employee (FirstName, LastName, ContactNumber, Address)
VALUES ('Bart','Doe','90909090','Test Address1')
INSERT INTO Employee (FirstName, LastName, ContactNumber, Address)
VALUES ('Dan','Zalorings','70707070','Test Address2')
INSERT INTO Employee (FirstName, LastName, ContactNumber, Address)
VALUES ('Emily','Leroy','50505050','Test Address3')
