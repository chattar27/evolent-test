using System.Collections.Generic;
using System.Threading.Tasks;
using testAPI.Models;

namespace testAPI.Repositary
{
    public interface IContactInfo
    {
        Task<List<ContactModel>> GetContact();

        Task<ContactModel> AddorUpdateContact(ContactModel contact);

        Task<ContactModel> DeleteContact(int id);
    }
}