CREATE PROCEDURE [dbo].[P_Autobus_sati]
AS
begin
	--Vraca informacije o autobusu i koliko sati je on ukupno proveo u voznji
	select * from(select p.Autobus_reg,hours = Sum(case when p.dv_polaska < CURRENT_TIMESTAMP and p.dv_dolaska < CURRENT_TIMESTAMP then DATEDIFF(HOUR, dv_polaska,dv_dolaska)
														when p.dv_polaska < CURRENT_TIMESTAMP and p.dv_dolaska > CURRENT_TIMESTAMP then DATEDIFF(hour,dv_polaska,CURRENT_TIMESTAMP) end) from Putuje p 
														where dv_dolaska is not null group by Autobus_reg)p join Autobus a
														on p.Autobus_reg = a.reg
end 