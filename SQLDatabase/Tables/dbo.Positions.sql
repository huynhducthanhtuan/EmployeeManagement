CREATE TABLE Positions 
(
    PositionId NVARCHAR(450) NOT NULL DEFAULT LOWER(NEWID()) PRIMARY KEY,
    PositionName NVARCHAR(max) NOT NULL,
    Description NVARCHAR(max),
	CreatedDate datetime2(7) NOT NULL DEFAULT GETDATE(),
	UpdatedDate datetime2(7) NULL,
	IsDeleted bit NOT NULL DEFAULT 0
);