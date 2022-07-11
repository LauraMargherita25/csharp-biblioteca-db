﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_biblioteca
{
    public class Library
    {
        public List<User> users = new List<User>();
        public List<Item> products = new List<Item>();
        public List<Lendal> landals = new List<Lendal>();

        
        SqlConnection connectionToLibraryDb = new SqlConnection("Data Source=localhost; Initial Catalog=library-db; Integrated Security=True");
        public void OpenLibrary()
        {
            Console.WriteLine("Benvenuto nella Biblioteca Online");
            this.MenuSignupOrLogin();
        }

        public void MenuSignupOrLogin()
        {
            Console.WriteLine("Sei già registrato?");

            string input = Console.ReadLine();

            if (input == "no")
            {
                this.SignupNewUser();
            } 
            //else if (input == "si")
            //{
            //    this.LoginUser();
            //}
           
        }
        public void SignupNewUser()
        {
            Console.Write("Nome: ");
            string inputNname = Console.ReadLine();
            Console.Write("Cognome: ");
            string inputSurname = Console.ReadLine();

            try
            {
                connectionToLibraryDb.Open();

                string query = "INSERT INTO users (name, surname) VALUES (@name, @surname)";

                SqlCommand cmd = new SqlCommand(query, connectionToLibraryDb);
                cmd.Parameters.Add(new SqlParameter("@name", inputNname));
                cmd.Parameters.Add(new SqlParameter("@surname", inputSurname));

                int affectedRows = cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                connectionToLibraryDb.Close();
            }

            //User newUser = new User(inputSurname, inputNname);
            //users.Add(newUser);

            Console.WriteLine("Ciao {0} {1}", inputNname, inputNname);
        }

        //public void LoginUser()
        //{
        //    Console.WriteLine("Email");
        //    string inputEmail = Console.ReadLine();
        //    Console.WriteLine("Password");
        //    string inputPassword = Console.ReadLine();
        //    bool notFound = true;

        //    do
        //    {
        //        foreach (User user in this.users)
        //        {
        //            if (user.Email == inputEmail && user.Password == inputPassword)
        //            {
        //                notFound = false;
        //                Console.WriteLine("Ciao {0} {1}", user.Name, user.Surname);
        //            }
                    
        //        }

        //        if (notFound)
        //        {
        //            Console.WriteLine("Nessuno utente trovato, registrati!");
        //            this.SignupNewUser();
        //        }
        //        else
        //        {
        //            this.menuSearchItem();
        //        }
        //    }
        //    while (notFound);

        //}

        public void menuSearchItem()
        {
            string[] menu = { "Visualizza dettagli prodotto", "Richiedi prestito", "Restituisci" };
            string inputUserResearch;
            bool notFound = true;

            do
            {
                Console.WriteLine("Cerca un libro o un dvd");
                inputUserResearch = Console.ReadLine();
                foreach (Item product in this.products)
                {
                    if(inputUserResearch == product.Title)
                    {
                        notFound = false;
                        Console.WriteLine("Prodotto Trovato");
                        for(int i = 0; i < menu.Length; i++)
                        {
                            Console.WriteLine("{0}. {1}", i + 1, menu[i]);
                        }
                        inputUserResearch = Console.ReadLine();
                        if (inputUserResearch == "1")
                        {
                            product.PrintItem();
                        } 
                        else if (inputUserResearch == "2")
                        {
                            this.LandItem(product);
                        }
                        else if (inputUserResearch == "3")
                        {
                            this.ReturnItem(product);
                        }
                    }
                }

                if (notFound)
                {
                    Console.WriteLine("Nessun prodotto trovato, prova a cercare qualcosa'altro!");
                }


            }while (notFound);

        }

        public void LandItem(Item item)
        {
            Console.WriteLine("Compila il modulo per il prestio");

            Console.WriteLine("Nome: ");
            string inputName = Console.ReadLine();
            Console.WriteLine("Cognome: ");
            string inputSurname = Console.ReadLine();
            Console.WriteLine("Codice fiscale: ");
            string inpuTaxCode = Console.ReadLine();
            Console.WriteLine("Dal: ");
            DateTime inputStartingDate = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Al: ");
            DateTime inputEndingDate = DateTime.Parse(Console.ReadLine());

            Lendal newLendal = new Lendal(inputName, inputSurname, inpuTaxCode, inputStartingDate, inputEndingDate);
            landals.Add(newLendal);

            item.Available = false;

        }

        public void ReturnItem(Item item)
        {
            item.Available = true; 
        }
    }
}
