using System;
using System.Collections.Generic;
using System.Text;

namespace libcontactmanagement.DAL
{
    public class Contact
    {
        public string name { get; set; }
        public string phonenumber { get; set; }
        public string datetime { get; set; }
        public string email { get; set; }


        public Contact() { }

        public Contact(string name=null,string phonenumber=null,string datetime=null,string email=null)
        {
            this.name = name;
            this.phonenumber = phonenumber;
            this.datetime = datetime;
            this.email = email;
        }
    }
}
