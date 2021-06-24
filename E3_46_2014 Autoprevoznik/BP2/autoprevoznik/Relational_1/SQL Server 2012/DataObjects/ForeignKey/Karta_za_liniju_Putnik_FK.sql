ALTER TABLE Karta_za_liniju
ADD CONSTRAINT Karta_za_liniju_Putnik_FK FOREIGN KEY
(
Putnik_mbr_p
)
REFERENCES Putnik
(
mbr_p
)
ON
DELETE
  NO ACTION ON
UPDATE NO ACTION
GO
