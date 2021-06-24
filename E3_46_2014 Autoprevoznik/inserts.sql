--delete from Prodaje
--delete from Proverava
--delete from Vozi
--delete from Karta
--delete from Putnik
--delete from Putuje
--delete from Putuje_kroz
--delete from Linija
--delete from Stanica
--delete from Garaza
--delete from Naselje
--delete from Autobus
--delete from Vozac
--delete from Kondukter
--delete from Kontroler
--delete from Radnik

insert into Autobus values(1,'Yugo',23,CURRENT_TIMESTAMP);
insert into Autobus values(2,'Fiat',55,CURRENT_TIMESTAMP);
insert into Autobus values(3,'BMW',43,CURRENT_TIMESTAMP);
insert into Autobus values(4,'Yugo',0,CURRENT_TIMESTAMP);
insert into Autobus values(5,'Fiat',12,CURRENT_TIMESTAMP);

insert into Naselje values('Bagljas');
insert into Naselje values('Liman');
insert into Naselje values('Spomenik');
insert into Naselje values('Aviv');
insert into Naselje values('Centar');
insert into Naselje values('Liman 2');
insert into Naselje values('Liman 3');
insert into Naselje values('Liman 4');
insert into Naselje values('Grbavica');

insert into Garaza values(1,'Bagljas',10);
insert into Garaza values(2,'Liman',10);
insert into Garaza values(3,'Spomenik',8);
insert into Garaza values(4,'Liman 2',10);
insert into Garaza values(5,'Grbavica',10);

insert into Stanica values(1,'Bagljas');
insert into Stanica values(2,'Spomenik');
insert into Stanica values(3,'Centar');
insert into Stanica values(4,'Grbavica');
insert into Stanica values(5,'Bagljas');
insert into Stanica values(6,'Liman 2');
insert into Stanica values(7,'Liman 3');

insert into Linija values(1,'Stari Bagljas');
insert into Putuje_kroz values('Bagljas',1);
insert into Putuje_kroz values('Spomenik',1);
insert into Putuje_kroz values('Aviv',1);

insert into Linija values(2,'Centar');
insert into Putuje_kroz values('Bagljas',2);
insert into Putuje_kroz values('Aviv',2);
insert into Putuje_kroz values('Centar',2);
insert into Putuje_kroz values('Liman 2',2);

insert into Linija values(3,'Grbavica');
insert into Putuje_kroz values('Bagljas',3);
insert into Putuje_kroz values('Grbavica',3);
insert into Putuje_kroz values('Liman 2',3);
insert into Putuje_kroz values('Liman 3',3);

insert into Linija values(4,'Novi Bagljas');
insert into Putuje_kroz values('Bagljas',4);
insert into Putuje_kroz values('Aviv',4);
insert into Putuje_kroz values('Centar',4);

insert into Linija values(5,'Liman');
insert into Putuje_kroz values('Liman 2',5);
insert into Putuje_kroz values('Liman 3',5);
insert into Putuje_kroz values('Centar',5);

insert into Putnik values(1,'Ivana','Markan');
insert into Putnik values(2,'Dragan','Draganovic');
insert into Putnik values(3,'Ana','Anic');
insert into Putnik values(4,'Bodgan','Bodanovic');
insert into Putnik values(5,'Milan','Milanovic');
insert into Putnik values(6,'Danijela','Danic');
insert into Putnik values(7,'Uros','Urosic');
insert into Putnik values(8,'Pepi','Pepic');

insert into Radnik values(1,'Ime','Imenovic',CURRENT_TIMESTAMP,'Adresa 2','1234232',CURRENT_TIMESTAMP,null);
insert into Vozac values(1,1,'ABC');

insert into Radnik values(2,'Danilo','Danilovic',CURRENT_TIMESTAMP,'Adresa 4','523452345',CURRENT_TIMESTAMP,null);
insert into Vozac values(2,2,'A1 A2');

insert into Radnik values(3,'Marko','Markovic',CURRENT_TIMESTAMP,'Adresa 221','234234',CURRENT_TIMESTAMP,null);
insert into Vozac values(3,3,'DE');

insert into Radnik values(4,'Daca','Imenovic',CURRENT_TIMESTAMP,'Adresa 666','64567',CURRENT_TIMESTAMP,null);
insert into Vozac values(4,4,'B2 B3');

insert into Radnik values(5,'Ime','Dacovic',CURRENT_TIMESTAMP,'Adresa 112','1123123',CURRENT_TIMESTAMP,null);
insert into Vozac values(5,5,'F');

insert into Radnik values(7,'Nikola','Nikolic',CURRENT_TIMESTAMP,'Adresa 112','1123123',CURRENT_TIMESTAMP,null);
insert into Vozac values(7,5,'F');

insert into Radnik values(6,'Andjela','Andjelovic',CURRENT_TIMESTAMP,'Adresa 112','1123123',CURRENT_TIMESTAMP,null);
insert into Vozac values(6,5,'F');

insert into Radnik values(8,'Momir','Momirovic',CURRENT_TIMESTAMP,'Adresa 112','1123123',CURRENT_TIMESTAMP,null);
insert into Kondukter values(8,1);

insert into Radnik values(9,'Nebojsa','Nebojsic',CURRENT_TIMESTAMP,'Adresa 112','1123123',CURRENT_TIMESTAMP,null);
insert into Kondukter values(9,2);

insert into Radnik values(10,'Spasoje','Spasojevic',CURRENT_TIMESTAMP,'Adresa 112','1123123',CURRENT_TIMESTAMP,null);
insert into Kondukter values(10,3);

insert into Radnik values(11,'Jovana','Jovanovic',CURRENT_TIMESTAMP,'Adresa 112','1123123',CURRENT_TIMESTAMP,null);
insert into Kontroler values(11,1);

insert into Radnik values(12,'Milica','Milicic',CURRENT_TIMESTAMP,'Adresa 112','1123123',CURRENT_TIMESTAMP,null);
insert into Kontroler values(12,2);

insert into Radnik values(13,'Sava','Savic',CURRENT_TIMESTAMP,'Adresa 112','1123123',CURRENT_TIMESTAMP,null);
insert into Kontroler values(13,3);


