ALTER TABLE Stanica
ADD CONSTRAINT Stanica_Naselje_FK FOREIGN KEY
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
