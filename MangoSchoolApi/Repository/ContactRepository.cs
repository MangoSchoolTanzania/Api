using MangoSchoolApi.Data;
using MangoSchoolApi.Models;
using MangoSchoolApi.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace MangoSchoolApi.Repository
{
    public class ContactRepository : IContactRepository
    {
        private readonly MangoDataContext _MangoDataContext;

        public ContactRepository(MangoDataContext MangoDataContext)
        {
            _MangoDataContext = MangoDataContext;
        }

        public async Task<Contact> GetContact(int id)
        {
            try
            {
                var result = await _MangoDataContext.Results
                    .FirstOrDefaultAsync(x => x.Id == id);

                return (Contact)result;
            }
            catch (Exception)
            {

                throw;
            }
        } 

        public async Task<List<Contact>> GetContacts()
        {
            try
            {
                var results = await _MangoDataContext.Contacts
                    .OrderByDescending(x => x.CreateDate)
                    .ToListAsync();

                return results;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Contact> PostContact(ContactViewModel contactVM)
        {
            try
            {
                var contact = new Contact();
                contact.Message = contactVM.Message;
                contact.Name = contactVM.Name;
                contact.Email = contactVM.Email;
                contact.CreateDate = DateTime.Now;

                _MangoDataContext.Contacts.Add(contact);
                _MangoDataContext.SaveChanges();

                return contact;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Contact> PutContact(ContactViewModel contactVM)
        {
            try
            {
                var contact = await GetContact(contactVM.Id);
                contact.Email = contactVM.Email;
                contact.Message = contactVM.Message;
                contact.Name = contactVM.Name;

                _MangoDataContext.Contacts.Add(contact);
                _MangoDataContext.SaveChanges();

                return contact;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Contact> DeleteContact(ContactViewModel contactVM)
        {
            try
            {
                var contact = await GetContact(contactVM.Id);
                _MangoDataContext.Remove(contact);
                _MangoDataContext.SaveChanges();

                return contact;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
