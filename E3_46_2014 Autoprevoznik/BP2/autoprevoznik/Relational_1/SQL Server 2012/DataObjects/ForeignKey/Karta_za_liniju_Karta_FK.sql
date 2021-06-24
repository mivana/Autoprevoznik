ALTER TABLE Karta_za_liniju
ADD CONSTRAINT Karta_za_liniju_Karta_FK FOREIGN KEY
(
Karta_br_karte
)
REFERENCES Karta
(
br_karte
)
ON
DELETE
  NO ACTION ON
UPDATE NO ACTION
GO
