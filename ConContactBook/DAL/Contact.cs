using System;
using System.Collections.Generic;
using System.Text;

namespace ConContactBook.DAL
{
    public class Contact
    {
        public int id { get; set; }
        public string name { get; set; }
        public string phonenumber { get; set; }
        
        public Contact() { }

        public Contact(string name,string phonenumber)
        {
            this.name = name;
            this.phonenumber = phonenumber;
        }
    }
}
