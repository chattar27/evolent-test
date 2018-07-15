using System.Collections.Generic;
using System.Threading.Tasks;

namespace testAPI.Repositary
{
    public interface IContactInfo
    {
        Task<List<Models.ContactInfo>> GetContact();

        Task<Models.ContactInfo> AddorUpdateContact(Models.ContactInfo contact);

        Task<Models.ContactInfo> DeleteContact(int id);
    }
}