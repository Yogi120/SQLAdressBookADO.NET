using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLAdressBookADO.NET
{
    public class Contact
    {
        public string Name;
        public string PhoneNumber;
        public string Email;
        public string State;
        public string City;
        public string ZipCode;
        public int Id;

        public Contact()
        {

        }
        public Contact(int id, string name, string phoneNumber, string email, string state, string city, string zipCode)
        {
            Id = id;
            Name = name;
            PhoneNumber = phoneNumber;
            Email = email;
            State = state;
            City = city;
            ZipCode = zipCode;
        }

        public Contact(string spname, string spphoneNumber, string spemail, string spstate, string spcity, string spzipCode)
        {
            Name = spname;
            PhoneNumber = spphoneNumber;
            Email = spemail;
            State = spstate;
            City = spcity;
            ZipCode = spzipCode;
        }
    }
}
