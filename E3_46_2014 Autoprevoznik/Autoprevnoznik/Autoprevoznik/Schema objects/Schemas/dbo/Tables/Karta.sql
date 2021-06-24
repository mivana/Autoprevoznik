CREATE TABLE Karta
  (
    sediste                 INTEGER ,
    datum_kup               DATE ,
    cena                    DECIMAL ,
    relacija                VARCHAR (100) ,
    Putnik_mbr_p            INTEGER NOT NULL ,
    Putuje_Autobus_reg      INTEGER NOT NULL ,
    Putuje_Linija_br_linije INTEGER NOT NULL ,
    Putuje_dv_polaska       DATETIME2 NOT NULL
  ) ;
