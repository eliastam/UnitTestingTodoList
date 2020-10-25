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
    public class Tests
    {
        HttpClient client = new HttpClient();

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task  Test1()
        {
            var list = await ApiHelper.GetAllTodos();

            Assert.AreEqual(list.Count(), list.Count());
        }

        [Test]
        public async Task TestCreateATodo()
        {
            var list = await ApiHelper.GetAllTodos();
            var CountBeforeAddition = list.Count();
            await ApiHelper.CreateTodo("false", "deeeee" , "elias");

            var list2 = await ApiHelper.GetAllTodos();
            var CountAfterAddition = list2.Count();
            Assert.AreEqual(CountBeforeAddition+ 1, CountAfterAddition);
        }

        
    }
}