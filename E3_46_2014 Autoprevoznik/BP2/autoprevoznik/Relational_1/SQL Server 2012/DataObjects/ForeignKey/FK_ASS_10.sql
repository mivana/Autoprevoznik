ALTER TABLE Proverava
ADD CONSTRAINT FK_ASS_10 FOREIGN KEY
(
Karta_za_liniju_mbr_p,
Karta_za_liniju_reg,
Karta_za_liniju_br_linije,
Karta_za_liniju_Karta_br_karte
)
REFERENCES Karta_za_liniju
(
Putnik_mbr_p ,
Putuje_Autobus_reg ,
Putuje_Linija_br_linije ,
Karta_br_karte
)
ON
DELETE
  NO ACTION ON
UPDATE NO ACTION
GO
