CREATE
  TABLE Autobus
  (
    reg                 INTEGER NOT NULL ,
    model               VARCHAR (100) ,
    br_mesta            INTEGER ,
    dat_reg             DATETIME ,
    Kompanija_sifra_kom INTEGER NOT NULL
  )
  ON "default"
GO
