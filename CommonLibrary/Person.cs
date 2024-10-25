using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibrary
{
    public class Person
    {
        public int UserType_ID;
        public int Profession_ID;
        public string LastName;
        public string FirstName;
        public string MiddleName;
        public string Suffix;
        public string Prefix;
        public string Address1;
        public string Address2;
        public string City;
        public int State_ID;
        public string PostalCode;
        public string Country;
        public string Email;
        public string SSN;
        public DateTime BirthDate;
        public string Phone;
        public string CellPhone;
        public int ContactMethod;

        public Person CreatePerson(int UserType_ID, int Profession_ID, string LastName, string FirstName, string MiddleName,
            string Suffix, string Prefix, string Address1, string Address2, string City, int State_ID, string Country,
            string Email, string SSN, DateTime BirthDate, string Phone, string CellPhone, int ContactMethod)
        {
            Person person = new Person();
            {
                person.UserType_ID = UserType_ID;
                person.Profession_ID = Profession_ID;
                person.LastName = LastName;
                person.FirstName = FirstName;
                person.MiddleName = MiddleName;
                person.Suffix = Suffix;
                person.Prefix = Prefix;
                person.Address1 = Address1;
                person.Address2 = Address2;
                person.State_ID = State_ID;
                person.Country = Country;
                person.Email = Email;
                person.SSN = SSN;
                person.BirthDate = BirthDate;
                person.Phone = Phone;
                person.CellPhone = CellPhone;
                person.ContactMethod = ContactMethod;
            }

            return person;
        }
    }
}
