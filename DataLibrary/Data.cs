using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonLibrary;
using NLog;

namespace DataLibrary
{
    public static class Data
    {
        //Create Logger
        private static readonly NLog.Logger _log =
            NLog.LogManager.GetCurrentClassLogger();

        private static SQLiteConnection sqlite;

        static Data()
        {
            try
            {
                sqlite = new SQLiteConnection("Data source=C:\\Users\\ppatr\\Desktop\\CIS359\\Database\\MyAPI.db");

            }
            catch (Exception ex)
            {
                _log.Error("{0}:DataLibrary:Data:An error occurred:{1}",
                        DateTime.Now, ex.Message);
            }
        }

        public static string GetData(int id)
        {
            string name = string.Empty;

            //Exception Handling
            try
            {

                using (var connection = sqlite)
                {
                    connection.Open();

                    var command = connection.CreateCommand();
                    command.CommandText =
                        @"SELECT FirstName, LastName FROM Contact WHERE Contact_ID = $id";
                    command.Parameters.AddWithValue("$id", id);

                    using (var reader = command.ExecuteReader())
                    {
                        while ((reader.Read()))
                        {
                            name = reader.GetString(0) + " " + reader.GetString(1);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _log.Error("{0}:DataLibrary:GetData:An error occurred:{1}",
                    DateTime.Now, ex.Message);
            }
            return name;
        }

        public static DataTable selectQuery(string query)
        {
            SQLiteDataAdapter ad;
            DataTable dt = new DataTable();

            //Exception Handling
            try
            {
                SQLiteCommand cmd;
                sqlite.Open(); // Open connection to the db
                cmd = sqlite.CreateCommand();
                cmd.CommandText = query; // Set the passed query
                ad = new SQLiteDataAdapter(cmd);
                ad.Fill(dt); // Fill the datatable

                _log.Info("{0}:DataLibrary:selectQuery:{1}", DateTime.Now, query);
            }
            catch (SQLiteException ex)
            {
                //Add your exception code here
                _log.Error("{0}:DataLibrary:selectQuery:An error occurred:{1}",
                    DateTime.Now, ex.Message);
            }
            sqlite.Close();
            return dt;
        }

        public static InsertAudit(Audit auditData)
        {
            string SQL = "INSERT INTO Audit(Person_ID, Page, TableName, FieldName, OldValue, NewValue, DateTimeStamp, QueryString, IPAddress)";
            SQL += "VALUES (" + auditData.Person_ID + ",'" + auditData.Page + "','" + auditData.TableName + "','";
            SQL += auditData.FieldName + "','" + auditData.OldValue + auditData.FieldName + "','" + auditData.NewValue;
            SQL += "','" + DateTime.Now + "', '" + auditData.QueryString + "','" + auditData.IPAddress + "')";

            using (var connection = sqlite)
            {
                connection.Open();
                using (var command = new SQLiteCommand())
                {
                    //Execute the INSERT statement
                    var rowInserted = command.ExecuteNonQuery();

                    Console.WriteLine($"The audit entry has been created successfully.");
                }
                connection.Close();
            }

        }

        public static CreatePerson(Person personData)
        {
            string SQL = "INSERT INTO PERSON (UserType_ID, Profession_ID, LastName, FirstName, MiddleName, Suffix, Prefix,";
            SQL += "Address1, Address2, City, State_ID, PostalCode, Country, Email, SSN, BirthDate, Phone, CellPhone, ContactMethod";
            SQL += "VALUES (" + personData.UserType_ID + "," + personData.Profession_ID + ",'" + personData.LastName + "','";
            SQL += personData.FirstName + "','" + personData.MiddleName + "','" + personData.Suffix + "','" + personData.Prefix + "',";
            SQL += personData.Address1 + "','" + personData.Address2 + "','" + personData.City + "','" + personData.State_ID + ",";
            SQL += personData.PostalCode + "','" + personData.Country + "','" + personData.Email + "','" + personData.SSN + ",";
            SQL += personData.BirthDate + "','" + personData.Phone + "','" + personData.CellPhone + "','" + personData.ContactMethod + ")";

            using (var connection = sqlite)
            {
                connection.Open();
                using (var command = new SQLiteCommand())
                {
                    //Execute the INSERT statement
                    var rowInserted = command.ExecuteNonQuery();

                    Console.WriteLine($"The person entry has been created successfully.");
                }
                connection.Close();
            }
        }

        public static CreateContact(Contacts contactData)
        {
            string SQL = "INSERT INTO Contact (Person_ID, Organization_ID, Category_ID, Group_ID, Title_ID)";
            SQL += "VALUES (" + contactData.Person_ID + "','" + contactData.Organization_ID + "','" + contactData.Category_ID + ",";
            SQL += contactData.Group_ID + "," + contactData.Title + ")";

            using (var connection = sqlite)
            {
                connection.Open();
                using (var command = new SQLiteCommand())
                {
                    // Execute the INSERT statement
                    var rowsInserted = command.ExecuteNonQuery();


                    Console.WriteLine($"The contact entry has been created successfully.");
                }
                connection.Close();
            }

            /* DECIDED TO COMMENT THIS OUT OCTOBER 24, 2024
             * 
             * public static SQLiteDataReader GetDataReader(string strSQL)
            {
                SQLiteDataReader sldr;
                SQLiteCommand cmd;

                sqlite.Open();  // Open connection to the db
                cmd = sqlite.CreateCommand();
                cmd.CommandText = strSQL;  // Set the passed query
                sldr = cmd.ExecuteReader();

                return sldr;
            } */
        }
    }
}
