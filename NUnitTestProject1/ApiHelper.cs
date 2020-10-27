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
        #region todos
        public async static Task<int> GetATodoId()
        {
            var id = 0;
            var list = await GetAllTodos();
            if (list.Any())
            {
                id = list.First().id;
            }
            return id;
        }
        #region /todos
        public async static Task<IEnumerable<Todo>> GetAllTodos()
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
                    return Enumerable.Empty<Todo>();
                }
            }

        }
        public async static Task<HttpResponseMessage> GetTodos()
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));
                var response = client.GetAsync("http://localhost:4567/todos").Result;

                return response;

            }

        }
        public async static Task<HttpResponseMessage> CreateTodo(string doneStatus, string description, string title)
        {
            var httpClient = new HttpClient();
            var someXmlString = $"<todo><doneStatus>{doneStatus}</doneStatus><description>{description}</description><title>{title}</title></todo>";


            var stringContent = new StringContent(someXmlString, Encoding.UTF8, "application/xml");
            var respone = await httpClient.PostAsync("http://localhost:4567/todos", stringContent);
            return respone;

        }

        public async static Task<HttpResponseMessage> PutTodo(string doneStatus, string description, string title)
        {
            var httpClient = new HttpClient();
            var someXmlString = $"<todo><doneStatus>{doneStatus}</doneStatus><description>{description}</description><title>{title}</title></todo>";


            var stringContent = new StringContent(someXmlString, Encoding.UTF8, "application/xml");
            var response = await httpClient.PutAsync("http://localhost:4567/todos", stringContent);
            return response;
        }
        public async static Task<HttpResponseMessage> PatchTodo(string doneStatus, string description, string title)
        {
            var httpClient = new HttpClient();
            var someXmlString = $"<todo><doneStatus>{doneStatus}</doneStatus><description>{description}</description><title>{title}</title></todo>";


            var stringContent = new StringContent(someXmlString, Encoding.UTF8, "application/xml");
            var response = await httpClient.PatchAsync("http://localhost:4567/todos", stringContent);
            return response;
        }

        public async static Task<HttpResponseMessage> DeleteTodo()
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));
                var response = client.DeleteAsync("http://localhost:4567/todos").Result;

                return response;

            }

        }
        #endregion

        #region /todos/id
        public async static Task<HttpResponseMessage> GetTodosId(int id)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));
                var response = client.GetAsync($"http://localhost:4567/todos/{id}").Result;

                return response;

            }

        }
        public async static Task<HttpResponseMessage> GetTodosId(string id)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));
                var response = client.GetAsync($"http://localhost:4567/todos/{id}").Result;

                return response;

            }

        }
        public async static Task<HttpResponseMessage> PostTodoId(int id, string doneStatus, string description, string title)
        {
            var httpClient = new HttpClient();
            var someXmlString = $"<todo><doneStatus>{doneStatus}</doneStatus><description>{description}</description><title>{title}</title></todo>";


            var stringContent = new StringContent(someXmlString, Encoding.UTF8, "application/xml");
            var respone = await httpClient.PostAsync($"http://localhost:4567/todos/{id}", stringContent);
            return respone;

        }
        public async static Task<HttpResponseMessage> PostTodoId(string id, string doneStatus, string description, string title)
        {
            var httpClient = new HttpClient();
            var someXmlString = $"<todo><doneStatus>{doneStatus}</doneStatus><description>{description}</description><title>{title}</title></todo>";


            var stringContent = new StringContent(someXmlString, Encoding.UTF8, "application/xml");
            var respone = await httpClient.PostAsync($"http://localhost:4567/todos/{id}", stringContent);
            return respone;

        }
        public async static Task<HttpResponseMessage> PutTodoId(int id, string doneStatus, string description, string title)
        {
            var httpClient = new HttpClient();
            var someXmlString = $"<todo><doneStatus>{doneStatus}</doneStatus><description>{description}</description><title>{title}</title></todo>";


            var stringContent = new StringContent(someXmlString, Encoding.UTF8, "application/xml");
            var respone = await httpClient.PutAsync($"http://localhost:4567/todos/{id}", stringContent);
            return respone;

        }
        public async static Task<HttpResponseMessage> PutTodoId(string id, string doneStatus, string description, string title)
        {
            var httpClient = new HttpClient();
            var someXmlString = $"<todo><doneStatus>{doneStatus}</doneStatus><description>{description}</description><title>{title}</title></todo>";


            var stringContent = new StringContent(someXmlString, Encoding.UTF8, "application/xml");
            var respone = await httpClient.PutAsync($"http://localhost:4567/todos/{id}", stringContent);
            return respone;

        }

        public async static Task<HttpResponseMessage> PatchTodoId(int id, string doneStatus, string description, string title)
        {
            var httpClient = new HttpClient();
            var someXmlString = $"<todo><doneStatus>{doneStatus}</doneStatus><description>{description}</description><title>{title}</title></todo>";


            var stringContent = new StringContent(someXmlString, Encoding.UTF8, "application/xml");
            var respone = await httpClient.PatchAsync($"http://localhost:4567/todos/{id}", stringContent);
            return respone;

        }
        public async static Task<HttpResponseMessage> PatchTodoId(string id, string doneStatus, string description, string title)
        {
            var httpClient = new HttpClient();
            var someXmlString = $"<todo><doneStatus>{doneStatus}</doneStatus><description>{description}</description><title>{title}</title></todo>";


            var stringContent = new StringContent(someXmlString, Encoding.UTF8, "application/xml");
            var respone = await httpClient.PatchAsync($"http://localhost:4567/todos/{id}", stringContent);
            return respone;

        }

        public async static Task<HttpResponseMessage> DeleteTodosId(int id)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));
                var response = client.DeleteAsync($"http://localhost:4567/todos/{id}").Result;

                return response;

            }

        }
        public async static Task<HttpResponseMessage> DeleteTodosId(string id)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));
                var response = client.DeleteAsync($"http://localhost:4567/todos/{id}").Result;

                return response;

            }

        }
        #endregion


        #region /todos/:id/tasksof

        public async static Task<HttpResponseMessage> GetTodosIdTaskof(int id)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));
                var response = client.GetAsync($"http://localhost:4567/todos/{id}/tasksof").Result;

                return response;

            }

        }
        public async static Task<HttpResponseMessage> GetTodosIdTaskof(string id)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));
                var response = client.GetAsync($"http://localhost:4567/todos/{id}/tasksof").Result;

                return response;

            }

        }

        public async static Task<HttpResponseMessage> PutTodoIdTaskof(int id, string doneStatus, string description, string title)
        {
            var httpClient = new HttpClient();
            var someXmlString = $"<todo><doneStatus>{doneStatus}</doneStatus><description>{description}</description><title>{title}</title></todo>";


            var stringContent = new StringContent(someXmlString, Encoding.UTF8, "application/xml");
            var respone = await httpClient.PutAsync($"http://localhost:4567/todos/{id}/tasksof", stringContent);
            return respone;

        }
        public async static Task<HttpResponseMessage> PutTodoIdTaskof(string id, string doneStatus, string description, string title)
        {
            var httpClient = new HttpClient();
            var someXmlString = $"<todo><doneStatus>{doneStatus}</doneStatus><description>{description}</description><title>{title}</title></todo>";


            var stringContent = new StringContent(someXmlString, Encoding.UTF8, "application/xml");
            var respone = await httpClient.PutAsync($"http://localhost:4567/todos/{id}/tasksof", stringContent);
            return respone;

        }

        public async static Task<HttpResponseMessage> PatchTodoIdTaskof(int id, string doneStatus, string description, string title)
        {
            var httpClient = new HttpClient();
            var someXmlString = $"<todo><doneStatus>{doneStatus}</doneStatus><description>{description}</description><title>{title}</title></todo>";


            var stringContent = new StringContent(someXmlString, Encoding.UTF8, "application/xml");
            var respone = await httpClient.PatchAsync($"http://localhost:4567/todos/{id}/tasksof", stringContent);
            return respone;

        }
        public async static Task<HttpResponseMessage> PatchTodoIdTaskof(string id, string doneStatus, string description, string title)
        {
            var httpClient = new HttpClient();
            var someXmlString = $"<todo><doneStatus>{doneStatus}</doneStatus><description>{description}</description><title>{title}</title></todo>";


            var stringContent = new StringContent(someXmlString, Encoding.UTF8, "application/xml");
            var respone = await httpClient.PatchAsync($"http://localhost:4567/todos/{id}/tasksof", stringContent);
            return respone;

        }

        public async static Task<HttpResponseMessage> PostTodoIdTaskof(int id, string doneStatus, string description, string title)
        {
            var httpClient = new HttpClient();
            var someXmlString = $"<project><active>{doneStatus}</active><description></description><completed>{doneStatus}</completed><title>{title}</title></project>";


            var stringContent = new StringContent(someXmlString, Encoding.UTF8, "application/xml");
            var respone = await httpClient.PostAsync($"http://localhost:4567/todos/{id}/tasksof", stringContent);
            return respone;

        }
        public async static Task<HttpResponseMessage> PostTodoIdTaskof(string id, string doneStatus, string description, string title)
        {
            var httpClient = new HttpClient();
            var someXmlString = $"<project><active>{doneStatus}</active><description></description><completed>{doneStatus}</completed><title>{title}</title></project>";


            var stringContent = new StringContent(someXmlString, Encoding.UTF8, "application/xml");
            var respone = await httpClient.PostAsync($"http://localhost:4567/todos/{id}/tasksof", stringContent);
            return respone;

        }

        public async static Task<HttpResponseMessage> DeleteTodosIdTaskof(int id)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));
                var response = client.DeleteAsync($"http://localhost:4567/todos/{id}/tasksof").Result;

                return response;

            }

        }
        public async static Task<HttpResponseMessage> DeleteTodosIdTaskof(string id)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));
                var response = client.DeleteAsync($"http://localhost:4567/todos/{id}/tasksof").Result;

                return response;

            }

        }


        #endregion

        #region /todos/:id/taskof/:id

        public async static Task<HttpResponseMessage> GetTodosIdTaskofId(int id, int id2)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));
                var response = client.GetAsync($"http://localhost:4567/todos/{id}/tasksof/{id2}").Result;

                return response;

            }

        }
        public async static Task<HttpResponseMessage> GetTodosIdTaskofId(string id, string id2)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));
                var response = client.GetAsync($"http://localhost:4567/todos/{id}/tasksof/{id2}").Result;

                return response;

            }

        }

        public async static Task<HttpResponseMessage> PutTodoIdTaskofId(int id, int id2, string doneStatus, string description, string title)
        {
            var httpClient = new HttpClient();
            var someXmlString = $"<todo><doneStatus>{doneStatus}</doneStatus><description>{description}</description><title>{title}</title></todo>";


            var stringContent = new StringContent(someXmlString, Encoding.UTF8, "application/xml");
            var respone = await httpClient.PutAsync($"http://localhost:4567/todos/{id}/tasksof/{id2}", stringContent);
            return respone;

        }
        public async static Task<HttpResponseMessage> PutTodoIdTaskofId(string id, string id2, string doneStatus, string description, string title)
        {
            var httpClient = new HttpClient();
            var someXmlString = $"<todo><doneStatus>{doneStatus}</doneStatus><description>{description}</description><title>{title}</title></todo>";


            var stringContent = new StringContent(someXmlString, Encoding.UTF8, "application/xml");
            var respone = await httpClient.PutAsync($"http://localhost:4567/todos/{id}/tasksof/{id2}", stringContent);
            return respone;

        }

        public async static Task<HttpResponseMessage> PatchTodoIdTaskofId(int id, int id2, string doneStatus, string description, string title)
        {
            var httpClient = new HttpClient();
            var someXmlString = $"<todo><doneStatus>{doneStatus}</doneStatus><description>{description}</description><title>{title}</title></todo>";


            var stringContent = new StringContent(someXmlString, Encoding.UTF8, "application/xml");
            var respone = await httpClient.PatchAsync($"http://localhost:4567/todos/{id}/tasksof/{id2}", stringContent);
            return respone;

        }
        public async static Task<HttpResponseMessage> PatchTodoIdTaskofId(string id, string id2, string doneStatus, string description, string title)
        {
            var httpClient = new HttpClient();
            var someXmlString = $"<todo><doneStatus>{doneStatus}</doneStatus><description>{description}</description><title>{title}</title></todo>";


            var stringContent = new StringContent(someXmlString, Encoding.UTF8, "application/xml");
            var respone = await httpClient.PatchAsync($"http://localhost:4567/todos/{id}/tasksof/{id2}", stringContent);
            return respone;

        }

        public async static Task<HttpResponseMessage> PostTodoIdTaskofId(int id, int id2, string doneStatus, string description, string title)
        {
            var httpClient = new HttpClient();
            var someXmlString = $"<project><active>{doneStatus}</active><description></description><completed>{doneStatus}</completed><title>{title}</title></project>";


            var stringContent = new StringContent(someXmlString, Encoding.UTF8, "application/xml");
            var respone = await httpClient.PostAsync($"http://localhost:4567/todos/{id}/tasksof/{id2}", stringContent);
            return respone;

        }
        public async static Task<HttpResponseMessage> PostTodoIdTaskofId(string id, string id2, string doneStatus, string description, string title)
        {
            var httpClient = new HttpClient();
            var someXmlString = $"<project><active>{doneStatus}</active><description></description><completed>{doneStatus}</completed><title>{title}</title></project>";


            var stringContent = new StringContent(someXmlString, Encoding.UTF8, "application/xml");
            var respone = await httpClient.PostAsync($"http://localhost:4567/todos/{id}/tasksof/{id2}", stringContent);
            return respone;

        }

        public async static Task<HttpResponseMessage> DeleteTodosIdTaskofId(int id, int id2)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));
                var response = client.DeleteAsync($"http://localhost:4567/todos/{id}/tasksof/{id2}").Result;

                return response;

            }

        }
        public async static Task<HttpResponseMessage> DeleteTodosIdTaskofId(string id, string id2)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));
                var response = client.DeleteAsync($"http://localhost:4567/todos/{id}/tasksof/{id2}").Result;

                return response;

            }

        }



        #endregion

        #region /todos/:id/category
        public async static Task<HttpResponseMessage> GetTodosIdCategory(int id)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));
                var response = client.GetAsync($"http://localhost:4567/todos/{id}/categories").Result;

                return response;

            }

        }
        public async static Task<HttpResponseMessage> GetTodosIdCategory(string id)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));
                var response = client.GetAsync($"http://localhost:4567/todos/{id}/categories").Result;

                return response;

            }

        }

        public async static Task<HttpResponseMessage> PutTodoIdCategory(int id, string doneStatus, string description, string title)
        {
            var httpClient = new HttpClient();
            var someXmlString = $"<todo><doneStatus>{doneStatus}</doneStatus><description>{description}</description><title>{title}</title></todo>";


            var stringContent = new StringContent(someXmlString, Encoding.UTF8, "application/xml");
            var respone = await httpClient.PutAsync($"http://localhost:4567/todos/{id}/categories", stringContent);
            return respone;

        }
        public async static Task<HttpResponseMessage> PutTodoIdCategory(string id, string doneStatus, string description, string title)
        {
            var httpClient = new HttpClient();
            var someXmlString = $"<todo><doneStatus>{doneStatus}</doneStatus><description>{description}</description><title>{title}</title></todo>";


            var stringContent = new StringContent(someXmlString, Encoding.UTF8, "application/xml");
            var respone = await httpClient.PutAsync($"http://localhost:4567/todos/{id}/categories", stringContent);
            return respone;

        }

        public async static Task<HttpResponseMessage> PatchTodoIdCategory(int id, string doneStatus, string description, string title)
        {
            var httpClient = new HttpClient();
            var someXmlString = $"<todo><doneStatus>{doneStatus}</doneStatus><description>{description}</description><title>{title}</title></todo>";


            var stringContent = new StringContent(someXmlString, Encoding.UTF8, "application/xml");
            var respone = await httpClient.PatchAsync($"http://localhost:4567/todos/{id}/categories", stringContent);
            return respone;

        }
        public async static Task<HttpResponseMessage> PatchTodoIdCategory(string id, string doneStatus, string description, string title)
        {
            var httpClient = new HttpClient();
            var someXmlString = $"<todo><doneStatus>{doneStatus}</doneStatus><description>{description}</description><title>{title}</title></todo>";


            var stringContent = new StringContent(someXmlString, Encoding.UTF8, "application/xml");
            var respone = await httpClient.PatchAsync($"http://localhost:4567/todos/{id}/categories", stringContent);
            return respone;

        }

        public async static Task<HttpResponseMessage> PostTodoIdCategory(int id, string title)
        {
            var httpClient = new HttpClient();
            var someXmlString = $"<category><description/><title>{title}</title></category>";


            var stringContent = new StringContent(someXmlString, Encoding.UTF8, "application/xml");
            var respone = await httpClient.PostAsync($"http://localhost:4567/todos/{id}/categories", stringContent);
            return respone;

        }
        public async static Task<HttpResponseMessage> PostTodoIdCategory(string id, string doneStatus, string description, string title)
        {
            var httpClient = new HttpClient();
            var someXmlString = $"<project><active>{doneStatus}</active><description></description><completed>{doneStatus}</completed><title>{title}</title></project>";


            var stringContent = new StringContent(someXmlString, Encoding.UTF8, "application/xml");
            var respone = await httpClient.PostAsync($"http://localhost:4567/todos/{id}/categories", stringContent);
            return respone;

        }

        public async static Task<HttpResponseMessage> DeleteTodosIdCategory(int id)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));
                var response = client.DeleteAsync($"http://localhost:4567/todos/{id}/categories").Result;

                return response;

            }

        }
        public async static Task<HttpResponseMessage> DeleteTodosIdCategory(string id)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));
                var response = client.DeleteAsync($"http://localhost:4567/todos/{id}/categories").Result;

                return response;

            }

        }

        #endregion

        #region /todos/:id/category/:id

        public async static Task<HttpResponseMessage> GetTodosIdCategoryId(int id, int id2)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));
                var response = client.GetAsync($"http://localhost:4567/todos/{id}/tasksof/{id2}").Result;

                return response;

            }

        }
        public async static Task<HttpResponseMessage> GetTodosIdCategoryId(string id, string id2)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));
                var response = client.GetAsync($"http://localhost:4567/todos/{id}/tasksof/{id2}").Result;

                return response;

            }

        }

        public async static Task<HttpResponseMessage> PutTodoIdCategoryId(int id, int id2, string doneStatus, string description, string title)
        {
            var httpClient = new HttpClient();
            var someXmlString = $"<todo><doneStatus>{doneStatus}</doneStatus><description>{description}</description><title>{title}</title></todo>";


            var stringContent = new StringContent(someXmlString, Encoding.UTF8, "application/xml");
            var respone = await httpClient.PutAsync($"http://localhost:4567/todos/{id}/tasksof/{id2}", stringContent);
            return respone;

        }
        public async static Task<HttpResponseMessage> PutTodoIdCategoryId(string id, string id2, string doneStatus, string description, string title)
        {
            var httpClient = new HttpClient();
            var someXmlString = $"<todo><doneStatus>{doneStatus}</doneStatus><description>{description}</description><title>{title}</title></todo>";


            var stringContent = new StringContent(someXmlString, Encoding.UTF8, "application/xml");
            var respone = await httpClient.PutAsync($"http://localhost:4567/todos/{id}/tasksof/{id2}", stringContent);
            return respone;

        }

        public async static Task<HttpResponseMessage> PatchTodoIdCategoryId(int id, int id2, string doneStatus, string description, string title)
        {
            var httpClient = new HttpClient();
            var someXmlString = $"<todo><doneStatus>{doneStatus}</doneStatus><description>{description}</description><title>{title}</title></todo>";


            var stringContent = new StringContent(someXmlString, Encoding.UTF8, "application/xml");
            var respone = await httpClient.PatchAsync($"http://localhost:4567/todos/{id}/tasksof/{id2}", stringContent);
            return respone;

        }
        public async static Task<HttpResponseMessage> PatchTodoIdCategoryId(string id, string id2, string doneStatus, string description, string title)
        {
            var httpClient = new HttpClient();
            var someXmlString = $"<todo><doneStatus>{doneStatus}</doneStatus><description>{description}</description><title>{title}</title></todo>";


            var stringContent = new StringContent(someXmlString, Encoding.UTF8, "application/xml");
            var respone = await httpClient.PatchAsync($"http://localhost:4567/todos/{id}/tasksof/{id2}", stringContent);
            return respone;

        }

        public async static Task<HttpResponseMessage> PostTodoIdCategoryId(int id, int id2, string doneStatus, string description, string title)
        {
            var httpClient = new HttpClient();
            var someXmlString = $"<project><active>{doneStatus}</active><description></description><completed>{doneStatus}</completed><title>{title}</title></project>";


            var stringContent = new StringContent(someXmlString, Encoding.UTF8, "application/xml");
            var respone = await httpClient.PostAsync($"http://localhost:4567/todos/{id}/tasksof/{id2}", stringContent);
            return respone;

        }
        public async static Task<HttpResponseMessage> PostTodoIdCategoryId(string id, string id2, string doneStatus, string description, string title)
        {
            var httpClient = new HttpClient();
            var someXmlString = $"<project><active>{doneStatus}</active><description></description><completed>{doneStatus}</completed><title>{title}</title></project>";


            var stringContent = new StringContent(someXmlString, Encoding.UTF8, "application/xml");
            var respone = await httpClient.PostAsync($"http://localhost:4567/todos/{id}/tasksof/{id2}", stringContent);
            return respone;

        }

        public async static Task<HttpResponseMessage> DeleteTodosIdCategoryId(int id, int id2)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));
                var response = client.DeleteAsync($"http://localhost:4567/todos/{id}/tasksof/{id2}").Result;

                return response;

            }

        }
        public async static Task<HttpResponseMessage> DeleteTodosIdCategoryId(string id, string id2)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));
                var response = client.DeleteAsync($"http://localhost:4567/todos/{id}/tasksof/{id2}").Result;

                return response;

            }

        }



        #endregion

        #endregion
        #region Categories
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

        #endregion


        #region projects
       
      
        public async static Task<int> GetAProjectId()
        {
            var id = 0;
            var list = await GetAllProjects();
            if (list.Any())
            {
                id = list.First().id;
            }
            return id;
        }
        #region /projects
        public async static Task<IEnumerable<Project>> GetAllProjects()
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));
                HttpResponseMessage response = client.GetAsync("http://localhost:4567/projects").Result;

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    XDocument xdoc = XDocument.Parse(response.Content.ReadAsStringAsync().Result);


                    var studentLst = xdoc.Descendants("project").Select(d =>
                      new Project
                      {
                          id = Int32.Parse(d.Element("id").Value),
                          active = bool.Parse(d.Element("active").Value),
                          completed = bool.Parse(d.Element("active").Value),
                          title = d.Element("title").Value,
                          description = d.Element("description").Value
                      }).ToList();

                    return studentLst;
                }
                else
                {
                    return Enumerable.Empty<Project>();
                }
            }

        }
        public async static Task<HttpResponseMessage> GetProjects()
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));
                var response = client.GetAsync("http://localhost:4567/projects").Result;

                return response;

            }

        }
        public async static Task<HttpResponseMessage> CreateProject(string doneStatus, string description, string title)
        {
            var httpClient = new HttpClient();
            var someXmlString = $"<project><active>{doneStatus}</active><description></description><completed>{doneStatus}</completed><title>{title}</title></project>";


            var stringContent = new StringContent(someXmlString, Encoding.UTF8, "application/xml");
            var respone = await httpClient.PostAsync("http://localhost:4567/projects", stringContent);
            return respone;

        }

        public async static Task<HttpResponseMessage> PutProject(string doneStatus, string description, string title)
        {
            var httpClient = new HttpClient();
            var someXmlString = $"<project><active>{doneStatus}</active><description></description><completed>{doneStatus}</completed><title>{title}</title></project>";


            var stringContent = new StringContent(someXmlString, Encoding.UTF8, "application/xml");
            var response = await httpClient.PutAsync("http://localhost:4567/projects", stringContent);
            return response;
        }
        public async static Task<HttpResponseMessage> PatchProject(string doneStatus, string description, string title)
        {
            var httpClient = new HttpClient();
            var someXmlString = $"<project><active>{doneStatus}</active><description></description><completed>{doneStatus}</completed><title>{title}</title></project>";


            var stringContent = new StringContent(someXmlString, Encoding.UTF8, "application/xml");
            var response = await httpClient.PatchAsync("http://localhost:4567/projects", stringContent);
            return response;
        }

        public async static Task<HttpResponseMessage> DeleteProject()
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));
                var response = client.DeleteAsync("http://localhost:4567/projects").Result;

                return response;

            }

        }
        #endregion


        #region /projects/id
        public async static Task<HttpResponseMessage> GetProjectsId(int id)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));
                var response = client.GetAsync($"http://localhost:4567/projects/{id}").Result;

                return response;

            }

        }
        public async static Task<HttpResponseMessage> GetProjectsId(string id)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));
                var response = client.GetAsync($"http://localhost:4567/projects/{id}").Result;

                return response;

            }

        }
        public async static Task<HttpResponseMessage> PostProjectId(int id, string doneStatus, string description, string title)
        {
            var httpClient = new HttpClient();
            var someXmlString = $"<project><active>{doneStatus}</active><description/><completed>false</completed><title>{title}</title></project>";


            var stringContent = new StringContent(someXmlString, Encoding.UTF8, "application/xml");
            var respone = await httpClient.PostAsync($"http://localhost:4567/projects/{id}", stringContent);
            return respone;

        }
        public async static Task<HttpResponseMessage> PostProjectId(string id, string doneStatus, string description, string title)
        {
            var httpClient = new HttpClient();
            var someXmlString = $"<project><active>{doneStatus}</active><description/><completed>false</completed><title>{title}</title></project>";


            var stringContent = new StringContent(someXmlString, Encoding.UTF8, "application/xml");
            var respone = await httpClient.PostAsync($"http://localhost:4567/projects/{id}", stringContent);
            return respone;

        }
        public async static Task<HttpResponseMessage> PutProjectId(int id, string doneStatus, string description, string title)
        {
            var httpClient = new HttpClient();
            var someXmlString = $"<project><active>{doneStatus}</active><description/><completed>false</completed><title>{title}</title></project>";


            var stringContent = new StringContent(someXmlString, Encoding.UTF8, "application/xml");
            var respone = await httpClient.PutAsync($"http://localhost:4567/projects/{id}", stringContent);
            return respone;

        }
        public async static Task<HttpResponseMessage> PutProjectId(string id, string doneStatus, string description, string title)
        {
            var httpClient = new HttpClient();
            var someXmlString = $"<project><active>{doneStatus}</active><description/><completed>false</completed><title>{title}</title></project>";


            var stringContent = new StringContent(someXmlString, Encoding.UTF8, "application/xml");
            var respone = await httpClient.PutAsync($"http://localhost:4567/projects/{id}", stringContent);
            return respone;

        }

        public async static Task<HttpResponseMessage> PatchProjectId(int id, string doneStatus, string description, string title)
        {
            var httpClient = new HttpClient();
            var someXmlString = $"<project><active>{doneStatus}</active><description/><completed>false</completed><title>{title}</title></project>";


            var stringContent = new StringContent(someXmlString, Encoding.UTF8, "application/xml");
            var respone = await httpClient.PatchAsync($"http://localhost:4567/projects/{id}", stringContent);
            return respone;

        }
        public async static Task<HttpResponseMessage> PatchProjectId(string id, string doneStatus, string description, string title)
        {
            var httpClient = new HttpClient();
            var someXmlString = $"<project><active>{doneStatus}</active><description/><completed>false</completed><title>{title}</title></project>";


            var stringContent = new StringContent(someXmlString, Encoding.UTF8, "application/xml");
            var respone = await httpClient.PatchAsync($"http://localhost:4567/projects/{id}", stringContent);
            return respone;

        }

        public async static Task<HttpResponseMessage> DeleteProjectsId(int id)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));
                var response = client.DeleteAsync($"http://localhost:4567/projects/{id}").Result;

                return response;

            }

        }
        public async static Task<HttpResponseMessage> DeleteProjectsId(string id)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));
                var response = client.DeleteAsync($"http://localhost:4567/projects/{id}").Result;

                return response;

            }

        }
        #endregion


      

        #region /projects/:id/category
        public async static Task<HttpResponseMessage> GetProjectsIdCategory(int id)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));
                var response = client.GetAsync($"http://localhost:4567/projects/{id}/categories").Result;

                return response;

            }

        }
        public async static Task<HttpResponseMessage> GetProjectsIdCategory(string id)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));
                var response = client.GetAsync($"http://localhost:4567/projects/{id}/categories").Result;

                return response;

            }

        }

        public async static Task<HttpResponseMessage> PutProjectIdCategory(int id, string doneStatus, string description, string title)
        {
            var httpClient = new HttpClient();
            var someXmlString = $"<project><doneStatus>{doneStatus}</doneStatus><description>{description}</description><title>{title}</title></project>";


            var stringContent = new StringContent(someXmlString, Encoding.UTF8, "application/xml");
            var respone = await httpClient.PutAsync($"http://localhost:4567/projects/{id}/categories", stringContent);
            return respone;

        }
        public async static Task<HttpResponseMessage> PutProjectIdCategory(string id, string doneStatus, string description, string title)
        {
            var httpClient = new HttpClient();
            var someXmlString = $"<project><doneStatus>{doneStatus}</doneStatus><description>{description}</description><title>{title}</title></project>";


            var stringContent = new StringContent(someXmlString, Encoding.UTF8, "application/xml");
            var respone = await httpClient.PutAsync($"http://localhost:4567/projects/{id}/categories", stringContent);
            return respone;

        }

        public async static Task<HttpResponseMessage> PatchProjectIdCategory(int id, string doneStatus, string description, string title)
        {
            var httpClient = new HttpClient();
            var someXmlString = $"<project><doneStatus>{doneStatus}</doneStatus><description>{description}</description><title>{title}</title></project>";


            var stringContent = new StringContent(someXmlString, Encoding.UTF8, "application/xml");
            var respone = await httpClient.PatchAsync($"http://localhost:4567/projects/{id}/categories", stringContent);
            return respone;

        }
        public async static Task<HttpResponseMessage> PatchProjectIdCategory(string id, string doneStatus, string description, string title)
        {
            var httpClient = new HttpClient();
            var someXmlString = $"<project><doneStatus>{doneStatus}</doneStatus><description>{description}</description><title>{title}</title></project>";


            var stringContent = new StringContent(someXmlString, Encoding.UTF8, "application/xml");
            var respone = await httpClient.PatchAsync($"http://localhost:4567/projects/{id}/categories", stringContent);
            return respone;

        }

        public async static Task<HttpResponseMessage> PostProjectIdCategory(int id, string title)
        {
            var httpClient = new HttpClient();
            var someXmlString = $"<category><description/><title>{title}</title></category>";


            var stringContent = new StringContent(someXmlString, Encoding.UTF8, "application/xml");
            var respone = await httpClient.PostAsync($"http://localhost:4567/projects/{id}/categories", stringContent);
            return respone;

        }
        public async static Task<HttpResponseMessage> PostProjectIdCategory(string id, string doneStatus, string description, string title)
        {
            var httpClient = new HttpClient();
            var someXmlString = $"<project><active>{doneStatus}</active><description></description><completed>{doneStatus}</completed><title>{title}</title></project>";


            var stringContent = new StringContent(someXmlString, Encoding.UTF8, "application/xml");
            var respone = await httpClient.PostAsync($"http://localhost:4567/projects/{id}/categories", stringContent);
            return respone;

        }

        public async static Task<HttpResponseMessage> DeleteProjectsIdCategory(int id)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));
                var response = client.DeleteAsync($"http://localhost:4567/projects/{id}/categories").Result;

                return response;

            }

        }
        public async static Task<HttpResponseMessage> DeleteProjectsIdCategory(string id)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));
                var response = client.DeleteAsync($"http://localhost:4567/projects/{id}/categories").Result;

                return response;

            }

        }

        #endregion

        #region /projects/:id/category/:id

        public async static Task<HttpResponseMessage> GetProjectsIdCategoryId(int id, int id2)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));
                var response = client.GetAsync($"http://localhost:4567/projects/{id}/tasksof/{id2}").Result;

                return response;

            }

        }
        public async static Task<HttpResponseMessage> GetProjectsIdCategoryId(string id, string id2)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));
                var response = client.GetAsync($"http://localhost:4567/projects/{id}/tasksof/{id2}").Result;

                return response;

            }

        }

        public async static Task<HttpResponseMessage> PutProjectIdCategoryId(int id, int id2, string doneStatus, string description, string title)
        {
            var httpClient = new HttpClient();
            var someXmlString = $"<project><active>{doneStatus}</active><description/><completed>false</completed><title/></project>";


            var stringContent = new StringContent(someXmlString, Encoding.UTF8, "application/xml");
            var respone = await httpClient.PutAsync($"http://localhost:4567/projects/{id}/tasksof/{id2}", stringContent);
            return respone;

        }
        public async static Task<HttpResponseMessage> PutProjectIdCategoryId(string id, string id2, string doneStatus, string description, string title)
        {
            var httpClient = new HttpClient();
            var someXmlString = $"<project><doneStatus>{doneStatus}</doneStatus><description>{description}</description><title>{title}</title></project>";


            var stringContent = new StringContent(someXmlString, Encoding.UTF8, "application/xml");
            var respone = await httpClient.PutAsync($"http://localhost:4567/projects/{id}/tasksof/{id2}", stringContent);
            return respone;

        }

        public async static Task<HttpResponseMessage> PatchProjectIdCategoryId(int id, int id2, string doneStatus, string description, string title)
        {
            var httpClient = new HttpClient();
            var someXmlString = $"<project><doneStatus>{doneStatus}</doneStatus><description>{description}</description><title>{title}</title></project>";


            var stringContent = new StringContent(someXmlString, Encoding.UTF8, "application/xml");
            var respone = await httpClient.PatchAsync($"http://localhost:4567/projects/{id}/tasksof/{id2}", stringContent);
            return respone;

        }
        public async static Task<HttpResponseMessage> PatchProjectIdCategoryId(string id, string id2, string doneStatus, string description, string title)
        {
            var httpClient = new HttpClient();
            var someXmlString = $"<project><doneStatus>{doneStatus}</doneStatus><description>{description}</description><title>{title}</title></project>";


            var stringContent = new StringContent(someXmlString, Encoding.UTF8, "application/xml");
            var respone = await httpClient.PatchAsync($"http://localhost:4567/projects/{id}/tasksof/{id2}", stringContent);
            return respone;

        }

        public async static Task<HttpResponseMessage> PostProjectIdCategoryId(int id, int id2, string doneStatus, string description, string title)
        {
            var httpClient = new HttpClient();
            var someXmlString = $"<project><active>{doneStatus}</active><description></description><completed>{doneStatus}</completed><title>{title}</title></project>";


            var stringContent = new StringContent(someXmlString, Encoding.UTF8, "application/xml");
            var respone = await httpClient.PostAsync($"http://localhost:4567/projects/{id}/tasksof/{id2}", stringContent);
            return respone;

        }
        public async static Task<HttpResponseMessage> PostProjectIdCategoryId(string id, string id2, string doneStatus, string description, string title)
        {
            var httpClient = new HttpClient();
            var someXmlString = $"<project><active>{doneStatus}</active><description></description><completed>{doneStatus}</completed><title>{title}</title></project>";


            var stringContent = new StringContent(someXmlString, Encoding.UTF8, "application/xml");
            var respone = await httpClient.PostAsync($"http://localhost:4567/projects/{id}/tasksof/{id2}", stringContent);
            return respone;

        }

        public async static Task<HttpResponseMessage> DeleteProjectsIdCategoryId(int id, int id2)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));
                var response = client.DeleteAsync($"http://localhost:4567/projects/{id}/tasksof/{id2}").Result;

                return response;

            }

        }
        public async static Task<HttpResponseMessage> DeleteProjectsIdCategoryId(string id, string id2)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));
                var response = client.DeleteAsync($"http://localhost:4567/projects/{id}/tasksof/{id2}").Result;

                return response;

            }

        }



        #endregion
        #endregion
    }
}
