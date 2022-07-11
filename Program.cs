// See https://aka.ms/new-console-template for more information
using csharp_biblioteca;



//User rossiCaio = new User("Rossi", "Caio", "rossi@caio.com", "rossi", 1234567);
//List<User> users = new List<User>();
//users.Add(rossiCaio);

Library bibliotecaOnline = new Library();


Book cimeTempestose = new Book("1234567891234", "Cime Tempestose", 1847, "Classici", true, 32, "Emily Brontë", 100);
bibliotecaOnline.AddNewPreoduct(cimeTempestose);
Book guidaGalaticcaPerAutostoppisti = new Book("6394652984522", "Guida galattica per gli autostoppisti", 1979, "Fantascienza", true, 13, "Douglas Adams", 224);
bibliotecaOnline.AddNewPreoduct(guidaGalaticcaPerAutostoppisti);

Dvd ilSignoreDegliAnelli1 = new Dvd("ABC 1234", "Il Signore degli Anelli - La Compagnia dell'Anello", 2001, "Fantasy", true, 43, "Peter Jackson", 178);
bibliotecaOnline.AddNewPreoduct(ilSignoreDegliAnelli1);
Dvd ilSignoreDegliAnelli2 = new Dvd("ASD 2345", "Il Signore degli Anelli - Le due torri", 2002, "Fantasy", true, 43, "Peter Jackson", 179);
bibliotecaOnline.AddNewPreoduct(ilSignoreDegliAnelli2);
Dvd ilSignoreDegliAnelli3 = new Dvd("QWE 3456", "Il Signore degli Anelli - Il ritorno del re", 2003, "Fantasy", true, 43, "Peter Jackson", 200);
bibliotecaOnline.AddNewPreoduct(ilSignoreDegliAnelli3);

User utente1 = new User("Rossi", "Gino", "gino@rossi.it", "1q2w3e", 3125244984);
bibliotecaOnline.AddNewUser(utente1);
User utente2 = new User("Bianchi", "Rosa", "rosa@bianchi.it", "asdfqwer", 3452952398);
bibliotecaOnline.AddNewUser(utente2);
User utente3 = new User("Verdi", "Luca", "luca@verdi.it", "forzajuve", 3973456263);
bibliotecaOnline.AddNewUser(utente3);

Lendal lendal1 = new Lendal("Gino", "Rossi", "QWEASD12Z34X567C", 2015-05-16, );

bibliotecaOnline.OpenLibrary();
