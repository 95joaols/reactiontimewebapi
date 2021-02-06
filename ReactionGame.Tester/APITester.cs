using Microsoft.VisualStudio.TestTools.UnitTesting;

using ReactionGame.Entety;

using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace ReactionGame.Tester
{
    [TestClass]
    public class APITester
    {
        private static readonly HttpClientHandler clientHandler = new HttpClientHandler { ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; } };
        private static readonly HttpClient client = new HttpClient(clientHandler);
        private const string serverAdtesAPI = "https://localhost:5001/Highscores";

        [TestInitialize]
        public async Task TestInitializeAsync()
        {
            _ = await client.DeleteAsync(serverAdtesAPI);
        }

        [TestMethod]
        public async Task TestIfICanAddAHighscoreAPIAsync()
        {
            //Arrange
            Highscore highscore = new Highscore("Tester", 100);
            Highscore highscoreFromApi = null;

            //Act
            HttpResponseMessage response = await client.PostAsJsonAsync(serverAdtesAPI, highscore);

            if (response?.IsSuccessStatusCode ?? false)
            {
                highscoreFromApi = await response.Content.ReadFromJsonAsync<Highscore>();
            }


            //Assert
            Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.Created, "StatusCode");
            Assert.IsNotNull(highscoreFromApi, "highscoreFromApi");
        }

        [TestMethod]
        public async Task TestIfICanAddAndGetHighscoresByIdAsync()
        {
            //Arrange
            Highscore highscore = new Highscore("Tester", 100);
            Highscore highscoreFromApi = null;
            HttpResponseMessage response = await client.PostAsJsonAsync(serverAdtesAPI, highscore);
            if (response?.IsSuccessStatusCode ?? false)
            {
                highscoreFromApi = await response.Content.ReadFromJsonAsync<Highscore>();
            }
            else
            {
                Assert.Fail("didend add");
            }

            //Act
            Highscore Gethighscore = await client.GetFromJsonAsync<Highscore>(serverAdtesAPI + "/" + highscoreFromApi.Id);


            //Assert
            Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.Created, "StatusCode");
            Assert.IsNotNull(Gethighscore, "highscoreFromApi");
        }

        [TestMethod]
        public async Task TestIfICanAddAndGetHighscoresByUsernameAsync()
        {
            //Arrange
            Highscore highscore = new Highscore("Tester", 100);
            Highscore highscoreFromApi = null;
            HttpResponseMessage response = await client.PostAsJsonAsync(serverAdtesAPI, highscore);
            if (response?.IsSuccessStatusCode ?? false)
            {
                highscoreFromApi = await response.Content.ReadFromJsonAsync<Highscore>();
            }
            else
            {
                Assert.Fail("didend add");
            }

            //Act
            IEnumerable<Highscore> Gethighscore = await client.GetFromJsonAsync<IEnumerable<Highscore>>(serverAdtesAPI + "/" + highscoreFromApi.Name);


            //Assert
            Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.Created, "StatusCode");
            Assert.IsNotNull(Gethighscore, "highscoreFromApi");
        }

        [TestMethod]
        public async Task TestIfICanAddMultibulAndGetAllAsync()
        {
            //Arrange
            Highscore highscore = new Highscore("Tester", 100);
            Highscore highscore1 = new Highscore("Tester2", 102);
            Highscore highscore2 = new Highscore("Tester1", 101);
            Highscore highscore3 = new Highscore("Tester4", 150);

            _ = await client.PostAsJsonAsync(serverAdtesAPI, highscore);
            _ = await client.PostAsJsonAsync(serverAdtesAPI, highscore1);
            _ = await client.PostAsJsonAsync(serverAdtesAPI, highscore2);
            _ = await client.PostAsJsonAsync(serverAdtesAPI, highscore3);




            //Act
            IEnumerable<Highscore> Gethighscores = await client.GetFromJsonAsync<IEnumerable<Highscore>>(serverAdtesAPI);


            //Assert
            Assert.AreEqual(4, Gethighscores.Count(), "highscoreFromApi");
        }

        [TestMethod]
        public async Task TestIfICanAddDeleteAUsernameAsync()
        {
            //Arrange
            Highscore highscore = new Highscore("Tester", 100);
            Highscore highscore1 = new Highscore("Tester", 102);
            Highscore highscore2 = new Highscore("Tester1", 101);
            Highscore highscore3 = new Highscore("Tester4", 150);

            _ = await client.PostAsJsonAsync(serverAdtesAPI, highscore);
            _ = await client.PostAsJsonAsync(serverAdtesAPI, highscore1);
            _ = await client.PostAsJsonAsync(serverAdtesAPI, highscore2);
            _ = await client.PostAsJsonAsync(serverAdtesAPI, highscore3);




            //Act
            _ = await client.DeleteAsync(serverAdtesAPI + "/Tester");
            IEnumerable<Highscore> Gethighscores = await client.GetFromJsonAsync<IEnumerable<Highscore>>(serverAdtesAPI);


            //Assert
            Assert.AreEqual(2, Gethighscores.Count(), "highscoreFromApi");
        }

        [TestMethod]
        public async Task TestIfICanDeleteAllAsync()
        {
            //Arrange
            Highscore highscore = new Highscore("Tester", 100);
            Highscore highscore1 = new Highscore("Tester", 102);
            Highscore highscore2 = new Highscore("Tester1", 101);
            Highscore highscore3 = new Highscore("Tester4", 150);

            _ = await client.PostAsJsonAsync(serverAdtesAPI, highscore);
            _ = await client.PostAsJsonAsync(serverAdtesAPI, highscore1);
            _ = await client.PostAsJsonAsync(serverAdtesAPI, highscore2);
            _ = await client.PostAsJsonAsync(serverAdtesAPI, highscore3);

            HttpResponseMessage response = null;


            //Act
            _ = await client.DeleteAsync(serverAdtesAPI);
            try
            {
                response = await client.GetAsync(serverAdtesAPI);
            }
            catch (System.Exception)
            {

            }

            //Assert
            Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.NoContent, "StatusCode");
        }

        [TestCleanup]
        public async Task TestCleanupAsync()
        {
            _ = await client.DeleteAsync(serverAdtesAPI);
        }
    }
}
