using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using testAPI.Models;
using testAPI.Utility;

namespace testAPI.Repositary
{
    public class ContactInfo : IContactInfo
    {
        async Task<ContactModel> IContactInfo.AddorUpdateContact(ContactModel contactModel)
        {
            var model = new Models.ContactInfo
            {
                ContactId = contactModel.ContactId,
                Email = contactModel.Email,
                FirstName = contactModel.FirstName,
                LastName = contactModel.LastName,
                Phone = contactModel.Phone,
                Status = contactModel.Status
            };
            var ctx = new ContactsEntities();
            var contact = ctx.ContactInfoes.FirstOrDefault(x => x.Email == model.Email);

            if (contact == null)
            {
                // Add new contact to list
                ctx.ContactInfoes.Add(model);
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
            return new ContactModel
            {
                ContactId = contact.ContactId,
                Email = contact.Email,
                FirstName = contact.FirstName,
                LastName = contact.LastName,
                Phone = contact.Phone,
                Status = contact.Status
            };
        }

        async Task<ContactModel> IContactInfo.DeleteContact(int id)
        {
            var ctx = new ContactsEntities();
            var contact = ctx.ContactInfoes.Find(id);
            if (contact == null) throw new ContactException("No Data Found for given id");
            if (contact.Status == "Inactive")
            {
                contact.Status = "Active";
                // save contact object back to data base.
                await ctx.SaveChangesAsync();
                return new ContactModel
                {
                    ContactId = contact.ContactId,
                    Email = contact.Email,
                    FirstName = contact.FirstName,
                    LastName = contact.LastName,
                    Phone = contact.Phone,
                    Status = contact.Status
                };
            }

            contact.Status = "Inactive";
            // save contact object back to data base.
            await ctx.SaveChangesAsync();
            return new ContactModel
            {
                ContactId = contact.ContactId,
                Email = contact.Email,
                FirstName = contact.FirstName,
                LastName = contact.LastName,
                Phone = contact.Phone,
                Status = contact.Status
            };
        }

        async Task<List<ContactModel>> IContactInfo.GetContact()
        {
            var ctx = new ContactsEntities();
            var contacts = await ctx.ContactInfoes.ToListAsync();
            return contacts.ConvertAll(x => new ContactModel
            {
                ContactId = x.ContactId,
                Email = x.Email,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Phone = x.Phone,
                Status = x.Status
            });
        }
    }
}