using System;
using System.Collections.Generic;
using System.Text;
using ConContactBook.DAL;
using ConContactBook.BL;


namespace ConContactBook.DAL
{
    public interface IProvider
    {
         int save(Contact contact);
         List<Contact> retrieve(string name);
         int delete(string name,string phonenumber);
         int update(Contact oldcontact, string newname,string newdatetime);
    }
}
