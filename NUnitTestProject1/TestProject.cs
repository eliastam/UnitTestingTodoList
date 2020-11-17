//using NUnit.Framework;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net;
//using System.Net.Http;
//using System.Text;
//using System.Threading.Tasks;

//namespace NUnitTestProject1
//{
//    class TestProject
//    {
//        HttpClient client = new HttpClient();

//        [SetUp]
//        public void Setup()
//        {
//        }
//        #region Project
//        [Test]
//        public async Task TestGetProject()
//        {
//            var response = await ApiHelper.GetProjects();

//            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
//        }

//        [Test]
//        public async Task TestCreateAProject()
//        {
//            var list = await ApiHelper.GetAllProjects();
//            var CountBeforeAddition = list.Count();
//            await ApiHelper.CreateProject("false", "deeeee", "elias");

//            var list2 = await ApiHelper.GetAllProjects();
//            var CountAfterAddition = list2.Count();
//            Assert.AreEqual(CountBeforeAddition + 1, CountAfterAddition);
//        }
//        [Test]
//        public async Task TestCreateAProjectWithTitleEqualsToEmptyString()
//        {

//            var response = await ApiHelper.CreateProject("false", "deeeee", "");
//            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);

//        }
//        [Test]
//        public async Task TestCreateAProjectWithTitleEqualsToNull()
//        {

//            var response = await ApiHelper.CreateProject("false", "deeeee", null);
//            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
//        }

//        [Test]
//        public async Task TestCreateAProjectWithDoneStuatusToNotBeBool()
//        {

//            var response = await ApiHelper.CreateProject("#$NotBoolForsure", "deeeee", "title");
//            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
//        }

//        [Test]
//        public async Task TestCreateAProjectWithNoDescription()
//        {

//            var response = await ApiHelper.CreateProject("false", "", "title");
//            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
//        }

//        [Test]
//        public async Task TestCreateAProjectWithDoneStuatusToNotBeTrue()
//        {

//            var response = await ApiHelper.CreateProject("true", "description", "title");
//            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
//        }


//        [Test]
//        public async Task TestPutProject()
//        {
//            var response = await ApiHelper.PutProject("false", "deeeee", "elias");


//            Assert.AreEqual(HttpStatusCode.MethodNotAllowed, response.StatusCode);
//        }

//        [Test]
//        public async Task TestPatchProject()
//        {
//            var response = await ApiHelper.PatchProject("false", "deeeee", "elias");


//            Assert.AreEqual(HttpStatusCode.MethodNotAllowed, response.StatusCode);
//        }

//        [Test]
//        public async Task TestDeleteProject()
//        {
//            var response = await ApiHelper.DeleteProject();


//            Assert.AreEqual(HttpStatusCode.MethodNotAllowed, response.StatusCode);
//        }
//        #endregion

//        #region Project/id
//        [Test]
//        public async Task TestGetProjectId_ExistedAndIntegerId()
//        {
//            var response = await ApiHelper.GetProjectsId(await ApiHelper.GetAProjectId());

//            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
//        }

//        [Test]
//        public async Task TestGetProjectId_NotExistedAndIntegerId()
//        {
//            var response = await ApiHelper.GetProjectsId(0);

//            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
//        }


//        [Test]
//        public async Task TestGetProjectId_NotIntegerId()
//        {
//            var response = await ApiHelper.GetProjectsId("not Integer");

//            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
//        }

//        [Test]
//        public async Task TestPostProjectIdSuccessful()
//        {

//            var response = await ApiHelper.PostProjectId(await ApiHelper.GetAProjectId(), "false", "deeeee", "title");
//            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

//        }
//        [Test]
//        public async Task TestPostProjectIdNotexistedId()
//        {

//            var response = await ApiHelper.PostProjectId(0, "false", "deeeee", "title");
//            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);

//        }
//        [Test]
//        public async Task TestPostProjectIdExistedIdWithNoTitle()
//        {

//            var response = await ApiHelper.PostProjectId(await ApiHelper.GetAProjectId(), "false", "deeeee", "");
//            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

//        }

//        [Test]
//        public async Task TestPostProjectIdExistedIdDonestatusNotBoolean()
//        {
//            var response = await ApiHelper.PostProjectId(await ApiHelper.GetAProjectId(), "NOTBool", "deeeee", "");
//            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
//        }

//        [Test]
//        public async Task TestPutProjectIdSuccessful()
//        {

//            var response = await ApiHelper.PutProjectId(await ApiHelper.GetAProjectId(), "false", "deeeee", "title");
//            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

//        }
//        [Test]
//        public async Task TestPutProjectIdNotexistedId()
//        {

//            var response = await ApiHelper.PutProjectId(0, "false", "deeeee", "title");
//            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);

//        }
//        [Test]
//        public async Task TestPutProjectIdExistedIdWithNoTitle()
//        {

//            var response = await ApiHelper.PutProjectId(await ApiHelper.GetAProjectId(), "false", "deeeee", "");
//            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

//        }

//        [Test]
//        public async Task TestPutProjectIdExistedIdDonestatusNotBoolean()
//        {
//            var response = await ApiHelper.PutProjectId(await ApiHelper.GetAProjectId(), "NOTBool", "deeeee", "");
//            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
//        }

//        [Test]
//        public async Task TestPatchProjectIdSuccessful()
//        {

//            var response = await ApiHelper.PatchProjectId(await ApiHelper.GetAProjectId(), "false", "deeeee", "title");
//            Assert.AreEqual(HttpStatusCode.MethodNotAllowed, response.StatusCode);

//        }
//        [Test]
//        public async Task TestPatchProjectIdNotexistedId()
//        {

//            var response = await ApiHelper.PatchProjectId(0, "false", "deeeee", "title");
//            Assert.AreEqual(HttpStatusCode.MethodNotAllowed, response.StatusCode);

//        }
//        [Test]
//        public async Task TestPatchProjectIdExistedIdWithNoTitle()
//        {

//            var response = await ApiHelper.PatchProjectId(await ApiHelper.GetAProjectId(), "false", "deeeee", "");
//            Assert.AreEqual(HttpStatusCode.MethodNotAllowed, response.StatusCode);

//        }

//        [Test]
//        public async Task TestPatchProjectIdExistedIdDonestatusNotBoolean()
//        {
//            var response = await ApiHelper.PatchProjectId(await ApiHelper.GetAProjectId(), "NOTBool", "deeeee", "");
//            Assert.AreEqual(HttpStatusCode.MethodNotAllowed, response.StatusCode);
//        }

//        [Test]
//        public async Task TestDeleteProjectId_ExistedAndIntegerId()
//        {
//            var response = await ApiHelper.DeleteProjectsId(await ApiHelper.GetAProjectId());

//            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
//        }

//        [Test]
//        public async Task TestDeleteProjectId_NotExistedAndIntegerId()
//        {
//            var response = await ApiHelper.DeleteProjectsId(0);

//            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
//        }

//        [Test]
//        public async Task TestDeleteProjectId_NotIntegerId()
//        {
//            var response = await ApiHelper.DeleteProjectsId("not Integer");

//            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
//        }

//        #endregion

//        #region /todos/:id/category
//        [Test]
//        public async Task TestGetProjectIdCategory_ExistedAndIntegerId()
//        {
//            var response = await ApiHelper.GetProjectsIdCategory(await ApiHelper.GetAProjectId());

//            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
//        }

//        [Test]
//        public async Task TestGetProjectIdCategory_NotExistedAndIntegerId()
//        {
//            var response = await ApiHelper.GetProjectsIdCategory(0);

//            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
//        }

//        [Test]
//        public async Task TestGetProjectIdCategory_NotIntegerId()
//        {
//            var response = await ApiHelper.GetProjectsIdCategory("not Integer");

//            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
//        }

//        [Test]
//        public async Task TestPutProjectIdCategorySuccessful()
//        {

//            var response = await ApiHelper.PutProjectIdCategory(await ApiHelper.GetAProjectId(), "false", "deeeee", "title");
//            Assert.AreEqual(HttpStatusCode.MethodNotAllowed, response.StatusCode);

//        }
//        [Test]
//        public async Task TestPutProjectIdCategoryNotexistedId()
//        {

//            var response = await ApiHelper.PutProjectIdCategory(0, "false", "deeeee", "title");
//            Assert.AreEqual(HttpStatusCode.MethodNotAllowed, response.StatusCode);

//        }
//        [Test]
//        public async Task TestPutProjectIdCategoryExistedIdWithNoTitle()
//        {

//            var response = await ApiHelper.PutProjectIdCategory(await ApiHelper.GetAProjectId(), "false", "deeeee", "");
//            Assert.AreEqual(HttpStatusCode.MethodNotAllowed, response.StatusCode);

//        }

//        [Test]
//        public async Task TestPutProjectIdCategoryExistedIdDonestatusNotBoolean()
//        {
//            var response = await ApiHelper.PutProjectIdCategory(await ApiHelper.GetAProjectId(), "NOTBool", "deeeee", "");
//            Assert.AreEqual(HttpStatusCode.MethodNotAllowed, response.StatusCode);
//        }

//        [Test]
//        public async Task TestPatchProjectIdCategorySuccessful()
//        {

//            var response = await ApiHelper.PatchProjectIdCategory(await ApiHelper.GetAProjectId(), "false", "deeeee", "title");
//            Assert.AreEqual(HttpStatusCode.MethodNotAllowed, response.StatusCode);

//        }
//        [Test]
//        public async Task TestPatchProjectIdCategoryNotexistedId()
//        {

//            var response = await ApiHelper.PatchProjectIdCategory(0, "false", "deeeee", "title");
//            Assert.AreEqual(HttpStatusCode.MethodNotAllowed, response.StatusCode);

//        }
//        [Test]
//        public async Task TestPatchProjectIdCategoryExistedIdWithNoTitle()
//        {

//            var response = await ApiHelper.PatchProjectIdCategory(await ApiHelper.GetAProjectId(), "false", "deeeee", "");
//            Assert.AreEqual(HttpStatusCode.MethodNotAllowed, response.StatusCode);

//        }

//        [Test]
//        public async Task TestPatchProjectIdCategoryExistedIdDonestatusNotBoolean()
//        {
//            var response = await ApiHelper.PatchProjectIdCategory(await ApiHelper.GetAProjectId(), "NOTBool", "deeeee", "");
//            Assert.AreEqual(HttpStatusCode.MethodNotAllowed, response.StatusCode);
//        }

//        [Test]
//        public async Task TestPostProjectIdCategorySuccessful()
//        {

//            var response = await ApiHelper.PostProjectIdCategory(await ApiHelper.GetAProjectId(), "title");
//            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);

//        }
//        [Test]
//        public async Task TestPostProjectIdCategoryNotexistedId()
//        {

//            var response = await ApiHelper.PostProjectIdCategory(0, "title");
//            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);

//        }
//        [Test]
//        public async Task TestPostProjectIdCategoryExistedIdWithNoTitle()
//        {
//            var response = await ApiHelper.PostProjectIdCategory(await ApiHelper.GetAProjectId(), "");
//            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
//        }

//        [Test]
//        public async Task TestPostProjectIdCategoryExistedIdDonestatusNotBoolean()
//        {
//            var response = await ApiHelper.PostProjectIdCategory(await ApiHelper.GetAProjectId(), "");
//            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
//        }

//        [Test]
//        public async Task TestDeleteProjectIdCategory_ExistedAndIntegerId()
//        {
//            var response = await ApiHelper.DeleteProjectsIdCategory(await ApiHelper.GetAProjectId());

//            Assert.AreEqual(HttpStatusCode.MethodNotAllowed, response.StatusCode);
//        }

//        [Test]
//        public async Task TestDeleteProjectIdCategory_NotExistedAndIntegerId()
//        {
//            var response = await ApiHelper.DeleteProjectsIdCategory(0);

//            Assert.AreEqual(HttpStatusCode.MethodNotAllowed, response.StatusCode);
//        }

//        [Test]
//        public async Task TestDeleteProjectIdCategory_NotIntegerId()
//        {
//            var response = await ApiHelper.DeleteProjectsIdCategory("not Integer");

//            Assert.AreEqual(HttpStatusCode.MethodNotAllowed, response.StatusCode);
//        }

//        #endregion

//    }
//}
