using System;
using System.Collections.Generic;
using System.Text;
using libcontactmanagement.DAL;
using libcontactmanagement.BL;


namespace libcontactmanagement.DAL
{
    public interface IProvider
    {
         int save(Contact contact);
         List<Contact> nameretrieve(string name);
         List<Contact> phoneretrieve(string phonenumber);
         List<Contact> emailretrieve(string email);
         int delete(string name,string phonenumber);
         int update(Contact oldcontact, string newname,string newdatetime);
    }
}
