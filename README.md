# evolent-test
assignment given by evolent

Application - REST- API for contact Info
Language - C#, Web API 2, SQL SERVER, EF and VS 2017 (.net framework 4.6)
Folder structure
testAPI - project code solition
App_Data folder contains database file
App_Start folder contains 
UnityConfig.cs - code for dependancy resolver.
WebApiConfig.cs - code for enabling attribute base routing and custom filters.
Controllers folder contain ContactApiController.cs - which has all API methods
Filters folder contain custome filter
Models folder contains edmx file
Repositary folder contains Interface and class for accessing database.
Utility Folder contains custom exception class
TestAPI.Test solution contains unit test cases.
How to run -
clone/download project you can host application on iis or directly run it.

Get API
http://localhost:54318/Api/Contacts/get

Create API
http://localhost:54318/Api/Contacts/Create
payload-body
{
        "FirstName": "chris",
        "LastName": "tens",
        "Email": "chris.tens@test.com",
        "Phone": "8080808070",
        "Status": "Active"
    }

Update API
payload-body
http://localhost:54318/Api/Contacts/Update
{
        "ContactId": 2,
        "FirstName": "chris",
        "LastName": "tens",
        "Email": "chris.tens@test.com",
        "Phone": "70808080",
        "Status": "Active"
    }

delete API
http://localhost:54318/Api/Contacts/delete/?id=1

