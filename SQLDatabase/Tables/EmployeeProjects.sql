CREATE TABLE EmployeeProjects 
(
    EmployeeId NVARCHAR(450) NOT NULL,
    ProjectId NVARCHAR(450) NOT NULL,
    PositionId NVARCHAR(450) NOT NULL,
    AssignedDate DATE NOT NULL DEFAULT LOWER(NEWID()),
	CreatedDate datetime2(7) NOT NULL DEFAULT GETDATE(),
	UpdatedDate datetime2(7) NULL,
	IsDeleted bit NOT NULL DEFAULT 0,
	PRIMARY KEY (EmployeeId, ProjectID),
    FOREIGN KEY (EmployeeId) REFERENCES Employees(EmployeeId),
    FOREIGN KEY (ProjectId) REFERENCES Projects(ProjectId),
    FOREIGN KEY (PositionId) REFERENCES Positions(PositionId)
);