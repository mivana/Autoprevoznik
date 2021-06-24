CREATE PROCEDURE [dbo].[P_Naselje]
(
	@returnValue varchar(100) output
)
AS
	--Prolazi kroz tabelu Naselje, racuna za svaki koliko je puta je putnik sa kartom prosao kroz njega, i racuna maximum
	declare @id_naselja varchar(50);
	DECLARE @passes INT = 0;
	DECLARE @NaseljeMax VARCHAR(50);
	DECLARE @PassesMax INT = 0;
	declare @lastNaselje varchar(50);

	declare Naselje_cursor cursor
	for
	select ime_naselja from Naselje

	open Naselje_cursor

	while @@FETCH_STATUS = 0
	BEGIN
		FETCH NEXT FROM Naselje_cursor INTO @id_naselja;

		IF(@passes > @PassesMax)
		BEGIN
			SET @PassesMax = @passes;
			set @NaseljeMax = @lastNaselje;
		end
		
		SET @passes = dbo.GetPasses(@id_naselja);
		set @lastNaselje = @id_naselja;

	end

	close Naselje_cursor;
	deallocate Naselje_cursor;

	 --SELECT p.Naselje_ime_naselja, p.passed FROM(SELECT TOP 1 Naselje_ime_naselja,passed = COUNT(Naselje_ime_naselja) FROM Putuje_kroz ok
		--right join Karta k on ok.Linija_br_linije = k.Putuje_Linija_br_linije group by Naselje_ime_naselja order by passed desc) p
	set @returnValue = @NaseljeMax + ',' + cast(@PassesMax as varchar(10));

RETURN 0;
