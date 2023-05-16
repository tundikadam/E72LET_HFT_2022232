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
        Mock<IRepository<Game>> mockGameRepo;
        Mock<IRepository<MinimalSystemRequirements>> mockMinRepo;
        Mock<IRepository<Studio>> mockStudioRepo;

    [SetUp]
        public void Init()
        {
           mockGameRepo = new Mock<IRepository<Game>>();
            mockMinRepo = new Mock<IRepository<MinimalSystemRequirements>>();
             mockStudioRepo = new Mock<IRepository<Studio>>();
            mockGameRepo.Setup(m => m.ReadAll()).Returns(new List<Game>()
            {new Game(1,1,1,"GameA",3,2012,10),
                new Game(2,1,2,"GameB",3,2007,18),
                new Game(3,2,3,"GameC",3,2008,10),
                new Game(4 ,3,3,"GameD",3,2010,10),
               new Game(5,4,4,"GameE",16,2003,10),
               new Game(6,4,5,"GameF",16,2007,10),
                 new Game(7,4,5,"GameG",18,2008,15),
                 new Game(8,4,6,"GameH",18,2015,15),
                 new Game(9,4,7,"GameI",18,2017,20),
                 new Game(10,5,8,"GameJ",18,2005,63),
                 new Game(11,5,9,"GameK",18,2009,20),

            }.AsQueryable());
            mockStudioRepo.Setup(m => m.ReadAll()).Returns(new List<Studio>()
            {new Studio(1,"SCS Software"),
                new Studio(2,"Contendo media"),
                new Studio(3,"Libredia"),
                new Studio(4,"Activison"),
                new Studio(5,"Rockstar Games"), }.AsQueryable());
            mockMinRepo.Setup(m => m.ReadAll()).Returns(new List<MinimalSystemRequirements>()
            {new MinimalSystemRequirements(1,"Windows Xp",2048,1.5,"Intel Core 2 Duo",2.4,"Nvidia GeForce GTS 450",1024),
              new MinimalSystemRequirements(2,"Windows 98",256,0.3,"Intel Pentium 3",1,"Nvidia GeForce 4 Ti",128),
              new MinimalSystemRequirements(3,"Windows Xp",512,1,"Intel Pentium 4",1.5,"Nvidia GeForce 6800",128),
              new MinimalSystemRequirements(4,"Windows 98",128,1.4,"Intel Pentium 3",0.6,"Nvidia Geforce 256",32),
              new MinimalSystemRequirements(5,"Windows Xp",512,8,"Intel Pentium 4",2.4,"Nvidia GeForce 6600",256),
              new MinimalSystemRequirements(6,"Windows 7",6144,100,"Intel Core I3-530",2.93,"Nvidia GeForce GTX 470",1024),
              new MinimalSystemRequirements(7,"Windows 7",8192,90,"Intel Core I3-3225",3.3,"Nvidia GeForce GTX 660",2048),
              new MinimalSystemRequirements(8,"Windows 2000",256,3.6,"Intel Pentium 3",1,"Nvidia GeForce 3",256),
              new MinimalSystemRequirements(9,"Windows Xp",1536,16,"Intel Core 2 Duo",1.8,"Nvidia GeForce GTS 7900",256), }.AsQueryable());
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
