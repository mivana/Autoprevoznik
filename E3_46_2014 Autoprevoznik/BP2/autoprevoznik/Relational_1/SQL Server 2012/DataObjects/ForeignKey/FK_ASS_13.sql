ALTER TABLE Putuje_kroz
ADD CONSTRAINT FK_ASS_13 FOREIGN KEY
(
Linija_br_linije
)
REFERENCES Linija
(
br_linije
)
ON
DELETE
  NO ACTION ON
UPDATE NO ACTION
GO
