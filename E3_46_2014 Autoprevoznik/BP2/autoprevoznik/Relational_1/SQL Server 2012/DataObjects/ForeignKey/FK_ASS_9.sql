ALTER TABLE Proverava
ADD CONSTRAINT FK_ASS_9 FOREIGN KEY
(
Kontroler_mbr_r
)
REFERENCES Kontroler
(
mbr_r
)
ON
DELETE
  NO ACTION ON
UPDATE NO ACTION
GO