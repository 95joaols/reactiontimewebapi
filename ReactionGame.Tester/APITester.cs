using Microsoft.VisualStudio.TestTools.UnitTesting;

using ReactionGame.Entety;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace ReactionGame.Tester
{
    [TestClass]
    public class APITester
    {
        static HttpClientHandler clientHandler = new HttpClientHandler { ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; } };
        static HttpClient client = new HttpClient(clientHandler);
        const string serverAdtesAPI = "http://localhost:5000/Highscores";

        [TestMethod]
        public async Task TestIfICanAddAHighscoreAPIAsync()
        {
            //Arrange
            Highscore highscore = new Highscore("Tester", 100);

            //Act
            HttpResponseMessage httpResponseMessage = await client.PostAsJsonAsync(serverAdtesAPI, highscore);


            //Assert
            Assert.IsTrue(httpResponseMessage.StatusCode == System.Net.HttpStatusCode.Created);
        }
    }
}
