using NUnit.Framework;
using NUnitTestProject1.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace NUnitTestProject1
{
    class TestCategoty

    {
        [SetUp]
        public void Setup()
        {
        }
        #region /categories
        [Test]
        public async Task TestGetCategories()
        {
            var response = ApiHelper.GetCategories();

            Assert.AreEqual(HttpStatusCode.OK, response.Result.StatusCode);
        }

        [Test]
        public async Task TestPutCategories()
        {
            var response = ApiHelper.PutCategories();

            Assert.AreEqual(HttpStatusCode.MethodNotAllowed, response.Result.StatusCode);
        }

        [Test]
        public async Task TestSucessfulPostCategories()
        {
            
            var list = await ApiHelper.GetAllCategories();
            var CountBeforeAddition = list.Count();
            var response = await ApiHelper.createCategorySuccessfully();

            var list2 = await ApiHelper.GetAllCategories();
            var CountAfterAddition = list2.Count();

            Assert.AreEqual(CountBeforeAddition + 1, CountAfterAddition);
            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
        }

        [Test]
        public async Task TestUnsucessfulPostCategories()
        {

            var list = await ApiHelper.GetAllCategories();
            var CountBeforeAddition = list.Count();
            var response = await ApiHelper.createCategoryUnsuccessfully();

            var list2 = await ApiHelper.GetAllCategories();
            var CountAfterAddition = list2.Count();

            Assert.AreEqual(CountBeforeAddition , CountAfterAddition);
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Test]
        public async Task TestDeleteCategory()
        {

            var response = ApiHelper.DeleteCategory();

            Assert.AreEqual(HttpStatusCode.MethodNotAllowed, response.Result.StatusCode);
        }
        [Test]
        public async Task TestpatchCategory()
        {
  
            var response = ApiHelper.PatchCategory();

            Assert.AreEqual(HttpStatusCode.MethodNotAllowed, response.Result.StatusCode);
        }
        #endregion

        #region /categories/id
        [Test]
        public async Task TestSuccessfulGetCategorybyId()
        {
            var id = 0;
            var list = await ApiHelper.GetAllCategories();
            if (list.Any())
            {
                id = list.First().id;
            }
            var response = await ApiHelper.GetCategoryById(id);
          
                XDocument xdoc = XDocument.Parse(response.Content.ReadAsStringAsync().Result);

                var categories = xdoc.Descendants("category").Select(d =>
                  new Category
                  {
                      id = Int32.Parse(d.Element("id").Value),
                      title = d.Element("title").Value,
                      description = d.Element("description").Value
                  }).ToList();


            Assert.AreEqual(1, categories.Count());
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }
        [Test]
        public async Task TestUnsuccessfulGetCategorybyId()
        {
            var response = await ApiHelper.GetCategoryById(9999);

            XDocument xdoc = XDocument.Parse(response.Content.ReadAsStringAsync().Result);

            var categories = xdoc.Descendants("category").Select(d =>
              new Category
              {
                  id = Int32.Parse(d.Element("id").Value),
                  title = d.Element("title").Value,
                  description = d.Element("description").Value
              }).ToList();


            Assert.AreEqual(0, categories.Count());
            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
        }
        [Test]
        public async Task TesSuccessfulPutCategorybyId()
        {
            var id = 0;
            var list = await ApiHelper.GetAllCategories();
            if (list.Any())
            {
                id = list.First().id;
            }
      
            var title = "new put Title";
            var description = "new put description";

            var response = await ApiHelper.putCategoryById(id, title, description);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

            var category = await ApiHelper.GetCategoryByIdObj(id);
            Assert.AreEqual(title, category.title);
            Assert.AreEqual(description, category.description);
        }

        [Test]
        public async Task TestUnsuccessfulPutCategorybyId()
        {
            var id = 9999;
            var title = "new put Title";
            var description = "new put description";

            var response = await ApiHelper.putCategoryById(id, title, description);
            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Test]
        public async Task TesSuccessfulPostCategorybyId()
        {
            var id = 0;
            var list = await ApiHelper.GetAllCategories();
            if (list.Any())
            {
                id = list.First().id;
            }
            var title = "new post Title";
            var description = "new post description";

            var response = await ApiHelper.PostCategoryById(id, title, description);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

            var category = await ApiHelper.GetCategoryByIdObj(id);
            Assert.AreEqual(title, category.title);
            Assert.AreEqual(description, category.description);
        }

        [Test]
        public async Task TestUnsuccessfulPostCategorybyId()
        {
            var id = 9999;
            var title = "new post Title";
            var description = "new post description";
            var response = await ApiHelper.PostCategoryById(id, title, description);
            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Test]
        public async Task TesSuccessfulDeleteCategorybyId()
        {
            var id = 0;
            var listt = await ApiHelper.GetAllCategories();
            if (listt.Any())
            {
                id = listt.First().id;
            }
            var list = await ApiHelper.GetAllCategories();
            var CountBeforeAddition = list.Count();

            var response = await ApiHelper.DeleteCategoryById(id);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

            var list2 = await ApiHelper.GetAllCategories();
            var CountAfterAddition = list2.Count();

            Assert.AreEqual(CountBeforeAddition - 1, CountAfterAddition);
            
        }

        [Test]
        public async Task TestUnsuccessfulDeleteCategorybyId()
        {

            var id = 9999999;
            var response = await ApiHelper.DeleteCategoryById(id);
            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Test]
        public async Task TestPatchCategorybyId()
        {
            var id = 0;
            var list = await ApiHelper.GetAllCategories();
            if (list.Any())
            {
                id = list.First().id;
            }
            var response = await ApiHelper.PatchCategoryById(id);

            Assert.AreEqual(HttpStatusCode.MethodNotAllowed, response.StatusCode);
        }

        #endregion

    }
}
