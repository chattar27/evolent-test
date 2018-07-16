using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using testAPI.Controllers;
using testAPI.Models;
using testAPI.Repositary;

namespace TestAPI.Test.Controllers
{
    [TestClass]
    public class ContactApiControllerTest
    {
        private ContactApiController _apiController;
        private Mock<IContactRepo> _mockContactInfo;
        private ContactModel _contact;

        [TestInitialize]
        public void TestInitialize()
        {
            _contact = new ContactModel
            {
                ContactId = 1,
                Email = "as.ad@test.com",
                FirstName = "asd",
                LastName = "der",
                Phone = "1231231234",
                Status = "Active"
            };
            _mockContactInfo = new Mock<IContactRepo>();
            _apiController = new ContactApiController(_mockContactInfo.Object);
        }

        [TestMethod]
        public async Task GetContactsReturnsValidResponse()
        {
            _mockContactInfo.Setup(x => x.GetContact()).ReturnsAsync(new List<ContactModel> { _contact });
            var result = await _apiController.GetContacts();
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(OkNegotiatedContentResult<List<ContactModel>>));
        }

        [TestMethod]
        public async Task AddContactReturnsValidResponse()
        {
            _mockContactInfo.Setup(x => x.AddorUpdateContact(It.IsAny<ContactModel>())).ReturnsAsync(_contact);
            var result = await _apiController.AddContacts(_contact);
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(OkNegotiatedContentResult<ContactModel>));
        }

        [TestMethod]
        public async Task UpdateContactReturnsValidResponse()
        {
            _mockContactInfo.Setup(x => x.AddorUpdateContact(It.IsAny<ContactModel>())).ReturnsAsync(_contact);
            var result = await _apiController.EditContact(_contact);
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(OkNegotiatedContentResult<ContactModel>));
        }

        [TestMethod]
        public async Task DeleteContactReturnsValidResponse()
        {
            _mockContactInfo.Setup(x => x.DeleteContact(It.IsAny<int>())).ReturnsAsync(_contact);
            var result = await _apiController.DeleteContact(2);
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(OkNegotiatedContentResult<ContactModel>));
        }
    }
}