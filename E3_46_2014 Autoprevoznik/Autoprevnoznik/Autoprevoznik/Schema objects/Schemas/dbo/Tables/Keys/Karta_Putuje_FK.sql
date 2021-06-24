ALTER TABLE Karta ADD CONSTRAINT Karta_Putuje_FK FOREIGN KEY ( Putuje_Autobus_reg, Putuje_Linija_br_linije, Putuje_dv_polaska ) REFERENCES Putuje ( Autobus_reg, Linija_br_linije, dv_polaska ) ;
