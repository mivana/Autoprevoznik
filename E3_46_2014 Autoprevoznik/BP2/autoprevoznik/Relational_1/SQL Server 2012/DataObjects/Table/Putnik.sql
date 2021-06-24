CREATE
  TABLE Putnik
  (
    mbr_p          INTEGER NOT NULL ,
    ime_p          VARCHAR (20) ,
    prz_p          VARCHAR (20) ,
    adresa         VARCHAR (50) ,
    datum_rodjenja DATETIME
  )
  ON "default"
GO
