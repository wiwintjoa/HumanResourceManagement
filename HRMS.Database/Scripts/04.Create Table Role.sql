IF (NOT EXISTS (SELECT *  FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND  TABLE_NAME = 'hr_Role'))
BEGIN
	CREATE TABLE [dbo].[hr_Role] (
		[Id]									INT IDENTITY (1, 1) NOT NULL,	
		[Title]									NVARCHAR (200) NOT NULL,		
		[Description]							NVARCHAR (500) NOT NULL,
		[DepartmentId]							INT NOT NULL,
		[CreatedBy]								NVARCHAR (56)  NOT NULL,
		[CreatedDateTime]						DATETIME2 (7)  NOT NULL,
		[LastModifiedBy]						NVARCHAR (56)  NOT NULL,
		[LastModifiedDateTime]					DATETIME2 (7)  NOT NULL,
		PRIMARY KEY CLUSTERED ([Id] ASC),
		CONSTRAINT [FK_hr_Role_hr_Department] FOREIGN KEY ([DepartmentId]) REFERENCES [hr_Department]([Id]) ON DELETE CASCADE,
	);
END
GO
