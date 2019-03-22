using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using WebServisesTests;

namespace WebServises
{
    [TestClass]
    public class WebServisesTests
    {
        private const string url = "https://jsonplaceholder.typicode.com/users";
        private const string method = "GET";


        [TestMethod]
        public void ResponseStatusCodeVerificationTest()
        {
            int expectedStatusCode = 200;
            HttpWebResponse response = GetDataFromWebService.MakeRequest(method, url);

            Assert.AreEqual(expectedStatusCode, GetDataFromWebService.GetResponseStatusCode(response));
        }

        [TestMethod]
        public void ResponseHeaderExistsVerificationTest()
        {
            HttpWebResponse response = GetDataFromWebService.MakeRequest(method, url);

            Assert.IsTrue(GetDataFromWebService.GetResponseHeader(response) != null);
        }

        [TestMethod]
        public void ResponseHeaderValueVerificationTest()
        {
            string expectedHeaderValue = "application/json; charset=utf-8";
            HttpWebResponse response = GetDataFromWebService.MakeRequest(method, url);

            Assert.AreEqual(expectedHeaderValue, GetDataFromWebService.GetResponseHeader(response));
        }

        [TestMethod]
        public void ResponseBodyContentVerificationTest()
        {
            int expectedNumberOfUsers = 10;
            HttpWebResponse response = GetDataFromWebService.MakeRequest(method, url);
            string responseBody = GetDataFromWebService.GetResponseBody(response);

            Assert.AreEqual(expectedNumberOfUsers, GetDataFromWebService.GetCountOFUsersFromResponse(responseBody));
        }
    }
}
