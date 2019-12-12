using System;
using libcontactmanagement.DAL;
using System.Collections.Generic;
using System.Text;

namespace libcontactmanagement.BL
{
    public static class ContactManager
    {
        //public static List<Contact> contacts = new List<Contact>();
        public enum Field { name, phonenumber, email };

        public static IProvider provider;

        public static List<Contact> getContact(string name,Field field)
        {
            switch(field)
            {
                case Field.name: return provider.nameretrieve(name);
                case Field.phonenumber: return provider.phoneretrieve(name);
                case Field.email: return provider.emailretrieve(name);
            }
            return null;
        }

        public static int update(string name, string phonenumber,string newname)
        {
            return provider.update(new Contact(name, phonenumber), newname,DateTime.Now.ToString());
        }

        public static int create(string name,string phonenumber,string email)
        {
            return provider.save(new Contact(name, phonenumber, DateTime.Now.ToString(),email));
        }

        public static int delete(string name, string phonenumber)
        {
            return provider.delete(name, phonenumber);
        }
    }
}
