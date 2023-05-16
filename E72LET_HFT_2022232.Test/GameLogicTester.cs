using E72LET_HFT_2022232.Logic;
using E72LET_HFT_2022232.Models;
using E72LET_HFT_2022232.Repository;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace E72LET_HFT_2022232.Test
{
   
   
    [TestFixture]
    public class GameLogicTester
    {
        GameLogic gamelogic;
        StudioLogic studiologic;
        MinimalSystemRequriementsLogic minlogic;

        [SetUp]
        public void Init()
        {
            Mock<IRepository<Game>> mockGameRepo = new Mock<IRepository<Game>>();
            Mock<IRepository<MinimalSystemRequirements>> mockMinRepo = new Mock<IRepository<MinimalSystemRequirements>>();
            Mock<IRepository<Studio>> mockStudioRepo = new Mock<IRepository<Studio>>();
            gamelogic = new GameLogic(mockGameRepo.Object);
            minlogic = new MinimalSystemRequriementsLogic(mockMinRepo.Object);
            studiologic = new StudioLogic(mockStudioRepo.Object);
        }

        [Test]


        public void ActivisionsGamePriceAverageTest()
        { double? avg = gamelogic.ActivisionsGamePriceAverage();
           
            Assert.That(avg, Is.EqualTo(14));
            
        }
        [Test]
        public void NewestGameTest()
        {
            string newest = gamelogic.NewestGame();
            
            Assert.That(newest == "Activision");
        }


            public void GameCreateValid()
        { Game cons = new Game(100, 10, 10, "Construction Simulator", 3, 2015, 10);
            gamelogic.Create(cons);
            
        }

    }
}
