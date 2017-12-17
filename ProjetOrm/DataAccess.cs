using Npgsql;
using ProjetOrm.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetOrm
{
    class DataAccess
    {
        private String connectionString ;

        public DataAccess()
        {
            //connexion paramétrer dans l'app config pour pouvoir utiliser d'autres serveur
            connectionString = ConfigurationManager.ConnectionStrings["BdContact"].ConnectionString;
        }

        //Recuperer tous les contactsS
        public List<Contact> GetContacts()
        {
            List<Contact> contacts = new List<Contact>();
            using (NpgsqlConnection connexpstgsql = new NpgsqlConnection(connectionString))
            {
                try//  verification ouverture et fermeture de la base de données 
                {
                    string req = "Select * from [Contact]";
                    //execute la requete à partir de la connexion
                    using (NpgsqlCommand myCmd = new NpgsqlCommand(req, connexpstgsql))
                    {
                        connexpstgsql.Open();
                        NpgsqlDataReader myReader = myCmd.ExecuteReader();

                        while (myReader.Read())// renvoie la requete 
                        {
                            Contact contact = new Contact();
                            contact.Id = (int)myReader["int"];
                            contact.Nom = (string)myReader["Nom"];
                            contact.Prenom = (string)myReader["Prenom"];
                            contact.Adresse = (string)myReader["Adresse"];
                            contact.Datenaissance = (DateTime)myReader["Date de naissance"];

                            contacts.Add(contact);
                        }

                        connexpstgsql.Close();
                    }

                }
                catch (Exception e)
                {

                    Console.WriteLine("Il y'a une erreur: "+ e.Message);
                }
            }

            return contacts; 

        }



        //Methode paramétrer
        public Contact GetContactNom(string nom)
        {
            Contact c = null;
            //Connection effectué a la base 
            using (NpgsqlConnection connexion = new NpgsqlConnection(connectionString))
            {
                try
                {
                    //requete SQL
                    using (NpgsqlCommand mycmd = new NpgsqlCommand("SELECT * FROM CLIENT WHERE NOM=@Nom", connexion))
                    {
                        NpgsqlParameter paramNom = new NpgsqlParameter();
                        paramNom.ParameterName = "@Nom";

                        mycmd.Parameters.Add(paramNom);
                        connexion.Open();
                        NpgsqlDataReader reader = mycmd.ExecuteReader();

                    }

                    connexion.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Il y'a une erreur:" + e.Message);
                }

                return c;
            }

        }
    }
    
    }
