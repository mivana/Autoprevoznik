CREATE
  TABLE Radnik
  (
    mbr_r               INTEGER NOT NULL ,
    ime_r               VARCHAR (20) ,
    prz_r               VARCHAR (20) ,
    god_r               DATETIME ,
    Kompanija_sifra_kom INTEGER NOT NULL ,
    adresa              VARCHAR (50) ,
    br_tel              INTEGER ,
    plata               DECIMAL (28)
  )
  ON "default"
GO
