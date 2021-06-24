ALTER TABLE Prodaje ADD CONSTRAINT Prodaje_PK PRIMARY KEY CLUSTERED (
Karta_br_karte, Kondukter_mbr_r)
WITH
  (
    ALLOW_PAGE_LOCKS = ON ,
    ALLOW_ROW_LOCKS  = ON
  )
  ON "default"
GO