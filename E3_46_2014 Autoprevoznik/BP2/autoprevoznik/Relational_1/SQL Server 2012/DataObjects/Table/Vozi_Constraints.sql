ALTER TABLE Vozi ADD CONSTRAINT Vozi_PK PRIMARY KEY CLUSTERED (Vozac_mbr_r,
Autobus_reg)
WITH
  (
    ALLOW_PAGE_LOCKS = ON ,
    ALLOW_ROW_LOCKS  = ON
  )
  ON "default"
GO