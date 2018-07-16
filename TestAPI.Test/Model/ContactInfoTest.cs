using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Hosting;
using System.Web.Http.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using testAPI.Controllers;
using testAPI.Models;
using testAPI.Repositary;
using ContactInfo = testAPI.Models.ContactInfo;

namespace TestAPI.Test.Model
{
    [TestClass]
    public class ContactInfoTest
    {
        private ContactModel _contact;
        private ContactApiController _apiController;
        private Mock<IContactRepo> _mockContactInfo;

        [TestInitialize]
        public void TestInitialize()
        {
            _mockContactInfo = new Mock<IContactRepo>();
            _apiController = new ContactApiController(_mockContactInfo.Object)
            {
                Request = new HttpRequestMessage()
                {
                    Properties = { { HttpPropertyKeys.HttpConfigurationKey, new HttpConfiguration() } }
                }
            };
        }

        [TestMethod]
        public async Task ValidContactInfoModel()
        {
            _contact = new ContactModel
            {
                Email = "as.ad@test.com",
                FirstName = "asd",
                LastName = "der",
                Phone = "1231231234",
                Status = "Active"
            };
            _apiController.Validate(_contact);
            var result = await _apiController.AddContacts(_contact);
        }
    }
}