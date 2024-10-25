using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibrary
{
    public class Audit
    {
        public Int32 Person_ID;
        public string Page;
        public string TableName;
        public string FieldName;
        public string OldValue;
        public string NewValue;
        public DateTime DateTimeStamp;
        public string QueryString;
        public string IPAddress;

        public Audit CreateAuditEntry(Int32 Person_ID, string Page, string TableName, string OldValue,
            string NewValue, DateTime DateTimeStamp, string QueryString, string IPAddress)
        {
            Audit audit = new Audit();
            {
                // If you use "this.FieldName" instead, it's not as explicit as using the object.FieldName
                audit.Person_ID = Person_ID;
                audit.Page = Page;
                audit.TableName = TableName;
                audit.OldValue = OldValue;
                audit.NewValue = NewValue;  
                audit.DateTimeStamp = DateTimeStamp;
                audit.QueryString = QueryString;
                audit.IPAddress = IPAddress;
            }
                
            // Returning the newly made Audit object named "audit"
            return audit;
        }
    }

    

}
