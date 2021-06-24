CREATE FUNCTION [dbo].[GetPasses]
(
	@ime VARCHAR(50)
)
RETURNS INT
AS
BEGIN
	--Izracunava koliko putnika sa kupljenom kartom proslo kroz prosledjeno naselje
	DECLARE @numPassed INT = 0;
	SET @numPassed = (select COUNT(*) FROM Putuje_kroz pk RIGHT JOIN Karta k ON pk.Linija_br_linije = k.Putuje_Linija_br_linije WHERE pk.Naselje_ime_naselja = @ime);

	RETURN @numPassed
END
