using System;
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
            else if (input == "si")
            {
                this.LoginUser();
            }

        }
        public void SignupNewUser()
        {
            Console.Write("Nome: ");
            string inputNname = Console.ReadLine();
            Console.Write("Cognome: ");
            string inputSurname = Console.ReadLine();
            Console.Write("Email: ");
            string inputEmail = Console.ReadLine();
            Console.Write("Password: ");
            string inputPassword = Console.ReadLine();

            try
            {
                connectionToLibraryDb.Open();

                string query = "INSERT INTO users (name, surname, email, password) VALUES (@Name, @Surname, @Email, @Password)";

                SqlCommand cmd = new SqlCommand(query, connectionToLibraryDb);
                cmd.Parameters.Add(new SqlParameter("@Name", inputNname));
                cmd.Parameters.Add(new SqlParameter("@Surname", inputSurname));
                cmd.Parameters.Add(new SqlParameter("@Email", inputEmail));
                cmd.Parameters.Add(new SqlParameter("@Password", inputPassword));

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

            Console.WriteLine("Ciao {0} {1}", inputNname, inputSurname);
        }

        public void LoginUser()
        {
            Console.WriteLine("Email");
            string inputEmail = Console.ReadLine();
            Console.WriteLine("Password");
            string inputPassword = Console.ReadLine();

            try
            {
                connectionToLibraryDb.Open();

                string query = "SELECT * FROM users WHERE email=@Email AND password=@Password";

                using (SqlCommand cmd = new SqlCommand(query, connectionToLibraryDb))
                {
                    cmd.Parameters.Add(new SqlParameter("@Email", inputEmail));
                    cmd.Parameters.Add(new SqlParameter("@Password", inputPassword));
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Console.WriteLine("Bentornato");
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                connectionToLibraryDb.Close();
                this.menuSearchItem();
            }

        }

        public void menuSearchItem()
        {
            Console.WriteLine("Cerca un libro");
            string inputUserResearch = Console.ReadLine();

            try
            {
                connectionToLibraryDb.Open();

                string query = "SELECT * FROM books WHERE title=@Title";
                using (SqlCommand cmd = new SqlCommand(query, connectionToLibraryDb))
                {
                    cmd.Parameters.Add(new SqlParameter("@Title", inputUserResearch));
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Console.WriteLine("Libro trovato");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                connectionToLibraryDb.Close();
            }
            //string[] menu = { "Visualizza dettagli prodotto", "Richiedi prestito", "Restituisci" };
            //string inputUserResearch;
            //bool notFound = true;

            //do
            //{
            //    Console.WriteLine("Cerca un libro");
            //    inputUserResearch = Console.ReadLine();
            //    foreach (Item product in this.products)
            //    {
            //        if(inputUserResearch == product.Title)
            //        {
            //            notFound = false;
            //            Console.WriteLine("Prodotto Trovato");
            //            for(int i = 0; i < menu.Length; i++)
            //            {
            //                Console.WriteLine("{0}. {1}", i + 1, menu[i]);
            //            }
            //            inputUserResearch = Console.ReadLine();
            //            if (inputUserResearch == "1")
            //            {
            //                product.PrintItem();
            //            } 
            //            else if (inputUserResearch == "2")
            //            {
            //                this.LandItem(product);
            //            }
            //            else if (inputUserResearch == "3")
            //            {
            //                this.ReturnItem(product);
            //            }
            //        }
            //    }

            //    if (notFound)
            //    {
            //        Console.WriteLine("Nessun prodotto trovato, prova a cercare qualcosa'altro!");
            //    }


            //}while (notFound);

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
