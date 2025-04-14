IF (NOT EXISTS (SELECT *  FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND  TABLE_NAME = 'hr_Location'))
BEGIN
	CREATE TABLE [dbo].[hr_Location] (
		[Id]									INT IDENTITY (1, 1) NOT NULL,	
		[Name]									NVARCHAR (200) NOT NULL,		
		[City]									NVARCHAR (200) NOT NULL,
		[Country]								NVARCHAR (200) NOT NULL,
		[CreatedBy]								NVARCHAR (56)  NOT NULL,
		[CreatedDateTime]						DATETIME2 (7)  NOT NULL,
		[LastModifiedBy]						NVARCHAR (56)  NOT NULL,
		[LastModifiedDateTime]					DATETIME2 (7)  NOT NULL,
		PRIMARY KEY CLUSTERED ([Id] ASC),
	);
END
GO
