ALTER TABLE Karta_za_liniju ADD CONSTRAINT Karta_za_liniju_PK PRIMARY KEY
CLUSTERED (Putnik_mbr_p, Putuje_Autobus_reg, Putuje_Linija_br_linije,
Karta_br_karte)
WITH
  (
    ALLOW_PAGE_LOCKS = ON ,
    ALLOW_ROW_LOCKS  = ON
  )
  ON "default"
GO