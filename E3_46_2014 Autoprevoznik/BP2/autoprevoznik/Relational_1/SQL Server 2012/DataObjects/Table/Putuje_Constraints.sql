ALTER TABLE Putuje ADD CONSTRAINT Putuje_PK PRIMARY KEY CLUSTERED (Autobus_reg,
Linija_br_linije)
WITH
  (
    ALLOW_PAGE_LOCKS = ON ,
    ALLOW_ROW_LOCKS  = ON
  )
  ON "default"
GO