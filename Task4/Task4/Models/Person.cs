using System;
using System.Web.Mvc;
using Task4.Infrastructure;

namespace Task4.Models
{
    [ModelBinder(typeof(PersonModelBinder))]
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DOB { get; set; }
        public Address HomeAddress { get; set; }
        public Role Role { get; set; }
    }

    [ModelBinder(typeof(AddressModelBInder))]
    public class Address
    {
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string AddressSummary { get; set; }

    }

    public enum Role
    {
        Admin,
        User,
        Guest
    }
}