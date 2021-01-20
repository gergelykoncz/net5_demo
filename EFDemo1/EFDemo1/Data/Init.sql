CREATE DATABASE ProductTest
GO

USE ProductTest
GO

CREATE TABLE Products (
ID int PRIMARY KEY IDENTITY(1,1),
Name nvarchar(255),
Price decimal(16,2)
)

INSERT INTO Products (Name, Price)
VALUES 
('Baseball bat', 30.0),
('Yoga mat', 15.0),
('10kg dumbbells', 45.0),
('Running shoes', 30.0),
('Protein bar', 2.0)