using System;
using System.Configuration;
using ConContactBook.DAL;
using ConContactBook.BL;

namespace ConContactBook
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("q to quit \t c to create contact \t u to update contact \t d to delete contact ");
            ContactManager.provider = new SqliteDBprovider(getconnectionstring());
            while (true)
            {
                char command = Console.ReadKey().KeyChar;
                switch(command)
                {
                    case 'q': Console.WriteLine("\n quit....."); return;
                    case 'c': createcontact();break;
                    case 'u': updatecontact();break;
                    case 'd': deletecontact();break;
                    case 's': listAllContacts();break;
                    default: Console.WriteLine("\n enter valid command");break;
                    
                }
            }
        }

        private static string getconnectionstring()
        {
            return ConfigurationManager.ConnectionStrings["default"].ConnectionString;
        }

        private static void InputnameAndphnumb(out string name,out string phonenumber)
        {
            Console.Write("\n enter the name:  ");
             name = Console.ReadLine();

            Console.Write("\n enter the phone number:  ");
             phonenumber = Console.ReadLine();
        }

        private static void listAllContacts()
        {
            Console.Write("\n enter the search name : ");
            string name = Console.ReadLine();
            int count = 0;
            foreach(var contact in ContactManager.getContact(name))
            {
                Console.WriteLine(string.Format("\n {0}\t{1}", contact.name, contact.phonenumber));
                count++;
            }
            Console.WriteLine(string.Format("\n {0} total contact(s)",count));
        }

        private static void deletecontact()
        {
            string name, phonenumber;
            InputnameAndphnumb(out name, out phonenumber);
            int result=ContactManager.delete(name, phonenumber);

            Console.WriteLine(string.Format("\n {0} contacts deleted", result));

        }

        private static void updatecontact()
        {
            string name, phonenumber;
            InputnameAndphnumb(out name, out phonenumber);

            Console.Write("\n enter the new name  ");
            string newname = Console.ReadLine();

            int result=ContactManager.update(name, phonenumber,newname);

            Console.WriteLine(string.Format("\n {0} contacts updated", result));
        }

        private static void createcontact()
        {
            string name, phonenumber;
            InputnameAndphnumb(out name, out phonenumber);

            int result=ContactManager.create(name, phonenumber);
            Console.WriteLine(string.Format("\n {0} contacts saved",result));
        }
    }
}
