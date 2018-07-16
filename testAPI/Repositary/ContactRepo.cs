using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using testAPI.Models;
using testAPI.Utility;

namespace testAPI.Repositary
{
    public class ContactRepo : IContactRepo
    {
        async Task<ContactModel> IContactRepo.AddorUpdateContact(ContactModel contactModel)
        {
            var model = new ContactInfo
            {
                ContactId = contactModel.ContactId,
                Email = contactModel.Email,
                FirstName = contactModel.FirstName,
                LastName = contactModel.LastName,
                Phone = contactModel.Phone,
                Status = contactModel.Status
            };

            using (var ctx = new ContactsEntities())
            {
                var contact = ctx.ContactInfoes.FirstOrDefault(x => x.Email == model.Email);

                if (contact == null)
                {
                    // Add new contact to list
                    ctx.ContactInfoes.Add(model);
                    await ctx.SaveChangesAsync();
                    return contactModel;
                }

                contact.Phone = contactModel.Phone;
                contact.FirstName = contactModel.FirstName;
                contact.LastName = contactModel.LastName;
                contact.Status = contactModel.Status;
                await ctx.SaveChangesAsync();
                return contactModel;
            }
        }

        async Task<ContactModel> IContactRepo.DeleteContact(int id)
        {
            using (var ctx = new ContactsEntities())
            {
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
        }

        async Task<List<ContactModel>> IContactRepo.GetContact()
        {
            using (var ctx = new ContactsEntities())
            {
                var contacts = await ctx.ContactInfoes.ToListAsync();
                if (!contacts.Any()) throw new ContactException("No Data Found for given id");
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
}