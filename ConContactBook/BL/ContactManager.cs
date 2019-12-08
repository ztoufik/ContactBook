using System;
using ConContactBook.DAL;
using System.Collections.Generic;
using System.Text;

namespace ConContactBook.BL
{
    public static class ContactManager
    {
        //public static List<Contact> contacts = new List<Contact>();

        public static IProvider provider;

        public static List<Contact> getContact(string name)
        {
            return provider.retrieve(name);
        }

        public static int update(string name, string phonenumber,string newname)
        {
            return provider.update(new Contact(name, phonenumber), newname);
        }

        public static int create(string name,string phonenumber)
        {
            Contact contact = new Contact(name, phonenumber);
            return provider.save(contact);
        }

        public static int delete(string name, string phonenumber)
        {
            return provider.delete(name, phonenumber);
        }
    }
}
