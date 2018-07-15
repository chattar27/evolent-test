using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using testAPI.Models;
using testAPI.Utility;

namespace testAPI.Repositary
{
    public class ContactInfo : IContactInfo
    {
        async Task<Models.ContactInfo> IContactInfo.AddorUpdateContact(Models.ContactInfo contactModel)
        {
            var ctx = new ContactsEntities();
            var contact = ctx.ContactInfoes.FirstOrDefault(x => x.Email == contactModel.Email);

            if (contact == null)
            {
                // Add new contact to list
                ctx.ContactInfoes.Add(contactModel);
                await ctx.SaveChangesAsync();
                return contactModel;
            }

            //update existing contact
            contact.Email = contactModel.Email;
            contact.Phone = contactModel.Phone;
            contact.FirstName = contactModel.FirstName;
            contact.LastName = contactModel.LastName;
            contact.Status = contactModel.Status;
            await ctx.SaveChangesAsync();
            return contact;
        }

        async Task<Models.ContactInfo> IContactInfo.DeleteContact(int id)
        {
            var ctx = new ContactsEntities();
            var contact = ctx.ContactInfoes.Find(id);
            if (contact == null) throw new ContactException("No Data Found for given id");
            if (contact.Status == "Inactive")
            {
                contact.Status = "Active";
                // save contact object back to data base.
                await ctx.SaveChangesAsync();
                return contact;
            }

            contact.Status = "Inactive";
            // save contact object back to data base.
            await ctx.SaveChangesAsync();
            return contact;
        }

        async Task<List<Models.ContactInfo>> IContactInfo.GetContact()
        {
            var ctx = new ContactsEntities();
            var contacts = await ctx.ContactInfoes.ToListAsync();
            return contacts;
        }
    }
}