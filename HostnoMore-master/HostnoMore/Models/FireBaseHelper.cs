using HostnoMore.Models;
using Firebase.Database;
using Firebase.Database.Query;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace HostnoMore.Helper
{
    public class FirebaseHelper
    {
        FirebaseClient firebase = new FirebaseClient("https://hostnodatabase.firebaseio.com/");
        public async Task<List<Person>> GetAllPersons()
        {
            return (await firebase
              .Child("Persons")
              .OnceAsync<Person>()).Select(item => new Person
              {
                  Name = item.Object.Name,
                  Email = item.Object.Email,
                  Password = item.Object.Password
              }).ToList();
        }
        public async Task AddPerson(string email, string name, string password)
        {
            await firebase
              .Child("Persons")
              .PostAsync(new Person() { Email = email, Name = name, Password = password });
        }

        public async Task<Person> GetPerson(string name, string password)
        {
            var allPersons = await GetAllPersons();
            await firebase
              .Child("Persons")
              .OnceAsync<Person>();
            return allPersons.Where(a => a.Name == name && a.Password == password).FirstOrDefault();
        }
        public async Task UpdatePerson(string email, string name, string password)
        {
            var toUpdatePerson = (await firebase
              .Child("Persons")
              .OnceAsync<Person>()).Where(a => a.Object.Name == name && a.Object.Password == password).FirstOrDefault();
            await firebase
              .Child("Persons")
              .Child(toUpdatePerson.Key)
              .PutAsync(new Person() { Email = email, Name = name, Password = password });
        }
        public async Task DeletePerson(string name, string password)
        {
            var toDeletePerson = (await firebase
              .Child("Persons")
              .OnceAsync<Person>()).Where(a => a.Object.Name == name && a.Object.Password == password).FirstOrDefault();
            await firebase.Child("Persons").Child(toDeletePerson.Key).DeleteAsync();
        }
    }
}

