using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using System.Configuration;
using libcontactmanagement.DAL;
using libcontactmanagement.BL;

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
            Console.Write("\n n:search by name \t p:search by phonenumber \t e:search by email\n ");
            List<Contact> contacts=null;
            char command = Console.ReadKey().KeyChar;
            switch(command)
            {
                case 'n':
                    {
                        Console.Write("\n enter the name: ");
                        string name = Console.ReadLine();
                        contacts = ContactManager.getContact(name,ContactManager.Field.name);
                        break;
                    }
                case 'p':
                    {
                        Console.Write("\n enter the phonenumber: ");
                        string phonenumber = Console.ReadLine();
                        contacts = ContactManager.getContact(phonenumber, ContactManager.Field.phonenumber);
                        break; ;
                    }
                case 'e':
                    {
                        Console.Write("\n enter the email: ");
                        string email = Console.ReadLine();
                        contacts = ContactManager.getContact(email, ContactManager.Field.email);
                        break;
                    }
                default: Console.WriteLine("invalid option"); return;
            }
            Console.Write("\n display alphabetcally (a)or by date(d): ");
            char sort = Console.ReadKey().KeyChar;
            switch(sort)
            {
                case 'd':contacts=contacts.OrderBy(o=>o.datetime).ToList(); break;
                case 'a': contacts = contacts.OrderBy(o => o.name).ToList(); break;
                default: Console.WriteLine("invalid character");break;
            }
            foreach(var contact in contacts)
            {
                Console.WriteLine(string.Format("\n {0}\t{1}\t{2}\t{3}",contact.name,contact.phonenumber,contact.datetime,contact.email));
            }
            Console.WriteLine(string.Format(" {0} total(s)",contacts.Count));
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
            Console.Write("\n enter the email ");
            string email = Console.ReadLine();
            int result=ContactManager.create(name, phonenumber,email);
            Console.WriteLine(string.Format("\n {0} contacts saved",result));
        }
    }
}
