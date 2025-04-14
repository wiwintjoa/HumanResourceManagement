IF (NOT EXISTS (SELECT *  FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND  TABLE_NAME = 'hr_Department'))
BEGIN
	CREATE TABLE [dbo].[hr_Department] (
		[Id]									INT IDENTITY (1, 1) NOT NULL,	
		[Name]									NVARCHAR (200) NOT NULL,		
		[Description]							NVARCHAR (500) NOT NULL,
		[LocationId]							INT NOT NULL,
		[CreatedBy]								NVARCHAR (56)  NOT NULL,
		[CreatedDateTime]						DATETIME2 (7)  NOT NULL,
		[LastModifiedBy]						NVARCHAR (56)  NOT NULL,
		[LastModifiedDateTime]					DATETIME2 (7)  NOT NULL,
		PRIMARY KEY CLUSTERED ([Id] ASC),
		CONSTRAINT [FK_hr_Department_hr_Location] FOREIGN KEY ([LocationId]) REFERENCES [hr_Location]([Id]) ON DELETE CASCADE,
	);
END
GO
