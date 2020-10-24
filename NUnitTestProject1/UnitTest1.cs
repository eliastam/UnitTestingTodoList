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

            Assert.AreEqual(2, list.Count());
        }
    }
}