CREATE TRIGGER [LinijaTrigger]
ON [dbo].[Linija]
AFTER INSERT
AS
	DECLARE @freeAutobus INT;
	DECLARE @br_linije INT;
	DECLARE @minAutobus INT;

	SELECT @br_linije = insertedLinija.br_linije from inserted insertedLinija;

	SELECT TOP 1 @freeAutobus=[reg] FROM Autobus a1
	LEFT JOIN Putuje p1 ON a1.reg = p1.Autobus_reg
	WHERE p1.Autobus_reg IS NULL
    
	IF(@freeAutobus IS NULL)
	BEGIN
		PRINT('izracunaj koji ima najmanje');
                    
		set @minAutobus = (select p.Autobus_reg from (select top 1 Autobus_reg,hours=Sum(case when p.dv_polaska < CURRENT_TIMESTAMP and p.dv_dolaska < CURRENT_TIMESTAMP then DATEDIFF(HOUR, dv_polaska,dv_dolaska)
														when p.dv_polaska < CURRENT_TIMESTAMP and p.dv_dolaska > CURRENT_TIMESTAMP then DATEDIFF(hour,dv_polaska,CURRENT_TIMESTAMP) end) from Putuje p
														where dv_dolaska is not null group by Autobus_reg order by hours asc) p)

		IF(@minAutobus IS NULL)
			PRINT('nema autobusa');
		else
			INSERT INTO putuje values(@minAutobus,@br_linije,CURRENT_TIMESTAMP,NULL);
	END
	else
		INSERT INTO Putuje VALUES (@freeAutobus, @br_linije, CURRENT_TIMESTAMP,NULL);
        