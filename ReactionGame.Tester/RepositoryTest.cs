using Microsoft.VisualStudio.TestTools.UnitTesting;

using ReactionGame.Entety;
using ReactionGame.Repository;

using System.Threading.Tasks;

namespace ReactionGame.Tester
{
    [TestClass]
    public class RepositoryTest
    {
        [TestMethod]
        public async Task TestIfICanAddAHighscoreAsync()
        {
            //Arrange
            Highscore highscore = new Highscore("Tester",100);
            IHighscoreRepository repository = new HighscoreRepositoryFile("Tester");

            //Act
            Highscore addedHighscore = await repository.NewHighscores(highscore);

            //Assert
            Assert.IsNotNull(addedHighscore);
        }
    }
}
