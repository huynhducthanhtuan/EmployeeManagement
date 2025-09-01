CREATE TABLE Projects 
(
    ProjectId NVARCHAR(450) NOT NULL DEFAULT LOWER(NEWID()) PRIMARY KEY,
    ProjectName NVARCHAR(max) NOT NULL,
    StartDate DATE NOT NULL,
    EndDate DATE NULL,
    DepartmentId NVARCHAR(450) NOT NULL,
	CreatedDate datetime2(7) NOT NULL DEFAULT GETDATE(),
	UpdatedDate datetime2(7) NULL,
	IsDeleted bit NOT NULL DEFAULT 0,
	FOREIGN KEY (DepartmentId) REFERENCES Departments(DepartmentId)
);