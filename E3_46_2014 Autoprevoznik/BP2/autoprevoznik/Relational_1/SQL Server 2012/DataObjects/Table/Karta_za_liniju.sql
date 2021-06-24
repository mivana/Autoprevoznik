CREATE
  TABLE Karta_za_liniju
  (
    sediste                 INTEGER ,
    datum_kup               DATETIME ,
    cena                    DECIMAL (28) ,
    relacija                VARCHAR (100) ,
    Putnik_mbr_p            INTEGER NOT NULL ,
    Putuje_Autobus_reg      INTEGER NOT NULL ,
    Putuje_Linija_br_linije INTEGER NOT NULL ,
    Karta_br_karte          INTEGER NOT NULL
  )
  ON "default"
GO
