IF (NOT EXISTS (SELECT *  FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND  TABLE_NAME = 'hr_Employee'))
BEGIN
	CREATE TABLE [dbo].[hr_Employee] (
		[Id]									INT IDENTITY (1, 1) NOT NULL,	
		[Name]									NVARCHAR (200) NOT NULL,		
		[BirthDate]								DATETIME2 (7)  NOT NULL,
		[Phone]									NVARCHAR (50) NOT NULL,
		[Email]									NVARCHAR (200) NOT NULL,
		[Gender]								NVARCHAR (10) NOT NULL,
		[Address]								NVARCHAR (500) NOT NULL,	
		[Status]								NVARCHAR (20) NOT NULL,
		[CreatedBy]								NVARCHAR (56)  NOT NULL,
		[CreatedDateTime]						DATETIME2 (7)  NOT NULL,
		[LastModifiedBy]						NVARCHAR (56)  NOT NULL,
		[LastModifiedDateTime]					DATETIME2 (7)  NOT NULL,
		PRIMARY KEY CLUSTERED ([Id] ASC),
	);
END
GO
