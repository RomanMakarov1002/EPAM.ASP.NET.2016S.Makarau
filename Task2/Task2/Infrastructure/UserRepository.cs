using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task2.Models;

namespace Task2.Infrastructure
{
    public static class UserRepository
    {
        private static List<User> _users = new User[]
        {
            new User() {Id = 1, Name = "Alex", Surname = "Daniels"},
            new User() {Id = 2, Name = "Antony", Surname = "Taylor"}
        }.ToList();

        public static async Task Add(User user)
        {
            if (user != null)
            {
                await Task.Factory.StartNew(() =>
                {
                    user.Id = _users.Last().Id + 1;
                    _users.Add(user);
                });
            }
        }

        public static async Task<List<User>> GetAll()
        {
            return await Task.Factory.StartNew(() => _users);
        }

        public static async Task Delete(User user)
        {
            await Task.Factory.StartNew(() =>
            {
                var user1 = user;
                user = _users.Find(x => x.Id == user1.Id);
                _users.Remove(user);
            });
        }

        public static async Task<User> GetById(int id)
        {
            return await Task.Factory.StartNew(() => _users.Find(x => x.Id == id));
        }

        public static async Task Modify(User user)
        {
            await Task.Factory.StartNew(() =>
            {
                var user1 = user;
                user = _users.Find(x => x.Id == user1.Id);
                user.Name = user1.Name;
                user.Surname = user1.Surname;
            });
        }
    }
}