using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using testAPI.Controllers;
using testAPI.Repositary;
using ContactInfo = testAPI.Models.ContactInfo;

namespace TestAPI.Test.Controllers
{
    [TestClass]
    public class ContactApiControllerTest
    {
        private ContactApiController _apiController;
        private Mock<IContactInfo> _mockContactInfo;
        private ContactInfo _contactInfo;

        [TestInitialize]
        public void TestInitialize()
        {
            _contactInfo = new ContactInfo
            {
                ContactId = 1,
                Email = "as.ad@test.com",
                FirstName = "asd",
                LastName = "der",
                Phone = "1231231234",
                Status = "Active"
            };
            _mockContactInfo = new Mock<IContactInfo>();
            _apiController = new ContactApiController(_mockContactInfo.Object);
        }

        [TestMethod]
        public async Task GetContactsReturnsValidResponse()
        {
            _mockContactInfo.Setup(x => x.GetContact()).ReturnsAsync(new List<ContactInfo> { _contactInfo });
            var result = await _apiController.GetContacts();
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(OkNegotiatedContentResult<List<ContactInfo>>));
        }

        [TestMethod]
        public async Task AddContactReturnsValidResponse()
        {
            _mockContactInfo.Setup(x => x.GetContact()).ReturnsAsync(new List<ContactInfo> { _contactInfo });
            var result = await _apiController.AddContacts(_contactInfo);
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(OkNegotiatedContentResult<ContactInfo>));
        }

        [TestMethod]
        public async Task UpdateContactReturnsValidResponse()
        {
            _mockContactInfo.Setup(x => x.GetContact()).ReturnsAsync(new List<ContactInfo> { _contactInfo });
            var result = await _apiController.EditContact(_contactInfo);
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(OkNegotiatedContentResult<ContactInfo>));
        }

        [TestMethod]
        public async Task DeleteContactReturnsValidResponse()
        {
            _mockContactInfo.Setup(x => x.GetContact()).ReturnsAsync(new List<ContactInfo> { _contactInfo });
            var result = await _apiController.DeleteContact(2);
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(OkNegotiatedContentResult<ContactInfo>));
        }
    }
}