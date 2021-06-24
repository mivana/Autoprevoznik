CREATE FUNCTION [dbo].[GetSeat]
(
	@reg int,
	@br_linije int,
	@dvPolaska datetime
)
RETURNS INT
AS
BEGIN
	--Izracunava sledece sediste na redu za kupovinu u Autobusu
	declare @nextFreeSeat int = 0;
	declare @br_mesta int;
	declare @seatsBought int;

	set @br_mesta = (select br_mesta from Autobus where reg = @reg);

	if(@br_mesta is not null)
	begin
		set @seatsBought = (select bought = count(*) from Karta where Putuje_Autobus_reg = @reg and Putuje_Linija_br_linije = @br_linije and Putuje_dv_polaska = @dvPolaska);
		if(@seatsBought is not null)
		begin
			if(@seatsBought < @br_mesta)
				set @nextFreeSeat = @seatsBought + 1;
			else
				set @nextFreeSeat = 0;
			
		end
	end
	else
		set @nextFreeSeat = 0;

	RETURN @nextFreeSeat
END
