using System.Collections.Generic;
using System.Linq;
using Task4.Models;

namespace Task4.Infrastructure
{
    public static class PersonRepository
    {
        private static List<Person> _persons = new List<Person>() {new Person() {FirstName = "Alex", LastName = "Jason", Id = 1} };

        public static List<Person> GetAll()
        {
            return _persons;
        }

        public static void Add(Person person)
        {
            _persons.Add(person);
        }

        public static Person GetByName(string name)
        {
            return _persons.FirstOrDefault(x => x.FirstName == name);
        } 
    }
}