// See https://aka.ms/new-console-template for more information
using csharp_biblioteca;
using System.Data.SqlClient;


//User rossiCaio = new User("Rossi", "Caio", "rossi@caio.com", "rossi", 1234567);
//List<User> users = new List<User>();
//users.Add(rossiCaio);

Library bibliotecaOnline = new Library();


Book cimeTempestose = new Book("1234567891234", "Cime Tempestose", 1847, "Classici", true, 32, "Emily Brontë", 100);
bibliotecaOnline.products.Add(cimeTempestose);
Book guidaGalaticcaPerAutostoppisti = new Book("6394652984522", "Guida galattica per gli autostoppisti", 1979, "Fantascienza", true, 13, "Douglas Adams", 224);
bibliotecaOnline.products.Add(guidaGalaticcaPerAutostoppisti);

User utente1 = new User("Rossi", "Gino");
bibliotecaOnline.users.Add(utente1);
User utente2 = new User("Bianchi", "Rosa");
bibliotecaOnline.users.Add(utente2);
User utente3 = new User("Verdi", "Luca");
bibliotecaOnline.users.Add(utente3);

//Lendal lendal1 = new Lendal("Gino", "Rossi", "QWEASD12Z34X567C", 2015-05-16, );

bibliotecaOnline.OpenLibrary();
