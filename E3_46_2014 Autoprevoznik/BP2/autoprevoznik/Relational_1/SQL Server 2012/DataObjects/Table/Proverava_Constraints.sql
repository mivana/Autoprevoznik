ALTER TABLE Proverava ADD CONSTRAINT Proverava_PK PRIMARY KEY CLUSTERED (
Kontroler_mbr_r, Karta_za_liniju_mbr_p, Karta_za_liniju_reg,
Karta_za_liniju_br_linije, Karta_za_liniju_Karta_br_karte)
WITH
  (
    ALLOW_PAGE_LOCKS = ON ,
    ALLOW_ROW_LOCKS  = ON
  )
  ON "default"
GO