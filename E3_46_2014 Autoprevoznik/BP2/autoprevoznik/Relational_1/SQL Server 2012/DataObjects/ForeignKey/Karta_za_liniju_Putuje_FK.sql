ALTER TABLE Karta_za_liniju
ADD CONSTRAINT Karta_za_liniju_Putuje_FK FOREIGN KEY
(
Putuje_Autobus_reg,
Putuje_Linija_br_linije
)
REFERENCES Putuje
(
Autobus_reg ,
Linija_br_linije
)
ON
DELETE
  NO ACTION ON
UPDATE NO ACTION
GO
