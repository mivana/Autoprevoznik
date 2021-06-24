﻿/*
Deployment script for AutoprevoznikDB

This code was generated by a tool.
Changes to this file may cause incorrect behavior and will be lost if
the code is regenerated.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "AutoprevoznikDB"
:setvar DefaultFilePrefix "AutoprevoznikDB"
:setvar DefaultDataPath "C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\"
:setvar DefaultLogPath "C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\"

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
PRINT N'Altering [dbo].[P_Autobus_sati]...';


GO
ALTER PROCEDURE [dbo].[P_Autobus_sati]
--(
--	@reg int
--)
AS
begin
	--select hours = [dbo].GetHours(@reg);
	
	DECLARE @reg INT;
	
	
	declare Autobus_cursor cursor
	for
	select reg FROM Autobus;

	open Autobus_cursor;

	while @@FETCH_STATUS = 0
	begin
		fetch next FROM Autobus_cursor INTO @reg;

		SELECT hours = [dbo].[GetHours](@reg);
	
	end

	--select reg=p.Autobus_reg,model=a.model,br_mesta=a.br_mesta,dat_reg=a.dat_reg,hours=p.hours from(select Autobus_reg,hours=Sum(DATEDIFF(HOUR, dv_polaska,dv_dolaska)) from Putuje
	--				where dv_dolaska is not null group by Autobus_reg )p join Autobus a on p.Autobus_reg = a.reg 
	
end
GO
PRINT N'Update complete.';


GO