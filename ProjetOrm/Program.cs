using Npgsql;
using ProjetOrm.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetOrm
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Contact> contacts;

            DataAccess da = new DataAccess();
            //test selection des contacts
            contacts = da.GetContacts();
            //test selection du nomm
            Contact co = da.GetContactNom("Bolongo");

            foreach (Contact c in contacts)
            {
                Console.WriteLine(c.Nom);

            }
            
            Console.WriteLine("Effectué");
            Console.ReadLine();
        }
    }
}
