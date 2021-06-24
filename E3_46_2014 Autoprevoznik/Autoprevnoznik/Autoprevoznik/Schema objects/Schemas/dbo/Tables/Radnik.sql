CREATE TABLE Radnik
  (
    mbr_r            INTEGER NOT NULL ,
    ime_r            VARCHAR (20) ,
    prz_r            VARCHAR (20) ,
    god_r            DATE ,
    adresa           VARCHAR (50) ,
    br_tel           INTEGER ,
    ugovor_sklopljen DATE NOT NULL ,
    ugovor_istekao   DATE
  ) ;
