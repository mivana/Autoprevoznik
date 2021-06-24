# Autoprevoznik

## O projektu
Projekat predstavlja primer projektovanja baze podataka za kompaniju autoprevoznika gradskog prevoza. Realizovan projekat predstavlja desktopnu aplikaciju gde pomoću korisničkog interfejsa korisnik manipuliše projektovanom bazom podataka.

**Autoprevoznik** predstavlja preduzeće čija je pretežna delatnost gradski i prigradski kopneni prevoz putnika. On vrši aktivnosti prevoza putnika autobusima, već određenim linijama, sa ukrcavanjem i iskrcavanjem putnika na određenim već utvrđenim autobuskim stajalištima.


## Korišćene tehnologije i alati

* Projekat je radjen u **Visual Studio** programu. Sama aplikacija je razvijena kao **Windows Presentation Formanat (WPF)** aplikacija.
* Tokom razvoja aplikacije korišćen je **MVVM** obrazak, odnosno Model - View - ViewModel.
* Model podataka razvijen je pomoću **Oracle SQL Developer Data Modeler** programa, pomoću kojeg smo napravili ER model podataka i generisali iz nje Relacioni model podataka.
* Upotreba SQL baze podataka podrazumeva i **upotrebu SQL komandi** (tj. trigera), uskladišćenih procedura, indeksa i funckija.


## Opis Rešenja

Primalna svrha projekta je u edukativne svrhe, time je korisnički interfejs rešenja minimalistički i jednostavnog izgleda. 
Projekat nam pruža osnovne funkcije rukavanja sa bazom podataka, tj podrazumeva upotrebu funkcija *Dodaj novi entitet*, *Izmeni entitet*, *Izbrisi entitet* i *Osveži*. Kod pojedinih tabela baza imamo mogućnost dodatnih funkcija, koje su vezane za samu tabelu u bazi. Na primer, kod tabele **Autobus** imamo dodatnu funkciju *Ukupno sati voznje* čija je funkcija izračunjavanja i prikaza ukupnog broja sati koji su provozali pojedini Autobusi. Data funkcija se izvršava putem posebne procedure u bazi podataka.

U okviru projekta imamo nekoliko SQL funkcija, procedura, trigera i indeks.
