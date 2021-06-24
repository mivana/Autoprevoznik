ALTER TABLE Radnik
ADD CONSTRAINT Radnik_Kompanija_FK FOREIGN KEY
(
Kompanija_sifra_kom
)
REFERENCES Kompanija
(
sifra_kom
)
ON
DELETE
  NO ACTION ON
UPDATE NO ACTION
GO
