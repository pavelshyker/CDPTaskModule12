using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;

namespace WebServisesTests
{
    class GetDataFromWebService
    {
        public static HttpWebResponse MakeRequest(string method, string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = method;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            return response;
        }

        public static int GetResponseStatusCode(HttpWebResponse response)
        {
            int statusNumber = (int)response.StatusCode;
            return statusNumber;
        }

        public static string GetResponseBody(HttpWebResponse response)
        {
            string responseBody;

            using (Stream stream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    responseBody = reader.ReadToEnd();
                }
            }
            return responseBody;
        }

        public static string GetResponseHeader(HttpWebResponse response)
        {
            string header = response.GetResponseHeader("Content-Type");
            return header;
        }

        public static int GetCountOFUsersFromResponse(string responseBody)
        { 
            var objList = JsonConvert.DeserializeObject<List<User>>(responseBody);
            int objectsCount = objList.Count();
            return objectsCount;
        }

    }
}
