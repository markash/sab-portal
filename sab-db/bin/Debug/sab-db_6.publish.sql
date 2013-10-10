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
USE [$(DatabaseName)];


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

set identity_insert dbo.campaign on;
insert into dbo.campaign_type (campaign_id, campaign_description) values (1, 'Premium');
insert into dbo.campaign_type (campaign_id, campaign_description) values (2, 'Mainstream');
insert into dbo.campaign_type (campaign_id, campaign_description) values (3, 'Affordable');
insert into dbo.campaign_type (campaign_id, campaign_description) values (4, 'Opaque');
insert into dbo.campaign_type (campaign_id, campaign_description) values (5, 'AFB');
set identity_insert dbo.campaign off
*/



GO

GO
PRINT N'Update complete.';


GO
