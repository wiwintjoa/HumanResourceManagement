IF (NOT EXISTS (SELECT *  FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND  TABLE_NAME = 'hr_JobHistory'))
BEGIN
	CREATE TABLE [dbo].[hr_JobHistory] (
		[Id]									INT IDENTITY (1, 1) NOT NULL,	
		[EmployeeId]							INT NOT NULL,		
		[Manager]								NVARCHAR (500) NOT NULL,
		[RoleId]								INT NOT NULL,
		[StartDate]								DATETIME2 (7)  NOT NULL,
		[EndDate]								DATETIME2 (7)  NOT NULL,
		[Status]								NVARCHAR (20)  NOT NULL,
		[Comments]								NVARCHAR(MAX)  NULL,
		[CreatedBy]								NVARCHAR (56)  NOT NULL,
		[CreatedDateTime]						DATETIME2 (7)  NOT NULL,
		[LastModifiedBy]						NVARCHAR (56)  NOT NULL,
		[LastModifiedDateTime]					DATETIME2 (7)  NOT NULL,
		PRIMARY KEY CLUSTERED ([Id] ASC),
		CONSTRAINT [FK_hr_JobHistory_hr_Employee] FOREIGN KEY ([EmployeeId]) REFERENCES [hr_Employee]([Id]) ON DELETE CASCADE,
		CONSTRAINT [FK_hr_JobHistory_hr_Role] FOREIGN KEY ([RoleId]) REFERENCES [hr_Role]([Id]) ON DELETE CASCADE,
	);
END
GO
