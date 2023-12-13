using MangoSchoolApi.Models.Models;
using MangoSchoolApi.Models.ViewModel;

namespace MangoSchoolApi.Repository
{
    public interface IContactRepository
    {
        public Task<Contact> GetContact(int id);
        public Task<List<Contact>> GetContacts();
        public Task<Contact> PostContact(ContactViewModel contactVM);
        public Task<Contact> PutContact(ContactViewModel contactVM);
        public Task<Contact> DeleteContact(int id);
    }
}
