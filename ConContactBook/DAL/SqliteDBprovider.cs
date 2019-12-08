using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SQLite;
using System.Data;

namespace ConContactBook.DAL
{
    class SqliteDBprovider : IProvider
    {
        string _connecitonstring;

        public SqliteDBprovider(string connectionstring)
        {
            _connecitonstring = connectionstring;
        }

        public int delete(string name,string phonenumber)
        {
            using (SQLiteConnection cnn = new SQLiteConnection(_connecitonstring))
            {
                int output;
                if (cnn != null)
                {
                    cnn.Open();
                    string sqlstatment = name.Equals("all")?"delete from contact":string.Format("delete from contact where name='{0}' and phonenumber='{1}'", name, phonenumber);
                    var sqlcommand = new SQLiteCommand(sqlstatment,cnn);
                    output=sqlcommand.ExecuteNonQuery();
                }
                else
                {
                    Console.WriteLine("failed connection");
                    output = 0;
                }
                return output;
            }
        }

        public List<Contact> retrieve(string name)
        {
            List<Contact> contacts = new List<Contact>();
            using (SQLiteConnection cnn = new SQLiteConnection(_connecitonstring))
            {
                if (cnn != null)
                {
                    cnn.Open();
                    string sqlstatement = name.Equals("all") ? "select name,phonenumber from contact" :
                        string.Format("select name , phonenumber from contact where name='{0}';", name);
                    var sqlcommand = new SQLiteCommand(sqlstatement,cnn);
                using (SQLiteDataReader rdr = sqlcommand.ExecuteReader())
                {

                    
                    while(rdr.Read())
                    {
                            Contact contact = new Contact();
                            contact.name = rdr["name"].ToString();
                            contact.phonenumber = rdr["phonenumber"].ToString();
                            contacts.Add(contact);
                    }
                }
                   
                }
                else
                {
                    Console.WriteLine("failed connection");
                }
            }
            return contacts;
        }

        public int save(Contact contact)
        {
            int output;
            using(SQLiteConnection cnn =new SQLiteConnection(_connecitonstring))
            {
                if(cnn!=null)
                {
                    cnn.Open();
                    string sqlstatement = string.Format("INSERT INTO contact (name,phonenumber) VALUES ('{0}','{1}');",
                                                        contact.name, contact.phonenumber);
                    var sqlcommand = new SQLiteCommand(sqlstatement,cnn);
                    output=sqlcommand.ExecuteNonQuery();
                }
                else
                {
                    Console.WriteLine("failed connection");
                    output = 0;
                }
            }
            return output;
            
        }

        public int update(Contact oldcontact, string newname)
        {
            int output;
            using (SQLiteConnection cnn = new SQLiteConnection(_connecitonstring))
            {
                if (cnn != null)
                {
                    cnn.Open();
                    string sqlstatment = string.Format("update contact set name='{0}' where name='{1}' and phonenumber='{2}'",
                                         newname,oldcontact.name,oldcontact.phonenumber
                                            );
                    var sqlcommand = new SQLiteCommand(sqlstatment, cnn);
                    output=sqlcommand.ExecuteNonQuery();
                }
                else
                {
                    Console.WriteLine("failed connection");
                    output = 0;
                }
            }
            return output;
        }
    }
}
