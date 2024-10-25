using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibrary
{
    public class Contacts
    {
        public int Person_ID;
        public int Organization_ID;
        public int Category_ID;
        public int Group_ID;
        public ContactTitle Title;
    
        public Contacts CreateContact (int Person_ID, int Organization_ID, int Category_ID, int Group_ID, ContactTitle Title) 
        {
            Contacts contact = new Contacts();
            { 
                contact.Person_ID = Person_ID;
                contact.Organization_ID = Organization_ID;
                contact.Category_ID = Category_ID;
                contact.Group_ID = Group_ID;
                contact.Title = Title;
            }
    
            return contact;
        }
    }
    
    public enum ContactTitle
    {
        Mr,
        Mrs,
        Miss,
        Mz,
        Dr
    }
    
}
