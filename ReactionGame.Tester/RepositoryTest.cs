using Microsoft.VisualStudio.TestTools.UnitTesting;

using ReactionGame.Entety;
using ReactionGame.Repository;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ReactionGame.Tester
{
    [TestClass]
    public class RepositoryTest
    {
        private const string testfile = "Tester.txt";
        [TestMethod]
        public async Task TestIfICanAddAHighscoreAsync()
        {
            //Arrange
            Highscore highscore = new Highscore("Tester", 100);
            IHighscoreRepository repository = new HighscoreRepositoryFile(testfile);

            //Act
            Highscore addedHighscore = await repository.NewHighscores(highscore);

            //Assert
            Assert.IsNotNull(addedHighscore);
        }

        [TestMethod]
        public async Task TestIfICanGetTheLastTestDataAsync()
        {
            //Arrange
            IHighscoreRepository repository = new HighscoreRepositoryFile(testfile);

            Highscore highscore = new Highscore("Tester", 100);
            Highscore addedHighscore = await repository.NewHighscores(highscore);

            //Act
            Highscore GetHighscores = await repository.GetHighscoresById(addedHighscore.Id);

            //Assert
            Assert.IsNotNull(GetHighscores);
        }

        [TestMethod]
        public async Task TestIfICanGetAllHighscoreByUsernameAsync()
        {
            //Arrange
            IHighscoreRepository repository = new HighscoreRepositoryFile(testfile);

            Highscore highscore = new Highscore("Tester", 100);
            Highscore highscore1 = new Highscore("Tester1", 100);
            Highscore highscore2 = new Highscore("Tester", 100);
            Highscore highscore3 = new Highscore("Tester3", 100);

            _ = await repository.NewHighscores(highscore);
            _ = await repository.NewHighscores(highscore1);
            _ = await repository.NewHighscores(highscore2);
            _ = await repository.NewHighscores(highscore3);

            //Act
            IEnumerable<Highscore> GetHighscores = await repository.GetHighscoresByUsername("Tester");

            //Assert
            Assert.AreEqual(2, GetHighscores?.Count());
        }

        [TestMethod]
        public async Task TestIfIAdd3DataThatIGet3DataAsync()
        {
            //Arrange
            IHighscoreRepository repository = new HighscoreRepositoryFile(testfile);

            Highscore highscore = new Highscore("Tester", 100);
            Highscore highscore1 = new Highscore("Tester", 1010);
            Highscore highscore2 = new Highscore("Tester", 110);
            _ = await repository.NewHighscores(highscore);
            _ = await repository.NewHighscores(highscore1);
            _ = await repository.NewHighscores(highscore2);

            //Act
            IEnumerable<Highscore> GetHighscores = await repository.GetHighscores();

            //Assert
            Assert.AreEqual(3, GetHighscores?.Count());
        }

        [TestMethod]
        public async Task TestIfICanRemoveAllHighscoreAsync()
        {
            //Arrange
            Highscore highscore = new Highscore("Tester", 100);
            IHighscoreRepository repository = new HighscoreRepositoryFile(testfile);
            _ = await repository.NewHighscores(highscore);

            //Act
            await repository.DeleteAllHighscores();
            IEnumerable<Highscore> GetHighscores = await repository.GetHighscores();

            //Assert
            Assert.AreEqual(0, GetHighscores?.Count());
        }

        [TestMethod]
        public async Task TestIfICannotAddBadDataAsync()
        {
            //Arrange
            Highscore highscoreNull = null;
            Highscore highscoreNullName = new Highscore(null, 100);
            Highscore highscoreNoName = new Highscore("", 100);
            Highscore highscoreNotime = new Highscore("", 0);
            IHighscoreRepository repository = new HighscoreRepositoryFile(testfile);

            //Act
            Highscore addedhighscoreNull = null;
            try
            {
                addedhighscoreNull = await repository.NewHighscores(highscoreNull);

            }
            catch (System.Exception)
            {
            }
            Highscore addedhighscoreNullName = null;
            try
            {
                addedhighscoreNullName = await repository.NewHighscores(highscoreNullName);

            }
            catch (System.Exception)
            {
            }
            Highscore addedhighscoreNoName = null;
            try
            {
                addedhighscoreNoName = await repository.NewHighscores(highscoreNull);

            }
            catch (System.Exception)
            {
            }
            Highscore addedhighscoreNotime = null;
            try
            {
                addedhighscoreNotime = await repository.NewHighscores(highscoreNotime);

            }
            catch (System.Exception)
            {
            }
            File.Delete(testfile);

            //Assert
            Assert.IsNull(addedhighscoreNull, "addedhighscoreNull");
            Assert.IsNull(addedhighscoreNullName, "addedhighscoreNullName");
            Assert.IsNull(addedhighscoreNoName, "addedhighscoreNoName");
            Assert.IsNull(addedhighscoreNotime, "addedhighscoreNotime");
        }

        [TestMethod]
        public async Task TestIfICanRemoveAllTesterHighscoreAsync()
        {
            //Arrange
            Highscore highscore = new Highscore("Tester", 100);
            Highscore highscore2 = new Highscore("Tester", 100);
            Highscore highscore3 = new Highscore("Tester1", 100);
            Highscore highscore4 = new Highscore("Tester1", 100);
            IHighscoreRepository repository = new HighscoreRepositoryFile(testfile);
            _ = await repository.NewHighscores(highscore);
            _ = await repository.NewHighscores(highscore2);
            _ = await repository.NewHighscores(highscore3);
            _ = await repository.NewHighscores(highscore4);


            //Act
            await repository.DeleteHighscoresFromUsername("Tester");
            IEnumerable<Highscore> GetHighscores = await repository.GetHighscores();

            //Assert
            Assert.AreEqual(2, GetHighscores?.Count());
        }
        //[TestMethod]
        //public async Task TestIfICanGetTAsync()
        //{
        //    //Arrange
        //    Highscore highscore = new Highscore("Tester", 100);
        //    Highscore highscore2 = new Highscore("Tester", 100);
        //    Highscore highscore3 = new Highscore("Tester1", 100);
        //    Highscore highscore4 = new Highscore("Tester1", 100);
        //    IHighscoreRepository repository = new HighscoreRepositoryFile(testfile);
        //    Highscore newHighscores = await repository.NewHighscores(highscore);
        //    _ = await repository.NewHighscores(highscore2);
        //    _ = await repository.NewHighscores(highscore3);
        //    _ = await repository.NewHighscores(highscore4);


        //    //Act
        //    Highscore Returnhighscore1 = await repository.GetT<Highscore, Highscore, int>(newHighscores.Id);
        //    IEnumerable<Highscore> Returnhighscore2 = await repository.GetT<IEnumerable<Highscore>, Highscore, string>("Tester1");
        //    IEnumerable<Highscore> GetHighscores = await repository.GetHighscores();

        //    //Assert
        //    Assert.IsNotNull(Returnhighscore1, "Returnhighscore1");
        //    Assert.AreEqual(2, Returnhighscore2.c, "Returnhighscore1");
        //}

        [TestCleanup]
        public void TestCleanup()
        {
            File.Delete(testfile);
        }
    }
}
