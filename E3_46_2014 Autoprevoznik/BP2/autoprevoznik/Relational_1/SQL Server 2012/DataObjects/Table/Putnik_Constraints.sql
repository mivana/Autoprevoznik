ALTER TABLE Putnik ADD CONSTRAINT Putnik_PK PRIMARY KEY CLUSTERED (mbr_p)
WITH
  (
    ALLOW_PAGE_LOCKS = ON ,
    ALLOW_ROW_LOCKS  = ON
  )
  ON "default"
GO