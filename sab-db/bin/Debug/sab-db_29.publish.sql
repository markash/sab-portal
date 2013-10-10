﻿/*
Deployment script for sab-db

This code was generated by a tool.
Changes to this file may cause incorrect behavior and will be lost if
the code is regenerated.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "sab-db"
:setvar DefaultFilePrefix "sab-db"
:setvar DefaultDataPath "C:\SDE\data\MSSQL10_50.SQLSERVER2008R2\MSSQL\DATA\"
:setvar DefaultLogPath "C:\SDE\data\MSSQL10_50.SQLSERVER2008R2\MSSQL\DATA\"

GO
:on error exit
GO
/*
Detect SQLCMD mode and disable script execution if SQLCMD mode is not supported.
To re-enable the script after enabling SQLCMD mode, execute the following:
SET NOEXEC OFF; 
*/
:setvar __IsSqlCmdEnabled "True"
GO
IF N'$(__IsSqlCmdEnabled)' NOT LIKE N'True'
    BEGIN
        PRINT N'SQLCMD mode must be enabled to successfully execute this script.';
        SET NOEXEC ON;
    END


GO
USE [master];


GO

IF (DB_ID(N'$(DatabaseName)') IS NOT NULL) 
BEGIN
    ALTER DATABASE [$(DatabaseName)]
    SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE [$(DatabaseName)];
END

GO
PRINT N'Creating $(DatabaseName)...'
GO
CREATE DATABASE [$(DatabaseName)]
    ON 
    PRIMARY(NAME = [$(DatabaseName)], FILENAME = N'$(DefaultDataPath)$(DefaultFilePrefix)_Primary.mdf')
    LOG ON (NAME = [$(DatabaseName)_log], FILENAME = N'$(DefaultLogPath)$(DefaultFilePrefix)_Primary.ldf') COLLATE SQL_Latin1_General_CP1_CI_AS
GO
PRINT N'Creating [FileStreamFileGroup]...';


GO
ALTER DATABASE [$(DatabaseName)]
    ADD FILEGROUP [FileStreamFileGroup] CONTAINS FILESTREAM;


GO
ALTER DATABASE [$(DatabaseName)]
    ADD FILE (NAME = [FileStreamFileGroup_59FAD3CF], FILENAME = N'$(DefaultDataPath)$(DefaultFilePrefix)_FileStreamFileGroup_59FAD3CF.mdf') TO FILEGROUP [FileStreamFileGroup];


GO
IF (SELECT is_default
    FROM   [$(DatabaseName)].[sys].[filegroups]
    WHERE  [name] = N'FileStreamFileGroup') = 0
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            MODIFY FILEGROUP [FileStreamFileGroup] DEFAULT;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET ANSI_NULLS ON,
                ANSI_PADDING ON,
                ANSI_WARNINGS ON,
                ARITHABORT ON,
                CONCAT_NULL_YIELDS_NULL ON,
                NUMERIC_ROUNDABORT OFF,
                QUOTED_IDENTIFIER ON,
                ANSI_NULL_DEFAULT ON,
                CURSOR_DEFAULT LOCAL,
                RECOVERY FULL,
                CURSOR_CLOSE_ON_COMMIT OFF,
                AUTO_CREATE_STATISTICS ON,
                AUTO_SHRINK OFF,
                AUTO_UPDATE_STATISTICS ON,
                RECURSIVE_TRIGGERS OFF 
            WITH ROLLBACK IMMEDIATE;
        ALTER DATABASE [$(DatabaseName)]
            SET AUTO_CLOSE OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET ALLOW_SNAPSHOT_ISOLATION OFF;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET READ_COMMITTED_SNAPSHOT OFF;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET AUTO_UPDATE_STATISTICS_ASYNC OFF,
                PAGE_VERIFY NONE,
                DATE_CORRELATION_OPTIMIZATION OFF,
                DISABLE_BROKER,
                PARAMETERIZATION SIMPLE,
                SUPPLEMENTAL_LOGGING OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF IS_SRVROLEMEMBER(N'sysadmin') = 1
    BEGIN
        IF EXISTS (SELECT 1
                   FROM   [master].[dbo].[sysdatabases]
                   WHERE  [name] = N'$(DatabaseName)')
            BEGIN
                EXECUTE sp_executesql N'ALTER DATABASE [$(DatabaseName)]
    SET TRUSTWORTHY OFF,
        DB_CHAINING OFF 
    WITH ROLLBACK IMMEDIATE';
            END
    END
ELSE
    BEGIN
        PRINT N'The database settings cannot be modified. You must be a SysAdmin to apply these settings.';
    END


GO
IF IS_SRVROLEMEMBER(N'sysadmin') = 1
    BEGIN
        IF EXISTS (SELECT 1
                   FROM   [master].[dbo].[sysdatabases]
                   WHERE  [name] = N'$(DatabaseName)')
            BEGIN
                EXECUTE sp_executesql N'ALTER DATABASE [$(DatabaseName)]
    SET HONOR_BROKER_PRIORITY OFF 
    WITH ROLLBACK IMMEDIATE';
            END
    END
ELSE
    BEGIN
        PRINT N'The database settings cannot be modified. You must be a SysAdmin to apply these settings.';
    END


GO
USE [$(DatabaseName)];


GO
IF fulltextserviceproperty(N'IsFulltextInstalled') = 1
    EXECUTE sp_fulltext_database 'enable';


GO
PRINT N'Creating [dbo].[brand]...';


GO
CREATE TABLE [dbo].[brand] (
    [brand_id]          INT          IDENTITY (1, 1) NOT NULL,
    [brand_description] VARCHAR (50) NOT NULL,
    [active]            BIT          NULL,
    [create_ts]         DATETIME     NULL,
    [update_ts]         DATETIME     NULL,
    PRIMARY KEY CLUSTERED ([brand_id] ASC)
);


GO
PRINT N'Creating [dbo].[campaign]...';


GO
CREATE TABLE [dbo].[campaign] (
    [campaign_id]      INT           IDENTITY (1, 1) NOT NULL,
    [category_id]      INT           NOT NULL,
    [territory_id]     INT           NOT NULL,
    [campaign_type_id] INT           NOT NULL,
    [country_id]       INT           NOT NULL,
    [brand_id]         INT           NOT NULL,
    [title]            VARCHAR (255) NOT NULL,
    [username]         VARCHAR (255) NOT NULL,
    [create_ts]        DATETIME      NULL,
    [update_ts]        DATETIME      NULL,
    PRIMARY KEY CLUSTERED ([campaign_id] ASC)
);


GO
PRINT N'Creating [dbo].[campaign_document]...';


GO
CREATE TABLE [dbo].[campaign_document] (
    [id]             UNIQUEIDENTIFIER           ROWGUIDCOL NOT NULL,
    [document]       VARBINARY (MAX) FILESTREAM NULL,
    [content_length] INT                        NULL,
    [content_type]   VARCHAR (255)              NOT NULL,
    [file_name]      VARCHAR (512)              NOT NULL,
    [campaign_id]    INT                        NOT NULL,
    UNIQUE NONCLUSTERED ([id] ASC)
);


GO
PRINT N'Creating [dbo].[campaign_type]...';


GO
CREATE TABLE [dbo].[campaign_type] (
    [campaign_type_id]          INT          IDENTITY (1, 1) NOT NULL,
    [campaign_type_description] VARCHAR (50) NOT NULL,
    [active]                    BIT          NULL,
    [create_ts]                 DATETIME     NULL,
    [update_ts]                 DATETIME     NULL,
    PRIMARY KEY CLUSTERED ([campaign_type_id] ASC)
);


GO
PRINT N'Creating [dbo].[category]...';


GO
CREATE TABLE [dbo].[category] (
    [category_id]          INT          IDENTITY (1, 1) NOT NULL,
    [category_description] VARCHAR (50) NOT NULL,
    [active]               BIT          NULL,
    [create_ts]            DATETIME     NULL,
    [update_ts]            DATETIME     NULL,
    PRIMARY KEY CLUSTERED ([category_id] ASC)
);


GO
PRINT N'Creating [dbo].[country]...';


GO
CREATE TABLE [dbo].[country] (
    [country_id]          INT          IDENTITY (1, 1) NOT NULL,
    [country_description] VARCHAR (50) NOT NULL,
    [active]              BIT          NULL,
    [create_ts]           DATETIME     NULL,
    [update_ts]           DATETIME     NULL,
    PRIMARY KEY CLUSTERED ([country_id] ASC)
);


GO
PRINT N'Creating [dbo].[territory]...';


GO
CREATE TABLE [dbo].[territory] (
    [territory_id]          INT          IDENTITY (1, 1) NOT NULL,
    [territory_description] VARCHAR (50) NOT NULL,
    [active]                BIT          NULL,
    [create_ts]             DATETIME     NULL,
    [update_ts]             DATETIME     NULL,
    PRIMARY KEY CLUSTERED ([territory_id] ASC)
);


GO
PRINT N'Creating [dbo].[usage]...';


GO
CREATE TABLE [dbo].[usage] (
    [usage_id]      INT           IDENTITY (1, 1) NOT NULL,
    [username]      VARCHAR (255) NOT NULL,
    [usage_type_id] INT           NOT NULL,
    [active]        BIT           NULL,
    [create_ts]     DATETIME      NULL,
    [update_ts]     DATETIME      NULL,
    PRIMARY KEY CLUSTERED ([usage_id] ASC)
);


GO
PRINT N'Creating [dbo].[usage_type]...';


GO
CREATE TABLE [dbo].[usage_type] (
    [usage_type_id]          INT          IDENTITY (1, 1) NOT NULL,
    [usage_type_description] VARCHAR (50) NOT NULL,
    [active]                 BIT          NULL,
    [create_ts]              DATETIME     NULL,
    [update_ts]              DATETIME     NULL,
    PRIMARY KEY CLUSTERED ([usage_type_id] ASC)
);


GO
PRINT N'Creating Default Constraint on [dbo].[brand]....';


GO
ALTER TABLE [dbo].[brand]
    ADD DEFAULT (1) FOR [active];


GO
PRINT N'Creating Default Constraint on [dbo].[brand]....';


GO
ALTER TABLE [dbo].[brand]
    ADD DEFAULT GETDATE() FOR [create_ts];


GO
PRINT N'Creating Default Constraint on [dbo].[campaign]....';


GO
ALTER TABLE [dbo].[campaign]
    ADD DEFAULT (0) FOR [category_id];


GO
PRINT N'Creating Default Constraint on [dbo].[campaign]....';


GO
ALTER TABLE [dbo].[campaign]
    ADD DEFAULT GETDATE() FOR [create_ts];


GO
PRINT N'Creating Default Constraint on [dbo].[campaign_document]....';


GO
ALTER TABLE [dbo].[campaign_document]
    ADD DEFAULT NEWID() FOR [id];


GO
PRINT N'Creating Default Constraint on [dbo].[campaign_type]....';


GO
ALTER TABLE [dbo].[campaign_type]
    ADD DEFAULT (1) FOR [active];


GO
PRINT N'Creating Default Constraint on [dbo].[campaign_type]....';


GO
ALTER TABLE [dbo].[campaign_type]
    ADD DEFAULT GETDATE() FOR [create_ts];


GO
PRINT N'Creating Default Constraint on [dbo].[category]....';


GO
ALTER TABLE [dbo].[category]
    ADD DEFAULT (1) FOR [active];


GO
PRINT N'Creating Default Constraint on [dbo].[category]....';


GO
ALTER TABLE [dbo].[category]
    ADD DEFAULT GETDATE() FOR [create_ts];


GO
PRINT N'Creating Default Constraint on [dbo].[country]....';


GO
ALTER TABLE [dbo].[country]
    ADD DEFAULT (1) FOR [active];


GO
PRINT N'Creating Default Constraint on [dbo].[country]....';


GO
ALTER TABLE [dbo].[country]
    ADD DEFAULT GETDATE() FOR [create_ts];


GO
PRINT N'Creating Default Constraint on [dbo].[territory]....';


GO
ALTER TABLE [dbo].[territory]
    ADD DEFAULT (1) FOR [active];


GO
PRINT N'Creating Default Constraint on [dbo].[territory]....';


GO
ALTER TABLE [dbo].[territory]
    ADD DEFAULT GETDATE() FOR [create_ts];


GO
PRINT N'Creating Default Constraint on [dbo].[usage]....';


GO
ALTER TABLE [dbo].[usage]
    ADD DEFAULT (1) FOR [active];


GO
PRINT N'Creating Default Constraint on [dbo].[usage]....';


GO
ALTER TABLE [dbo].[usage]
    ADD DEFAULT GETDATE() FOR [create_ts];


GO
PRINT N'Creating Default Constraint on [dbo].[usage_type]....';


GO
ALTER TABLE [dbo].[usage_type]
    ADD DEFAULT (1) FOR [active];


GO
PRINT N'Creating Default Constraint on [dbo].[usage_type]....';


GO
ALTER TABLE [dbo].[usage_type]
    ADD DEFAULT GETDATE() FOR [create_ts];


GO
PRINT N'Creating campaign_category_fk...';


GO
ALTER TABLE [dbo].[campaign]
    ADD CONSTRAINT [campaign_category_fk] FOREIGN KEY ([category_id]) REFERENCES [dbo].[category] ([category_id]);


GO
PRINT N'Creating campaign_territory_fk...';


GO
ALTER TABLE [dbo].[campaign]
    ADD CONSTRAINT [campaign_territory_fk] FOREIGN KEY ([territory_id]) REFERENCES [dbo].[territory] ([territory_id]);


GO
PRINT N'Creating campaign_campaign_type_fk...';


GO
ALTER TABLE [dbo].[campaign]
    ADD CONSTRAINT [campaign_campaign_type_fk] FOREIGN KEY ([campaign_type_id]) REFERENCES [dbo].[campaign_type] ([campaign_type_id]);


GO
PRINT N'Creating campaign_brand_fk...';


GO
ALTER TABLE [dbo].[campaign]
    ADD CONSTRAINT [campaign_brand_fk] FOREIGN KEY ([brand_id]) REFERENCES [dbo].[brand] ([brand_id]);


GO
PRINT N'Creating campaign_country_fk...';


GO
ALTER TABLE [dbo].[campaign]
    ADD CONSTRAINT [campaign_country_fk] FOREIGN KEY ([country_id]) REFERENCES [dbo].[country] ([country_id]);


GO
PRINT N'Creating campaign_document_campaign_fk...';


GO
ALTER TABLE [dbo].[campaign_document]
    ADD CONSTRAINT [campaign_document_campaign_fk] FOREIGN KEY ([campaign_id]) REFERENCES [dbo].[campaign] ([campaign_id]);


GO
PRINT N'Creating usage_usage_type_fk...';


GO
ALTER TABLE [dbo].[usage]
    ADD CONSTRAINT [usage_usage_type_fk] FOREIGN KEY ([usage_type_id]) REFERENCES [dbo].[usage_type] ([usage_type_id]);


GO
-- Refactoring step to update target server with deployed transaction logs

IF OBJECT_ID(N'dbo.__RefactorLog') IS NULL
BEGIN
    CREATE TABLE [dbo].[__RefactorLog] (OperationKey UNIQUEIDENTIFIER NOT NULL PRIMARY KEY)
    EXEC sp_addextendedproperty N'microsoft_database_tools_support', N'refactoring log', N'schema', N'dbo', N'table', N'__RefactorLog'
END
GO
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '3a5366aa-f422-4bde-b489-5dbe72a84806')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('3a5366aa-f422-4bde-b489-5dbe72a84806')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '046f5d47-2466-4be0-9886-ec458d1cd6c0')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('046f5d47-2466-4be0-9886-ec458d1cd6c0')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '7a24b641-b410-4c84-b139-6214355671b0')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('7a24b641-b410-4c84-b139-6214355671b0')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '2e680047-0a4d-46f8-af69-5fc01d83ed5e')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('2e680047-0a4d-46f8-af69-5fc01d83ed5e')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '54ecaf6f-5d92-46e8-ae67-ea1d93bc91a3')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('54ecaf6f-5d92-46e8-ae67-ea1d93bc91a3')

GO

GO
/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

set identity_insert dbo.category on;
insert into dbo.category (category_id, category_description) values (0, 'Unassigned');
insert into dbo.category (category_id, category_description) values (1, 'Premium');
insert into dbo.category (category_id, category_description) values (2, 'Mainstream');
insert into dbo.category (category_id, category_description) values (3, 'Affordable');
insert into dbo.category (category_id, category_description) values (4, 'Opaque');
insert into dbo.category (category_id, category_description) values (5, 'AFB');
set identity_insert dbo.category off

set identity_insert dbo.territory on;
insert into dbo.territory (territory_id, territory_description) values (1, 'Pride in Origins');
insert into dbo.territory (territory_id, territory_description) values (2, 'Bring us Together');
insert into dbo.territory (territory_id, territory_description) values (3, 'Masculine Character');
insert into dbo.territory (territory_id, territory_description) values (4, 'Style');
insert into dbo.territory (territory_id, territory_description) values (5, 'Making it');
insert into dbo.territory (territory_id, territory_description) values (6, 'Lust for Life');
insert into dbo.territory (territory_id, territory_description) values (7, 'Men will be men');
insert into dbo.territory (territory_id, territory_description) values (8, 'Beer appreciation');
insert into dbo.territory (territory_id, territory_description) values (9, 'Idyllic relaxation');
set identity_insert dbo.territory off;

set identity_insert dbo.campaign_type on;
insert into dbo.campaign_type (campaign_type_id, campaign_type_description) values (1, 'Emotional');
insert into dbo.campaign_type (campaign_type_id, campaign_type_description) values (2, 'Rational');
insert into dbo.campaign_type (campaign_type_id, campaign_type_description) values (3, 'Innovation');
insert into dbo.campaign_type (campaign_type_id, campaign_type_description) values (4, 'Promotion');
insert into dbo.campaign_type (campaign_type_id, campaign_type_description) values (5, 'Music sponsorship/event');
insert into dbo.campaign_type (campaign_type_id, campaign_type_description) values (6, 'Sport sponsorship/event');
insert into dbo.campaign_type (campaign_type_id, campaign_type_description) values (7, 'Other sponsorship/even');
insert into dbo.campaign_type (campaign_type_id, campaign_type_description) values (8, 'TTL');
insert into dbo.campaign_type (campaign_type_id, campaign_type_description) values (9, 'One visual');
set identity_insert dbo.campaign_type off

set identity_insert dbo.brand on;
insert into dbo.brand (brand_id, brand_description) values (1, 'Hansa');
insert into dbo.brand (brand_id, brand_description) values (2, 'CBL');
insert into dbo.brand (brand_id, brand_description) values (3, '2M');
insert into dbo.brand (brand_id, brand_description) values (4, 'Manica');
insert into dbo.brand (brand_id, brand_description) values (5, 'Laurentina Clara');
insert into dbo.brand (brand_id, brand_description) values (6, 'Laurentina Preta');
insert into dbo.brand (brand_id, brand_description) values (7, 'Lion');
insert into dbo.brand (brand_id, brand_description) values (8, 'Mosi');
insert into dbo.brand (brand_id, brand_description) values (9, 'Nile Special');
insert into dbo.brand (brand_id, brand_description) values (10, 'Club Pilsner');
insert into dbo.brand (brand_id, brand_description) values (11, 'Club Lager');
insert into dbo.brand (brand_id, brand_description) values (12, 'Kilimanjaro');
insert into dbo.brand (brand_id, brand_description) values (13, 'Safari');
insert into dbo.brand (brand_id, brand_description) values (14, 'Balimi');
insert into dbo.brand (brand_id, brand_description) values (15, 'Stone');
insert into dbo.brand (brand_id, brand_description) values (16, 'Hero');
insert into dbo.brand (brand_id, brand_description) values (17, 'Grand');
insert into dbo.brand (brand_id, brand_description) values (18, 'Trophy');
set identity_insert dbo.brand off

set identity_insert dbo.country on;
insert into dbo.country(country_id, country_description) values (1, 'Lesotho');
insert into dbo.country(country_id, country_description) values (2, 'Swaziland');
insert into dbo.country(country_id, country_description) values (3, 'Botswana');
insert into dbo.country(country_id, country_description) values (4, 'Mozambique');
insert into dbo.country(country_id, country_description) values (5, 'Zambia');
insert into dbo.country(country_id, country_description) values (6, 'Zimbabwe');
insert into dbo.country(country_id, country_description) values (7, 'Uganda');
insert into dbo.country(country_id, country_description) values (8, 'Tanzania');
insert into dbo.country(country_id, country_description) values (9, 'Kenya');
insert into dbo.country(country_id, country_description) values (10, 'Ghana');
insert into dbo.country(country_id, country_description) values (11, 'Nigeria');
set identity_insert dbo.country off;

set identity_insert dbo.usage_type on;
insert into dbo.usage_type(usage_type_id, usage_type_description) values (1, 'Login');
insert into dbo.usage_type(usage_type_id, usage_type_description) values (2, 'Upload');
insert into dbo.usage_type(usage_type_id, usage_type_description) values (3, 'Upload Report');
insert into dbo.usage_type(usage_type_id, usage_type_description) values (4, 'Usage Report');
insert into dbo.usage_type(usage_type_id, usage_type_description) values (5, 'Maintain Territories');
insert into dbo.usage_type(usage_type_id, usage_type_description) values (6, 'Maintain Campaign Types');
insert into dbo.usage_type(usage_type_id, usage_type_description) values (7, 'Maintain Brands');
insert into dbo.usage_type(usage_type_id, usage_type_description) values (8, 'Maintain Countries');
insert into dbo.usage_type(usage_type_id, usage_type_description) values (9, 'Read Document');
set identity_insert dbo.usage_type off;





 





GO

GO
DECLARE @VarDecimalSupported AS BIT;

SELECT @VarDecimalSupported = 0;

IF ((ServerProperty(N'EngineEdition') = 3)
    AND (((@@microsoftversion / power(2, 24) = 9)
          AND (@@microsoftversion & 0xffff >= 3024))
         OR ((@@microsoftversion / power(2, 24) = 10)
             AND (@@microsoftversion & 0xffff >= 1600))))
    SELECT @VarDecimalSupported = 1;

IF (@VarDecimalSupported > 0)
    BEGIN
        EXECUTE sp_db_vardecimal_storage_format N'$(DatabaseName)', 'ON';
    END


GO
PRINT N'Update complete.';


GO
