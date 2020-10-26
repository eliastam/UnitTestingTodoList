using NUnitTestProject1.Entities;
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
        public async static Task<int> GetAnId()
        {
            var id = 0;
            var list = await GetAllCategories();
            if (list.Any())
            {
                id = list.First().id;
            }
            return id;
        }
        public async static Task<IEnumerable<Object>> GetAllTodos()
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));
                HttpResponseMessage response = client.GetAsync("http://localhost:4567/todos").Result;

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    XDocument xdoc = XDocument.Parse(response.Content.ReadAsStringAsync().Result);


                    var studentLst = xdoc.Descendants("todo").Select(d =>
                      new Todo
                      {
                          id = Int32.Parse(d.Element("id").Value),
                          doneStatus = bool.Parse(d.Element("doneStatus").Value),
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

        public async static Task CreateTodo(string doneStatus, string description, string title)
        {
            var httpClient = new HttpClient();
            var someXmlString = $"<todo><doneStatus>{doneStatus}</doneStatus><description>{description}</description><title>{title}</title></todo>";


            var stringContent = new StringContent(someXmlString, Encoding.UTF8, "application/xml");
            var respone = await httpClient.PostAsync("http://localhost:4567/todos", stringContent);

        }

        #region /categroy
        public async static Task<HttpResponseMessage> GetCategories()
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));
                HttpResponseMessage response = client.GetAsync("http://localhost:4567/categories").Result;
                return response;
            }

        }
        public async static Task<IEnumerable<Category>> GetAllCategories()
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));
                HttpResponseMessage response = client.GetAsync("http://localhost:4567/categories").Result;

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    XDocument xdoc = XDocument.Parse(response.Content.ReadAsStringAsync().Result);


                    var Categorylst = xdoc.Descendants("category").Select(d =>
                      new Category
                      {
                          id = Int32.Parse(d.Element("id").Value),
                          title = d.Element("title").Value,
                          description = d.Element("description").Value
                      }).ToList();

                    return Categorylst;
                }
                else
                {
                    return Enumerable.Empty<Category>();
                }
            }

        }
        public async static Task<HttpResponseMessage> PutCategories()
        {
            var xmlValue = "<category><description/><id>1</id><title> putValue</title></category>";
            var stringContent = new StringContent(xmlValue, Encoding.UTF8, "application/xml");
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));
                var response = await client.PutAsync("http://localhost:4567/categories", stringContent);
                return response;
            }

        }
        public async static Task<HttpResponseMessage> createCategorySuccessfully()
        {
            var httpClient = new HttpClient();
            var someXmlString = $"<category><description>description</description><title>PostValue</title></category>";


            var stringContent = new StringContent(someXmlString, Encoding.UTF8, "application/xml");
            var respone = await httpClient.PostAsync("http://localhost:4567/categories", stringContent);
            return respone;
        }
        public async static Task<HttpResponseMessage> createCategoryUnsuccessfully()
        {
            var httpClient = new HttpClient();
            var someXmlString = $"<category><description>description</description><title/>category>";


            var stringContent = new StringContent(someXmlString, Encoding.UTF8, "application/xml");
            var respone = await httpClient.PostAsync("http://localhost:4567/categories", stringContent);
            return respone;
        }
        public async static Task<HttpResponseMessage> createCategorySuccessfullyWithoutDescription()
        {
            var httpClient = new HttpClient();
            var someXmlString = $"<category><description/><title>PostValue</title></category>";


            var stringContent = new StringContent(someXmlString, Encoding.UTF8, "application/xml");
            var respone = await httpClient.PostAsync("http://localhost:4567/categories", stringContent);
            return respone;
        }
        public async static Task<HttpResponseMessage> DeleteCategory()
        {

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));
                var response = await client.DeleteAsync("http://localhost:4567/categories");
                return response;
            }

        }
        public async static Task<HttpResponseMessage> PatchCategory()
        {
            var xmlValue = "<category><description/><id>1</id><title> putValue</title></category>";
            var stringContent = new StringContent(xmlValue, Encoding.UTF8, "application/xml");
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));
                var response = await client.PatchAsync("http://localhost:4567/categories", stringContent);
                return response;
            }
        }
        #endregion

        #region /categroy/id
        public async static Task<HttpResponseMessage> GetCategoryById(int id)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));
                HttpResponseMessage response = client.GetAsync($"http://localhost:4567/categories/{id}").Result;

                return response;
            }

        }
        public async static Task<HttpResponseMessage> GetCategoryByIdString(string id)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));
                HttpResponseMessage response = client.GetAsync($"http://localhost:4567/categories/{id}").Result;

                return response;
            }

        }

        public async static Task<Category> GetCategoryByIdObj(int id)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));
                HttpResponseMessage response = client.GetAsync($"http://localhost:4567/categories/{id}").Result;

                XDocument xdoc = XDocument.Parse(response.Content.ReadAsStringAsync().Result);

                var categories = xdoc.Descendants("category").Select(d =>
                  new Category
                  {
                      id = Int32.Parse(d.Element("id").Value),
                      title = d.Element("title").Value,
                      description = d.Element("description").Value
                  }).ToList();
                return categories.FirstOrDefault();
            }


        }

        public async static Task<HttpResponseMessage> putCategoryById(int id, string title, string description)
        {
            var xmlValue = $"<category><description>{description}</description><title>{title}</title></category>";
            var stringContent = new StringContent(xmlValue, Encoding.UTF8, "application/xml");
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));
                var response = await client.PutAsync($"http://localhost:4567/categories/{id}", stringContent);
                return response;
            }

        }
        public async static Task<HttpResponseMessage> PostCategoryById(int id, string title, string description)
        {
            var xmlValue = $"<category><description>{description}</description><title>{title}</title></category>";
            var stringContent = new StringContent(xmlValue, Encoding.UTF8, "application/xml");
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));
                var response = await client.PostAsync($"http://localhost:4567/categories/{id}", stringContent);
                return response;
            }

        }

        public async static Task<HttpResponseMessage> DeleteCategoryById(int id)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));
                var response = await client.DeleteAsync($"http://localhost:4567/categories/{id}");
                return response;
            }

        }
        public async static Task<HttpResponseMessage> PatchCategoryById(int id)
        {
            var xmlValue = "<category><description/><title>patchValue</title></category>";
            var stringContent = new StringContent(xmlValue, Encoding.UTF8, "application/xml");
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));
                var response = await client.PatchAsync($"http://localhost:4567/categories/{id}", stringContent);
                return response;
            }

        }
        #endregion

        #region /categroy/id/projects
        public async static Task<HttpResponseMessage> CreateCategoryProjectRelationship(int categoryId, int projectId)
        {
            var httpClient = new HttpClient();
            var someXmlString = $"<projects><id>1</id></projects>";


            var stringContent = new StringContent(someXmlString, Encoding.UTF8, "application/xml");
            var respone = await httpClient.PostAsync($"http://localhost:4567/categories/{categoryId}/projects", stringContent);
            return respone;
        }

        public async static Task<HttpResponseMessage> DeleteCategoryIdProjects(int categoryId)
        {
            var httpClient = new HttpClient();


            var respone = await httpClient.DeleteAsync($"http://localhost:4567/categories/{categoryId}/projects");
            return respone;
        }
        public async static Task<HttpResponseMessage> GetCategoryIdProject(int categoryId)
        {
            var httpClient = new HttpClient();

            var respone = await httpClient.GetAsync($"http://localhost:4567/categories/{categoryId}/projects");
            return respone;
        }


        public async static Task<HttpResponseMessage> GetCategoryIdStringProject(string categoryId)
        {
            var httpClient = new HttpClient();

            var respone = await httpClient.GetAsync($"http://localhost:4567/categories/{categoryId}/projects");
            return respone;
        }
        #endregion

        #region /categroy/id/projects/id

        public async static Task<HttpResponseMessage> PostCategoryIdProjectId(int categoryId, int projectId)
        {
            var httpClient = new HttpClient();
            var someXmlString = $"<projects><id>1</id></projects>";


            var stringContent = new StringContent(someXmlString, Encoding.UTF8, "application/xml");
            var respone = await httpClient.PostAsync($"http://localhost:4567/categories/{categoryId}/projects/{projectId}", stringContent);
            return respone;
        }
        public async static Task<HttpResponseMessage> PutCategoryIdProjectId(int categoryId, int projectId)
        {
            var httpClient = new HttpClient();
            var someXmlString = $"<projects><id>1</id></projects>";


            var stringContent = new StringContent(someXmlString, Encoding.UTF8, "application/xml");
            var respone = await httpClient.PutAsync($"http://localhost:4567/categories/{categoryId}/projects/{projectId}", stringContent);
            return respone;
        }
        public async static Task<HttpResponseMessage> PatchCategoryIdProjectId(int categoryId, int projectId)
        {
            var httpClient = new HttpClient();
            var someXmlString = $"<projects><id>1</id></projects>";


            var stringContent = new StringContent(someXmlString, Encoding.UTF8, "application/xml");
            var respone = await httpClient.PatchAsync($"http://localhost:4567/categories/{categoryId}/projects/{projectId}", stringContent);
            return respone;
        }
        public async static Task<HttpResponseMessage> DeleteCategoryIdProjectsId(int categoryId, int projectId)
        {
            var httpClient = new HttpClient();


            var respone = await httpClient.DeleteAsync($"http://localhost:4567/categories/{categoryId}/projects/{projectId}");
            return respone;
        }
        public async static Task<HttpResponseMessage> GetCategoryIdProjectId(int categoryId, int projectId)
        {
            var httpClient = new HttpClient();

            var respone = await httpClient.GetAsync($"http://localhost:4567/categories/{categoryId}/projects/{projectId}");
            return respone;
        }


        #endregion

        #region/categories/:id/todos
        public async static Task<HttpResponseMessage> GetCategoryIdTodos(int categoryId)
        {
            var httpClient = new HttpClient();
           
            var respone = await httpClient.GetAsync($"http://localhost:4567/categories/{categoryId}/todos");
            return respone;
        }

        public async static Task<HttpResponseMessage> PostCategoryIdTodos(int categoryId)
        {
            var httpClient = new HttpClient();
            var someXmlString = $"<todo><doneStatus>false</doneStatus><description>ddd</description><title>title</title></todo>";


            var stringContent = new StringContent(someXmlString, Encoding.UTF8, "application/xml");
            var respone = await httpClient.PostAsync($"http://localhost:4567/categories/{categoryId}/todos", stringContent);
            return respone;
        }
        public async static Task<HttpResponseMessage> PostCategoryIdTodoswithError(int categoryId)
        {
            var httpClient = new HttpClient();
            var someXmlString = $"<todo><doneStatus>false</doneStatus><description>ddd</description></todo>";


            var stringContent = new StringContent(someXmlString, Encoding.UTF8, "application/xml");
            var respone = await httpClient.PostAsync($"http://localhost:4567/categories/{categoryId}/todos", stringContent);
            return respone;
        }
        public async static Task<HttpResponseMessage> PutCategoryIdTodos(int categoryId)
        {
            var httpClient = new HttpClient();
            var someXmlString = $"<todo><doneStatus>false</doneStatus><description>ddd</description><title>title</title></todo>";


            var stringContent = new StringContent(someXmlString, Encoding.UTF8, "application/xml");
            var respone = await httpClient.PutAsync($"http://localhost:4567/categories/{categoryId}/todos", stringContent);
            return respone;
        }
        public async static Task<HttpResponseMessage> PatchCategoryIdTodos(int categoryId)
        {
            var httpClient = new HttpClient();
            var someXmlString = $"<todo><doneStatus>false</doneStatus><description>ddd</description><title>title</title></todo>";


            var stringContent = new StringContent(someXmlString, Encoding.UTF8, "application/xml");
            var respone = await httpClient.PatchAsync($"http://localhost:4567/categories/{categoryId}/todos", stringContent);
            return respone;
        }

        public async static Task<HttpResponseMessage> DeleteCategoryIdTodos(int categoryId)
        {
            var httpClient = new HttpClient();

            var respone = await httpClient.DeleteAsync($"http://localhost:4567/categories/{categoryId}/todos");
            return respone;
        }



        #endregion

        #region/categories/:id/todos
        public async static Task<HttpResponseMessage> GetCategoryIdTodosId(int categoryId, int todoId)
        {
            var httpClient = new HttpClient();

            var respone = await httpClient.GetAsync($"http://localhost:4567/categories/{categoryId}/todos/{todoId}");
            return respone;
        }


        public async static Task<HttpResponseMessage> PostCategoryIdTodosId(int categoryId, int todoId)
        {
            var httpClient = new HttpClient();
            var someXmlString = $"<todo><doneStatus>false</doneStatus><description>ddd</description><title>title</title></todo>";


            var stringContent = new StringContent(someXmlString, Encoding.UTF8, "application/xml");
            var respone = await httpClient.PostAsync($"http://localhost:4567/categories/{categoryId}/todos/{todoId}", stringContent);
            return respone;
        }

        public async static Task<HttpResponseMessage> PutCategoryIdTodosId(int categoryId, int todoId)
        {
            var httpClient = new HttpClient();
            var someXmlString = $"<todo><doneStatus>false</doneStatus><description>ddd</description><title>title</title></todo>";


            var stringContent = new StringContent(someXmlString, Encoding.UTF8, "application/xml");
            var respone = await httpClient.PutAsync($"http://localhost:4567/categories/{categoryId}/todos/{todoId}", stringContent);
            return respone;
        }
        public async static Task<HttpResponseMessage> PatchCategoryIdTodosId(int categoryId, int todoId)
        {
            var httpClient = new HttpClient();
            var someXmlString = $"<todo><doneStatus>false</doneStatus><description>ddd</description><title>title</title></todo>";


            var stringContent = new StringContent(someXmlString, Encoding.UTF8, "application/xml");
            var respone = await httpClient.PatchAsync($"http://localhost:4567/categories/{categoryId}/todos/{todoId}", stringContent);
            return respone;
        }
        #endregion
    }
}
