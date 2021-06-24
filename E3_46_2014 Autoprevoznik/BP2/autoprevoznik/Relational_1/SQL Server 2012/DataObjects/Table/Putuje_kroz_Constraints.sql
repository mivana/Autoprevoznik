ALTER TABLE Putuje_kroz ADD CONSTRAINT Putuje_kroz_PK PRIMARY KEY CLUSTERED (
Naselje_ime_naselja, Linija_br_linije)
WITH
  (
    ALLOW_PAGE_LOCKS = ON ,
    ALLOW_ROW_LOCKS  = ON
  )
  ON "default"
GO