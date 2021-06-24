ALTER TABLE Garaza
ADD CONSTRAINT Garaza_Naselje_FK FOREIGN KEY
(
Naselje_ime_naselja
)
REFERENCES Naselje
(
ime_naselja
)
ON
DELETE
  NO ACTION ON
UPDATE NO ACTION
GO
