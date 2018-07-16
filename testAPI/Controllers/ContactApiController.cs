using System.Threading.Tasks;
using System.Web.Http;
using testAPI.Models;
using testAPI.Repositary;

namespace testAPI.Controllers
{
    [RoutePrefix("Api/Contacts")]
    public class ContactApiController : ApiController
    {
        private readonly IContactRepo _contactInfo;

        public ContactApiController(IContactRepo contactInfo)
        {
            _contactInfo = contactInfo;
        }

        [HttpGet, Route("Get")]
        public async Task<IHttpActionResult> GetContacts()
        {
            var contacts = await _contactInfo.GetContact();

            return Ok(contacts);
        }

        [HttpPost, Route("Create")]
        public async Task<IHttpActionResult> AddContacts([FromBody] ContactModel contactModel)
        {
            if (!ModelState.IsValid)
            {
                // return bad request with validation massage.
                return BadRequest(ModelState);
            }
            var contact = await _contactInfo.AddorUpdateContact(contactModel);
            return Ok(contact);
        }

        [HttpPut, Route("Update")]
        public async Task<IHttpActionResult> EditContact([FromBody] ContactModel contactModel)
        {
            if (!ModelState.IsValid)
            {
                // return bad request with validation massage.
                return BadRequest(ModelState);
            }
            var contact = await _contactInfo.AddorUpdateContact(contactModel);
            return Ok(contact);
        }

        [HttpDelete, Route("Delete")]
        public async Task<IHttpActionResult> DeleteContact(int id)
        {
            if (!ModelState.IsValid)
            {
                // return bad request with validation massage.
                return BadRequest(ModelState);
            }

            var contact = await _contactInfo.DeleteContact(id);
            return Ok(contact);
        }
    }
}