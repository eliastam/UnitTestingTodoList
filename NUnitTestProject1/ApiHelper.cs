using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace NUnitTestProject1
{
    public static class ApiHelper
    {
        public static HttpClient ApiClient { get; set; } = new HttpClient();

        public async static Task<IEnumerable<Object>> GetAllTodos()
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));
                HttpResponseMessage response =  client.GetAsync("http://localhost:4567/todos").Result;

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    XDocument xdoc = XDocument.Parse(response.Content.ReadAsStringAsync().Result);


                    var studentLst = xdoc.Descendants("todo").Select(d =>
                      new {
                          id = d.Element("id").Value,
                          doneStatus = d.Element("doneStatus").Value,
                          title = d.Element("title").Value,
                          description = d.Element("description").Value
                      }).ToList();

                    return studentLst;
                }
                else
                {
                    return Enumerable.Empty<Object>();
                }
            }

        }
    }
}
