using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using NUnit.Framework;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace NUnitTestProject1
{
    [TestClass]
    public class TestTodo

    {
        HttpClient client = new HttpClient();

  
        #region Todo
        [TestInitialize]
        public void TestCaseExecuting()
        {
            ServerManager.start();
        }
        [TestCleanup]
        public void TestCaseExecuted()
        {

        }
        [TestMethod]
        public async Task TestGetTodo()
        {
            var response = await ApiHelper.GetTodos();

            NUnit.Framework.Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        //[TestMethod]
        //public async Task TestCreateATodo()
        //{
        //    var list = await ApiHelper.GetAllTodos();
        //    var CountBeforeAddition = list.Count();
        //    await ApiHelper.CreateTodo("false", "deeeee", "elias");

        //    var list2 = await ApiHelper.GetAllTodos();
        //    var CountAfterAddition = list2.Count();
        //    Assert.AreEqual(CountBeforeAddition + 1, CountAfterAddition);
        //}
        //[TestMethod]
        //public async Task TestCreateATodoWithTitleEqualsToEmptyString()
        //{

        //    var response = await ApiHelper.CreateTodo("false", "deeeee", "");
        //    Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);

        //}
        //[TestMethod]
        //public async Task TestCreateATodoWithTitleEqualsToNull()
        //{

        //    var response = await ApiHelper.CreateTodo("false", "deeeee", null);
        //    Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        //}

        //[TestMethod]
        //public async Task TestCreateATodoWithDoneStuatusToNotBeBool()
        //{

        //    var response = await ApiHelper.CreateTodo("#$NotBoolForsure", "deeeee", "title");
        //    Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        //}

        //[TestMethod]
        //public async Task TestCreateATodoWithNoDescription()
        //{

        //    var response = await ApiHelper.CreateTodo("false", "", "title");
        //    Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
        //}

        //[TestMethod]
        //public async Task TestCreateATodoWithDoneStuatusToNotBeTrue()
        //{

        //    var response = await ApiHelper.CreateTodo("true", "description", "title");
        //    Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
        //}


        //[TestMethod]
        //public async Task TestPutTodo()
        //{
        //    var response = await ApiHelper.PutTodo("false", "deeeee", "elias");


        //    Assert.AreEqual(HttpStatusCode.MethodNotAllowed, response.StatusCode);
        //}

        //[TestMethod]
        //public async Task TestPatchTodo()
        //{
        //    var response = await ApiHelper.PatchTodo("false", "deeeee", "elias");


        //    Assert.AreEqual(HttpStatusCode.MethodNotAllowed, response.StatusCode);
        //}

        //[TestMethod]
        //public async Task TestDeleteTodo()
        //{
        //    var response = await ApiHelper.DeleteTodo();


        //    Assert.AreEqual(HttpStatusCode.MethodNotAllowed, response.StatusCode);
        //}
        //#endregion

        //#region Todo/id
        //[TestMethod]
        //public async Task TestGetTodoId_ExistedAndIntegerId()
        //{
        //    var response = await ApiHelper.GetTodosId(await ApiHelper.GetATodoId());

        //    Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        //}

        //[TestMethod]
        //public async Task TestGetTodoId_NotExistedAndIntegerId()
        //{
        //    var response = await ApiHelper.GetTodosId(0);

        //    Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
        //}


        //[TestMethod]
        //public async Task TestGetTodoId_NotIntegerId()
        //{
        //    var response = await ApiHelper.GetTodosId("not Integer");

        //    Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
        //}

        //[TestMethod]
        //public async Task TestPostTodoIdSuccessful()
        //{

        //    var response = await ApiHelper.PostTodoId(await ApiHelper.GetATodoId(), "false", "deeeee", "title");
        //    Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

        //}
        //[TestMethod]
        //public async Task TestPostTodoIdNotexistedId()
        //{

        //    var response = await ApiHelper.PostTodoId(0, "false", "deeeee", "title");
        //    Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);

        //}
        //[TestMethod]
        //public async Task TestPostTodoIdExistedIdWithNoTitle()
        //{

        //    var response = await ApiHelper.PostTodoId(await ApiHelper.GetATodoId(), "false", "deeeee", "");
        //    Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);

        //}

        //[TestMethod]
        //public async Task TestPostTodoIdExistedIdDonestatusNotBoolean()
        //{
        //    var response = await ApiHelper.PostTodoId(await ApiHelper.GetATodoId(), "NOTBool", "deeeee", "");
        //    Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        //}

        //[TestMethod]
        //public async Task TestPutTodoIdSuccessful()
        //{

        //    var response = await ApiHelper.PutTodoId(await ApiHelper.GetATodoId(), "false", "deeeee", "title");
        //    Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

        //}
        //[TestMethod]
        //public async Task TestPutTodoIdNotexistedId()
        //{

        //    var response = await ApiHelper.PutTodoId(0, "false", "deeeee", "title");
        //    Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);

        //}
        //[TestMethod]
        //public async Task TestPutTodoIdExistedIdWithNoTitle()
        //{

        //    var response = await ApiHelper.PutTodoId(await ApiHelper.GetATodoId(), "false", "deeeee", "");
        //    Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);

        //}

        //[TestMethod]
        //public async Task TestPutTodoIdExistedIdDonestatusNotBoolean()
        //{
        //    var response = await ApiHelper.PutTodoId(await ApiHelper.GetATodoId(), "NOTBool", "deeeee", "");
        //    Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        //}

        //[TestMethod]
        //public async Task TestPatchTodoIdSuccessful()
        //{

        //    var response = await ApiHelper.PatchTodoId(await ApiHelper.GetATodoId(), "false", "deeeee", "title");
        //    Assert.AreEqual(HttpStatusCode.MethodNotAllowed, response.StatusCode);

        //}
        //[TestMethod]
        //public async Task TestPatchTodoIdNotexistedId()
        //{

        //    var response = await ApiHelper.PatchTodoId(0, "false", "deeeee", "title");
        //    Assert.AreEqual(HttpStatusCode.MethodNotAllowed, response.StatusCode);

        //}
        //[TestMethod]
        //public async Task TestPatchTodoIdExistedIdWithNoTitle()
        //{

        //    var response = await ApiHelper.PatchTodoId(await ApiHelper.GetATodoId(), "false", "deeeee", "");
        //    Assert.AreEqual(HttpStatusCode.MethodNotAllowed, response.StatusCode);

        //}

        //[TestMethod]
        //public async Task TestPatchTodoIdExistedIdDonestatusNotBoolean()
        //{
        //    var response = await ApiHelper.PatchTodoId(await ApiHelper.GetATodoId(), "NOTBool", "deeeee", "");
        //    Assert.AreEqual(HttpStatusCode.MethodNotAllowed, response.StatusCode);
        //}

        //[TestMethod]
        //public async Task TestDeleteTodoId_ExistedAndIntegerId()
        //{
        //    var response = await ApiHelper.DeleteTodosId(await ApiHelper.GetATodoId());

        //    Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        //}

        //[TestMethod]
        //public async Task TestDeleteTodoId_NotExistedAndIntegerId()
        //{
        //    var response = await ApiHelper.DeleteTodosId(0);

        //    Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
        //}

        //[TestMethod]
        //public async Task TestDeleteTodoId_NotIntegerId()
        //{
        //    var response = await ApiHelper.DeleteTodosId("not Integer");

        //    Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
        //}

        //#endregion

        //#region /todos/:id/tasksof
        //[TestMethod]
        //public async Task TestGetTodoIdTaskof_ExistedAndIntegerId()
        //{
        //    var response = await ApiHelper.GetTodosIdTaskof(await ApiHelper.GetATodoId());

        //    Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        //}

        //[TestMethod]
        //public async Task TestGetTodoIdTaskof_NotExistedAndIntegerId()
        //{
        //    var response = await ApiHelper.GetTodosIdTaskof(0);

        //    Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        //}

        //[TestMethod]
        //public async Task TestGetTodoIdTaskof_NotIntegerId()
        //{
        //    var response = await ApiHelper.GetTodosIdTaskof("not Integer");

        //    Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        //}

        //[TestMethod]
        //public async Task TestPutTodoIdTaskofSuccessful()
        //{

        //    var response = await ApiHelper.PutTodoIdTaskof(await ApiHelper.GetATodoId(), "false", "deeeee", "title");
        //    Assert.AreEqual(HttpStatusCode.MethodNotAllowed, response.StatusCode);

        //}
        //[TestMethod]
        //public async Task TestPutTodoIdTaskofNotexistedId()
        //{

        //    var response = await ApiHelper.PutTodoIdTaskof(0, "false", "deeeee", "title");
        //    Assert.AreEqual(HttpStatusCode.MethodNotAllowed, response.StatusCode);

        //}
        //[TestMethod]
        //public async Task TestPutTodoIdTaskofExistedIdWithNoTitle()
        //{

        //    var response = await ApiHelper.PutTodoIdTaskof(await ApiHelper.GetATodoId(), "false", "deeeee", "");
        //    Assert.AreEqual(HttpStatusCode.MethodNotAllowed, response.StatusCode);

        //}

        //[TestMethod]
        //public async Task TestPutTodoIdTaskofExistedIdDonestatusNotBoolean()
        //{
        //    var response = await ApiHelper.PutTodoIdTaskof(await ApiHelper.GetATodoId(), "NOTBool", "deeeee", "");
        //    Assert.AreEqual(HttpStatusCode.MethodNotAllowed, response.StatusCode);
        //}

        //[TestMethod]
        //public async Task TestPatchTodoIdTaskofSuccessful()
        //{

        //    var response = await ApiHelper.PatchTodoIdTaskof(await ApiHelper.GetATodoId(), "false", "deeeee", "title");
        //    Assert.AreEqual(HttpStatusCode.MethodNotAllowed, response.StatusCode);

        //}
        //[TestMethod]
        //public async Task TestPatchTodoIdTaskofNotexistedId()
        //{

        //    var response = await ApiHelper.PatchTodoIdTaskof(0, "false", "deeeee", "title");
        //    Assert.AreEqual(HttpStatusCode.MethodNotAllowed, response.StatusCode);

        //}
        //[TestMethod]
        //public async Task TestPatchTodoIdTaskofExistedIdWithNoTitle()
        //{

        //    var response = await ApiHelper.PatchTodoIdTaskof(await ApiHelper.GetATodoId(), "false", "deeeee", "");
        //    Assert.AreEqual(HttpStatusCode.MethodNotAllowed, response.StatusCode);

        //}

        //[TestMethod]
        //public async Task TestPatchTodoIdTaskofExistedIdDonestatusNotBoolean()
        //{
        //    var response = await ApiHelper.PatchTodoIdTaskof(await ApiHelper.GetATodoId(), "NOTBool", "deeeee", "");
        //    Assert.AreEqual(HttpStatusCode.MethodNotAllowed, response.StatusCode);
        //}

        //[TestMethod]
        //public async Task TestPostTodoIdTaskofSuccessful()
        //{

        //    var response = await ApiHelper.PostTodoIdTaskof(await ApiHelper.GetATodoId(), "false", "deeeee", "title");
        //    Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);

        //}
        //[TestMethod]
        //public async Task TestPostTodoIdTaskofNotexistedId()
        //{

        //    var response = await ApiHelper.PostTodoIdTaskof(0, "false", "deeeee", "title");
        //    Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);

        //}
        //[TestMethod]
        //public async Task TestPostTodoIdTaskofExistedIdWithNoTitle()
        //{
        //    var response = await ApiHelper.PostTodoIdTaskof(await ApiHelper.GetATodoId(), "false", "deeeee", "");
        //    Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
        //}

        //[TestMethod]
        //public async Task TestPostTodoIdTaskofExistedIdDonestatusNotBoolean()
        //{
        //    var response = await ApiHelper.PostTodoIdTaskof(await ApiHelper.GetATodoId(), "NOTBool", "deeeee", "");
        //    Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        //}

        //[TestMethod]
        //public async Task TestDeleteTodoIdTaskof_ExistedAndIntegerId()
        //{
        //    var response = await ApiHelper.DeleteTodosIdTaskof(await ApiHelper.GetATodoId());

        //    Assert.AreEqual(HttpStatusCode.MethodNotAllowed, response.StatusCode);
        //}

        //[TestMethod]
        //public async Task TestDeleteTodoIdTaskof_NotExistedAndIntegerId()
        //{
        //    var response = await ApiHelper.DeleteTodosIdTaskof(0);

        //    Assert.AreEqual(HttpStatusCode.MethodNotAllowed, response.StatusCode);
        //}

        //[TestMethod]
        //public async Task TestDeleteTodoIdTaskof_NotIntegerId()
        //{
        //    var response = await ApiHelper.DeleteTodosIdTaskof("not Integer");

        //    Assert.AreEqual(HttpStatusCode.MethodNotAllowed, response.StatusCode);
        //}

        //#endregion

        //#region /todos/:id/tasksof/:id


        //[TestMethod]
        //public async Task TestPutTodoIdTaskofIdSuccessful()
        //{

        //    var response = await ApiHelper.PutTodoIdTaskofId(await ApiHelper.GetATodoId(), 1, "false", "deeeee", "title");
        //    Assert.AreEqual(HttpStatusCode.MethodNotAllowed, response.StatusCode);

        //}
        //[TestMethod]
        //public async Task TestPutTodoIdTaskofIdNotexistedId()
        //{

        //    var response = await ApiHelper.PutTodoIdTaskofId(0, 1, "false", "deeeee", "title");
        //    Assert.AreEqual(HttpStatusCode.MethodNotAllowed, response.StatusCode);

        //}
        //[TestMethod]
        //public async Task TestPutTodoIdTaskofIdExistedIdWithNoTitle()
        //{

        //    var response = await ApiHelper.PutTodoIdTaskofId(await ApiHelper.GetATodoId(), 1, "false", "deeeee", "");
        //    Assert.AreEqual(HttpStatusCode.MethodNotAllowed, response.StatusCode);

        //}

        //[TestMethod]
        //public async Task TestPutTodoIdTaskofIdExistedIdDonestatusNotBoolean()
        //{
        //    var response = await ApiHelper.PutTodoIdTaskofId(await ApiHelper.GetATodoId(), 1, "NOTBool", "deeeee", "");
        //    Assert.AreEqual(HttpStatusCode.MethodNotAllowed, response.StatusCode);
        //}

        //[TestMethod]
        //public async Task TestPatchTodoIdTaskofIdSuccessful()
        //{

        //    var response = await ApiHelper.PatchTodoIdTaskofId(await ApiHelper.GetATodoId(), 1, "false", "deeeee", "title");
        //    Assert.AreEqual(HttpStatusCode.MethodNotAllowed, response.StatusCode);

        //}
        //[TestMethod]
        //public async Task TestPatchTodoIdTaskofIdNotexistedId()
        //{

        //    var response = await ApiHelper.PatchTodoIdTaskofId(0, 1, "false", "deeeee", "title");
        //    Assert.AreEqual(HttpStatusCode.MethodNotAllowed, response.StatusCode);

        //}
        //[TestMethod]
        //public async Task TestPatchTodoIdTaskofIdExistedIdWithNoTitle()
        //{

        //    var response = await ApiHelper.PatchTodoIdTaskofId(await ApiHelper.GetATodoId(), 1, "false", "deeeee", "");
        //    Assert.AreEqual(HttpStatusCode.MethodNotAllowed, response.StatusCode);

        //}

        //[TestMethod]
        //public async Task TestPatchTodoIdTaskofIdExistedIdDonestatusNotBoolean()
        //{
        //    var response = await ApiHelper.PatchTodoIdTaskofId(await ApiHelper.GetATodoId(), 1, "NOTBool", "deeeee", "");
        //    Assert.AreEqual(HttpStatusCode.MethodNotAllowed, response.StatusCode);
        //}




        //#endregion

        //#region /todos/:id/category
        //[TestMethod]
        //public async Task TestGetTodoIdCategory_ExistedAndIntegerId()
        //{
        //    var response = await ApiHelper.GetTodosIdCategory(await ApiHelper.GetATodoId());

        //    Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        //}

        //[TestMethod]
        //public async Task TestGetTodoIdCategory_NotExistedAndIntegerId()
        //{
        //    var response = await ApiHelper.GetTodosIdCategory(0);

        //    Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        //}

        //[TestMethod]
        //public async Task TestGetTodoIdCategory_NotIntegerId()
        //{
        //    var response = await ApiHelper.GetTodosIdCategory("not Integer");

        //    Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        //}

        //[TestMethod]
        //public async Task TestPutTodoIdCategorySuccessful()
        //{

        //    var response = await ApiHelper.PutTodoIdCategory(await ApiHelper.GetATodoId(), "false", "deeeee", "title");
        //    Assert.AreEqual(HttpStatusCode.MethodNotAllowed, response.StatusCode);

        //}
        //[TestMethod]
        //public async Task TestPutTodoIdCategoryNotexistedId()
        //{

        //    var response = await ApiHelper.PutTodoIdCategory(0, "false", "deeeee", "title");
        //    Assert.AreEqual(HttpStatusCode.MethodNotAllowed, response.StatusCode);

        //}
        //[TestMethod]
        //public async Task TestPutTodoIdCategoryExistedIdWithNoTitle()
        //{

        //    var response = await ApiHelper.PutTodoIdCategory(await ApiHelper.GetATodoId(), "false", "deeeee", "");
        //    Assert.AreEqual(HttpStatusCode.MethodNotAllowed, response.StatusCode);

        //}

        //[TestMethod]
        //public async Task TestPutTodoIdCategoryExistedIdDonestatusNotBoolean()
        //{
        //    var response = await ApiHelper.PutTodoIdCategory(await ApiHelper.GetATodoId(), "NOTBool", "deeeee", "");
        //    Assert.AreEqual(HttpStatusCode.MethodNotAllowed, response.StatusCode);
        //}

        //[TestMethod]
        //public async Task TestPatchTodoIdCategorySuccessful()
        //{

        //    var response = await ApiHelper.PatchTodoIdCategory(await ApiHelper.GetATodoId(), "false", "deeeee", "title");
        //    Assert.AreEqual(HttpStatusCode.MethodNotAllowed, response.StatusCode);

        //}
        //[TestMethod]
        //public async Task TestPatchTodoIdCategoryNotexistedId()
        //{

        //    var response = await ApiHelper.PatchTodoIdCategory(0, "false", "deeeee", "title");
        //    Assert.AreEqual(HttpStatusCode.MethodNotAllowed, response.StatusCode);

        //}
        //[TestMethod]
        //public async Task TestPatchTodoIdCategoryExistedIdWithNoTitle()
        //{

        //    var response = await ApiHelper.PatchTodoIdCategory(await ApiHelper.GetATodoId(), "false", "deeeee", "");
        //    Assert.AreEqual(HttpStatusCode.MethodNotAllowed, response.StatusCode);

        //}

        //[TestMethod]
        //public async Task TestPatchTodoIdCategoryExistedIdDonestatusNotBoolean()
        //{
        //    var response = await ApiHelper.PatchTodoIdCategory(await ApiHelper.GetATodoId(), "NOTBool", "deeeee", "");
        //    Assert.AreEqual(HttpStatusCode.MethodNotAllowed, response.StatusCode);
        //}

        //[TestMethod]
        //public async Task TestPostTodoIdCategorySuccessful()
        //{

        //    var response = await ApiHelper.PostTodoIdCategory(await ApiHelper.GetATodoId(), "title");
        //    Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);

        //}
        //[TestMethod]
        //public async Task TestPostTodoIdCategoryNotexistedId()
        //{

        //    var response = await ApiHelper.PostTodoIdCategory(0, "title");
        //    Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);

        //}
        //[TestMethod]
        //public async Task TestPostTodoIdCategoryExistedIdWithNoTitle()
        //{
        //    var response = await ApiHelper.PostTodoIdCategory(await ApiHelper.GetATodoId(), "");
        //    Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        //}

        //[TestMethod]
        //public async Task TestPostTodoIdCategoryExistedIdDonestatusNotBoolean()
        //{
        //    var response = await ApiHelper.PostTodoIdCategory(await ApiHelper.GetATodoId(), "");
        //    Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        //}

        //[TestMethod]
        //public async Task TestDeleteTodoIdCategory_ExistedAndIntegerId()
        //{
        //    var response = await ApiHelper.DeleteTodosIdCategory(await ApiHelper.GetATodoId());

        //    Assert.AreEqual(HttpStatusCode.MethodNotAllowed, response.StatusCode);
        //}

        //[TestMethod]
        //public async Task TestDeleteTodoIdCategory_NotExistedAndIntegerId()
        //{
        //    var response = await ApiHelper.DeleteTodosIdCategory(0);

        //    Assert.AreEqual(HttpStatusCode.MethodNotAllowed, response.StatusCode);
        //}

        //[TestMethod]
        //public async Task TestDeleteTodoIdCategory_NotIntegerId()
        //{
        //    var response = await ApiHelper.DeleteTodosIdCategory("not Integer");

        //    Assert.AreEqual(HttpStatusCode.MethodNotAllowed, response.StatusCode);
        //}

        //#endregion

        //#region /todos/:id/category/:id


        //[TestMethod]
        //public async Task TestPutTodoIdCategoryIdSuccessful()
        //{

        //    var response = await ApiHelper.PutTodoIdCategoryId(await ApiHelper.GetATodoId(), 1, "false", "deeeee", "title");
        //    Assert.AreEqual(HttpStatusCode.MethodNotAllowed, response.StatusCode);

        //}
        //[TestMethod]
        //public async Task TestPutTodoIdCategoryIdNotexistedId()
        //{

        //    var response = await ApiHelper.PutTodoIdCategoryId(0, 1, "false", "deeeee", "title");
        //    Assert.AreEqual(HttpStatusCode.MethodNotAllowed, response.StatusCode);

        //}
        //[TestMethod]
        //public async Task TestPutTodoIdCategoryIdExistedIdWithNoTitle()
        //{

        //    var response = await ApiHelper.PutTodoIdCategoryId(await ApiHelper.GetATodoId(), 1, "false", "deeeee", "");
        //    Assert.AreEqual(HttpStatusCode.MethodNotAllowed, response.StatusCode);

        //}

        //[TestMethod]
        //public async Task TestPutTodoIdCategoryIdExistedIdDonestatusNotBoolean()
        //{
        //    var response = await ApiHelper.PutTodoIdCategoryId(await ApiHelper.GetATodoId(), 1, "NOTBool", "deeeee", "");
        //    Assert.AreEqual(HttpStatusCode.MethodNotAllowed, response.StatusCode);
        //}

        //[TestMethod]
        //public async Task TestPatchTodoIdCategoryIdSuccessful()
        //{

        //    var response = await ApiHelper.PatchTodoIdCategoryId(await ApiHelper.GetATodoId(), 1, "false", "deeeee", "title");
        //    Assert.AreEqual(HttpStatusCode.MethodNotAllowed, response.StatusCode);

        //}
        //[TestMethod]
        //public async Task TestPatchTodoIdCategoryIdNotexistedId()
        //{

        //    var response = await ApiHelper.PatchTodoIdCategoryId(0, 1, "false", "deeeee", "title");
        //    Assert.AreEqual(HttpStatusCode.MethodNotAllowed, response.StatusCode);

        //}
        //[TestMethod]
        //public async Task TestPatchTodoIdCategoryIdExistedIdWithNoTitle()
        //{

        //    var response = await ApiHelper.PatchTodoIdCategoryId(await ApiHelper.GetATodoId(), 1, "false", "deeeee", "");
        //    Assert.AreEqual(HttpStatusCode.MethodNotAllowed, response.StatusCode);

        //}

        //[TestMethod]
        //public async Task TestPatchTodoIdCategoryIdExistedIdDonestatusNotBoolean()
        //{
        //    var response = await ApiHelper.PatchTodoIdCategoryId(await ApiHelper.GetATodoId(), 1, "NOTBool", "deeeee", "");
        //    Assert.AreEqual(HttpStatusCode.MethodNotAllowed, response.StatusCode);
        //}




        #endregion
    }
}