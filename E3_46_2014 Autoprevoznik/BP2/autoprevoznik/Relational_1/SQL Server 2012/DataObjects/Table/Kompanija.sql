CREATE
  TABLE Kompanija
  (
    sifra_kom       INTEGER NOT NULL ,
    ime_kom         VARCHAR (20) ,
    vlasnik         VARCHAR (20) ,
    adresa          VARCHAR (50) ,
    br_tel          INTEGER ,
    datum_osnivanja DATETIME
  )
  ON "default"
GO
