ALTER TABLE Putuje
ADD CONSTRAINT Putuje_Autobus_FK FOREIGN KEY
(
Autobus_reg
)
REFERENCES Autobus
(
reg
)
ON
DELETE
  NO ACTION ON
UPDATE NO ACTION
GO