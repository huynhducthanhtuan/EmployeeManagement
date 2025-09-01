CREATE TABLE Employees
(
	EmployeeId nvarchar(450) NOT NULL DEFAULT LOWER(NEWID())  PRIMARY KEY,
	FullName nvarchar(max) NOT NULL,
	Gender nvarchar(max) NOT NULL DEFAULT 'Other',
	DateOfBirth datetime2(7) NOT NULL,
	Hometown nvarchar(max) NOT NULL,
	AvatarImage nvarchar(max) NULL DEFAULT NULL,
    DepartmentId NVARCHAR(450) NOT NULL,
	PositionId NVARCHAR(450) NOT NULL,
	CreatedDate datetime2(7) NOT NULL DEFAULT GETDATE(),
	UpdatedDate datetime2(7) NULL,
	IsDeleted bit NOT NULL DEFAULT 0,
	FOREIGN KEY (DepartmentId) REFERENCES Departments (DepartmentId),
	FOREIGN KEY (PositionId) REFERENCES Positions (PositionId)
);