//using NUnit.Framework;
//using NUnitTestProject1.Entities;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net;
//using System.Runtime.CompilerServices;
//using System.Text;
//using System.Threading.Tasks;
//using System.Xml.Linq;

//namespace NUnitTestProject1
//{
//    class TestCategoty

//    {
//        [SetUp]
//        public void Setup()
//        {
//        }
//        #region /categories
//        [Test]
//        public async Task TestGetCategories()
//        {
//            var response = ApiHelper.GetCategories();

//            Assert.AreEqual(HttpStatusCode.OK, response.Result.StatusCode);
//        }

//        [Test]
//        public async Task TestPutCategories()
//        {
//            var response = ApiHelper.PutCategories();

//            Assert.AreEqual(HttpStatusCode.MethodNotAllowed, response.Result.StatusCode);
//        }

//        [Test]
//        public async Task TestSucessfulPostCategories()
//        {
            
//            var list = await ApiHelper.GetAllCategories();
//            var CountBeforeAddition = list.Count();
//            var response = await ApiHelper.createCategorySuccessfully();

//            var list2 = await ApiHelper.GetAllCategories();
//            var CountAfterAddition = list2.Count();

//            Assert.AreEqual(CountBeforeAddition + 1, CountAfterAddition);
//            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
//        }

//        [Test]
//        public async Task TestUnsucessfulPostCategories()
//        {

//            var list = await ApiHelper.GetAllCategories();
//            var CountBeforeAddition = list.Count();
//            var response = await ApiHelper.createCategoryUnsuccessfully();

//            var list2 = await ApiHelper.GetAllCategories();
//            var CountAfterAddition = list2.Count();

//            Assert.AreEqual(CountBeforeAddition , CountAfterAddition);
//            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
//        }
        
//        [Test]
//        public async Task TestSucessfulPostCategorieswithoutDescription()
//        {

//            var response = await ApiHelper.createCategorySuccessfullyWithoutDescription();

          
//            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
//        }
        
//        [Test]
//        public async Task TestDeleteCategory()
//        {

//            var response = ApiHelper.DeleteCategory();

//            Assert.AreEqual(HttpStatusCode.MethodNotAllowed, response.Result.StatusCode);
//        }
       
//        [Test]
//        public async Task TestpatchCategory()
//        {
  
//            var response = ApiHelper.PatchCategory();

//            Assert.AreEqual(HttpStatusCode.MethodNotAllowed, response.Result.StatusCode);
//        }
//        #endregion
//        #region /categories/id
//        [Test]
//        public async Task TestSuccessfulGetCategorybyId()
//        {
//            var id = 0;
//            var list = await ApiHelper.GetAllCategories();
//            if (list.Any())
//            {
//                id = list.First().id;
//            }
//            var response = await ApiHelper.GetCategoryById(id);
          
//                XDocument xdoc = XDocument.Parse(response.Content.ReadAsStringAsync().Result);

//                var categories = xdoc.Descendants("category").Select(d =>
//                  new Category
//                  {
//                      id = Int32.Parse(d.Element("id").Value),
//                      title = d.Element("title").Value,
//                      description = d.Element("description").Value
//                  }).ToList();


//            Assert.AreEqual(1, categories.Count());
//            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
//        }
//        [Test]
//        public async Task TestUnsuccessfulGetCategorybyId()
//        {
//            var response = await ApiHelper.GetCategoryById(9999);

//            XDocument xdoc = XDocument.Parse(response.Content.ReadAsStringAsync().Result);

//            var categories = xdoc.Descendants("category").Select(d =>
//              new Category
//              {
//                  id = Int32.Parse(d.Element("id").Value),
//                  title = d.Element("title").Value,
//                  description = d.Element("description").Value
//              }).ToList();


//            Assert.AreEqual(0, categories.Count());
//            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
//        }
//        // Issue 1 : when filter by id contains character it gives not found instead of an error
//        public async Task TestUnsuccessfulGetCategorybyIdContainsCharacter()
//        {
//            var response = await ApiHelper.GetCategoryByIdString("invalildID$$soInvalid2020");

          
//            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
//        }
//        [Test]
//        public async Task TesSuccessfulPutCategorybyId()
//        {
//            var id = 0;
//            var list = await ApiHelper.GetAllCategories();
//            if (list.Any())
//            {
//                id = list.First().id;
//            }
      
//            var title = "new put Title";
//            var description = "new put description";

//            var response = await ApiHelper.putCategoryById(id, title, description);
//            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

//            var category = await ApiHelper.GetCategoryByIdObj(id);
//            Assert.AreEqual(title, category.title);
//            Assert.AreEqual(description, category.description);
//        }

//        [Test]
//        public async Task TestUnsuccessfulPutCategorybyId()
//        {
//            var id = 9999;
//            var title = "new put Title";
//            var description = "new put description";

//            var response = await ApiHelper.putCategoryById(id, title, description);
//            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
//        }

//        [Test]
//        public async Task TesSuccessfulPostCategorybyId()
//        {
//            var id = 0;
//            var list = await ApiHelper.GetAllCategories();
//            if (list.Any())
//            {
//                id = list.First().id;
//            }
//            var title = "new post Title";
//            var description = "new post description";

//            var response = await ApiHelper.PostCategoryById(id, title, description);
//            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

//            var category = await ApiHelper.GetCategoryByIdObj(id);
//            Assert.AreEqual(title, category.title);
//            Assert.AreEqual(description, category.description);
//        }

//        [Test]
//        public async Task TestUnsuccessfulPostCategorybyId()
//        {
//            var id = 9999;
//            var title = "new post Title";
//            var description = "new post description";
//            var response = await ApiHelper.PostCategoryById(id, title, description);
//            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
//        }

//        [Test]
//        public async Task TesSuccessfulDeleteCategorybyId()
//        {
//            var id = 0;
//            var listt = await ApiHelper.GetAllCategories();
//            if (listt.Any())
//            {
//                id = listt.First().id;
//            }
//            var list = await ApiHelper.GetAllCategories();
//            var CountBeforeAddition = list.Count();

//            var response = await ApiHelper.DeleteCategoryById(id);
//            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

//            var list2 = await ApiHelper.GetAllCategories();
//            var CountAfterAddition = list2.Count();

//            Assert.AreEqual(CountBeforeAddition - 1, CountAfterAddition);
            
//        }

//        [Test]
//        public async Task TestUnsuccessfulDeleteCategorybyId()
//        {

//            var id = 9999999;
//            var response = await ApiHelper.DeleteCategoryById(id);
//            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
//        }

//        [Test]
//        public async Task TestPatchCategorybyId()
//        {
//            var id = 0;
//            var list = await ApiHelper.GetAllCategories();
//            if (list.Any())
//            {
//                id = list.First().id;
//            }
//            var response = await ApiHelper.PatchCategoryById(id);

//            Assert.AreEqual(HttpStatusCode.MethodNotAllowed, response.StatusCode);
//        }

//        #endregion
//        #region /categories/id/projects
//        [Test]
//        public async Task TestDeleteCategoryIdProject()
//        {
//            var id = await ApiHelper.GetAnId();

//            var response = await ApiHelper.DeleteCategoryIdProjects(id);

//            Assert.AreEqual(HttpStatusCode.MethodNotAllowed, response.StatusCode);
//        }


//        [Test]
//        public async Task TestGetCategoryIdProject()
//        {
//            var id = await ApiHelper.GetAnId();

//            var response = await ApiHelper.GetCategoryIdProject(id);

//            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
//        }

//        // Issue 2: this should return not found  
//        [Test]
//        public async Task TestGetCategoryIdProjectUnExpected()
//        {
//            var response = await ApiHelper.GetCategoryIdProject(0);

//            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
//        }

//        // Issue 3: Id must be a number characters should not be accepted
//        [Test]
//        public async Task TestGetCategoryIdProjectUnExpected2()
//        {
//            var response = await ApiHelper.GetCategoryIdStringProject("StringID%%");

//            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
//        }
//        #endregion
//        #region /categories/id/projects

//        // issue 4: should be method not allowd ! 
//        [Test]
//        public async Task TestPostCategoryIdProjectId()
//        {
//            var id = await ApiHelper.GetAnId();
//            var response = await ApiHelper.PostCategoryIdProjectId(id, 909);

//            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
//        }

//        // issue 5: should be method not allowd ! 
//        [Test]
//        public async Task TestGetCategoryIdProjectId()
//        {
//            var id = await ApiHelper.GetAnId();
//            var response = await ApiHelper.GetCategoryIdProjectId(id,909);

//            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
//        }

//        [Test]
//        public async Task TestPutCategoryIdProjectId()
//        {
//            var id = await ApiHelper.GetAnId();
//            var response = await ApiHelper.PutCategoryIdProjectId(id, 909);

//            Assert.AreEqual(HttpStatusCode.MethodNotAllowed, response.StatusCode);
//        }
  
//        [Test]
//        public async Task TestPatchCategoryIdProjectId()
//        {
//            var id = await ApiHelper.GetAnId();
//            var response = await ApiHelper.PatchCategoryIdProjectId(id, 909);

//            Assert.AreEqual(HttpStatusCode.MethodNotAllowed, response.StatusCode);
//        }

//        [Test]
//        public async Task TestDeleteCategoryIdProjectId()
//        {
//            var id = await ApiHelper.GetAnId();
//            var response = await ApiHelper.DeleteCategoryIdProjectsId(id, 909);

//            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
//        }
//        #endregion
//        #region/categories/:id/todos

//        [Test]
//        public async Task TestGetCategoryIdTodos()
//        {
//            var id = await ApiHelper.GetAnId();
//            var response = await ApiHelper.GetCategoryIdTodos(id);

//            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
//        }
//        [Test]
//        public async Task TestPostCategoryIdTodos()
//        {
//            var id = await ApiHelper.GetAnId();
//            var response = await ApiHelper.PostCategoryIdTodos(id);

//            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
//        }
//        [Test]
//        public async Task TestPostCategoryIdnotExistedTodos()
//        {
//            var id = await ApiHelper.GetAnId();
//            var response = await ApiHelper.PostCategoryIdTodos(0);

//            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
//        }
//        [Test]
//        public async Task TestPostCategoryIdTodoswithError()
//        {
//            var id = await ApiHelper.GetAnId();
//            var response = await ApiHelper.PostCategoryIdTodoswithError(id);

//            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
//        }

//        [Test]
//        public async Task TestPutCategoryIdTodos()
//        {
//            var id = await ApiHelper.GetAnId();
//            var response = await ApiHelper.PutCategoryIdTodos(id);

//            Assert.AreEqual(HttpStatusCode.MethodNotAllowed, response.StatusCode);
//        }

//        [Test]
//        public async Task TestPatchCategoryIdTodos()
//        {
//            var id = await ApiHelper.GetAnId();
//            var response = await ApiHelper.PatchCategoryIdTodos(id);

//            Assert.AreEqual(HttpStatusCode.MethodNotAllowed, response.StatusCode);
//        }
//        [Test]
//        public async Task TestDeleteCategoryIdTodos()
//        {
//            var id = await ApiHelper.GetAnId();
//            var response = await ApiHelper.DeleteCategoryIdTodos(id);

//            Assert.AreEqual(HttpStatusCode.MethodNotAllowed, response.StatusCode);
//        }


//        #endregion
//        #region/categories/:id/todos
//        [Test]
//        // issue 6: should be method not allowd ! 
//        public async Task TestGetCategoryIdTodosId()
//        {
//            var id = await ApiHelper.GetAnId();
//            var response = await ApiHelper.GetCategoryIdTodosId(id, 9);

//            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
//        }

//        // issue 7: should be method not allowd ! 
//        [Test]
//        public async Task TestPostCategoryIdTodosId()
//        {
//            var id = await ApiHelper.GetAnId();
//            var response = await ApiHelper.PostCategoryIdTodosId(id, 9);

//            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
//        }
//        [Test]

//        public async Task TestPutCategoryIdTodosId()
//        {
//            var id = await ApiHelper.GetAnId();
//            var response = await ApiHelper.PutCategoryIdTodosId(id, 9);

//            Assert.AreEqual(HttpStatusCode.MethodNotAllowed, response.StatusCode);
//        }
//        [Test]
//        public async Task TestPatchCategoryIdTodosId()
//        {
//            var id = await ApiHelper.GetAnId();
//            var response = await ApiHelper.PatchCategoryIdTodosId(id, 9);

//            Assert.AreEqual(HttpStatusCode.MethodNotAllowed, response.StatusCode);
//        }

//        #endregion
//    }
//}
