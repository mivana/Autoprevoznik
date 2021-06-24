CREATE TRIGGER [VozacTrigger]
	ON [dbo].[Vozac]
	AFTER INSERT 
	AS
		DECLARE @mbr_r int;
		DECLARE @reg INT;

		SELECT @mbr_r = insertedVozac.mbr_r FROM inserted insertedVozac;

		SELECT TOP 1 @reg=[reg] FROM Autobus a1
		LEFT JOIN Vozi v1 ON a1.reg = v1.Autobus_reg
		WHERE v1.Autobus_reg IS NULL

		IF(@reg is not NULL)
			INSERT INTO Vozi(Vozac_mbr_r,Autobus_reg) VALUES(@mbr_r,@reg)
		ELSE
			PRINT ('Nema slobodnih autobusa');
		
