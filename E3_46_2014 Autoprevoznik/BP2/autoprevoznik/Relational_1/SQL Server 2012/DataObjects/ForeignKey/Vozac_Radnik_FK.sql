ALTER TABLE Vozac
ADD CONSTRAINT Vozac_Radnik_FK FOREIGN KEY
(
mbr_r
)
REFERENCES Radnik
(
mbr_r
)
ON
DELETE
  NO ACTION ON
UPDATE NO ACTION
GO
