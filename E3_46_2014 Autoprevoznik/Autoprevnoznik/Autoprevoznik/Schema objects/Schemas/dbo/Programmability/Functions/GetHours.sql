CREATE FUNCTION [dbo].[GetHours]
(
	@reg int
)
RETURNS INT
AS
BEGIN
	--Izracunava koliko je sati autobus bio u voznji
    
	declare @hours NUMERIC = 0, @current_hours NUMERIC = 0;
	declare @dv_polaska datetime, @dv_dolaska datetime;
	declare @autobus_reg int;


	declare Sati_cursor cursor
	for
	select Autobus_reg,dv_polaska,dv_dolaska FROM Putuje;

	open Sati_cursor;

	while @@FETCH_STATUS = 0
	begin
		
		fetch next FROM Sati_cursor INTO @autobus_reg,@dv_polaska, @dv_dolaska;
		if(@autobus_reg = @reg)
		begin
			if(@dv_dolaska is not null)
			begin 
				if(@dv_polaska < CURRENT_TIMESTAMP and @dv_dolaska < CURRENT_TIMESTAMP)
					set @hours += sum(DATEDIFF(hour,@dv_polaska,@dv_dolaska));
				else
					if(@dv_polaska < CURRENT_TIMESTAMP and @dv_dolaska > CURRENT_TIMESTAMP)
						set @hours += sum(DATEDIFF(hour,@dv_polaska,CURRENT_TIMESTAMP));
			end
		end
		
	end

	RETURN @hours
END
