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
      static  GameLogic gamelogic;
       static StudioLogic studiologic;
     static   MinimalSystemRequriementsLogic minlogic;
  static      Mock<IRepository<Game>> mockGameRepo;
      static  Mock<IRepository<MinimalSystemRequirements>> mockMinRepo;
       static Mock<IRepository<Studio>> mockStudioRepo;

    [SetUp]
        public void Init()
        {
           mockGameRepo = new Mock<IRepository<Game>>();
            mockMinRepo = new Mock<IRepository<MinimalSystemRequirements>>();
             mockStudioRepo = new Mock<IRepository<Studio>>();
            mockGameRepo.Setup(x => x.ReadAll()).Returns(new List<Game>()
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
            mockGameRepo.Setup(x => x.Read(1)).Returns(new Game(1, 1, 1, "GameA", 3, 2012, 10));
            mockGameRepo.Setup(x => x.Read(2)).Returns(new Game(2, 1, 2, "GameB", 3, 2007, 18));
            mockGameRepo.Setup(x => x.Read(3)).Returns(new Game(3, 2, 3, "GameC", 3, 2008, 10));
            mockGameRepo.Setup(x => x.Read(4)).Returns(new Game(4, 3, 3, "GameD", 3, 2010, 10));
            mockGameRepo.Setup(x => x.Read(5)).Returns(new Game(5, 4, 4, "GameE", 16, 2003, 10));
            mockGameRepo.Setup(x => x.Read(6)).Returns(new Game(6, 4, 5, "GameF", 16, 2007, 10));
            mockGameRepo.Setup(x => x.Read(7)).Returns(new Game(7, 4, 5, "GameG", 18, 2008, 15));
            mockGameRepo.Setup(x => x.Read(8)).Returns(new Game(8, 4, 6, "GameH", 18, 2015, 15));
            mockGameRepo.Setup(x => x.Read(9)).Returns(new Game(9, 4, 7, "GameI", 18, 2017, 20));
            mockGameRepo.Setup(x => x.Read(10)).Returns(new Game(10, 5, 8, "GameJ", 18, 2005, 63));
            mockGameRepo.Setup(x => x.Read(11)).Returns(new Game(11, 5, 9, "GameK", 18, 2009, 20));
           
            mockStudioRepo.Setup(x => x.ReadAll()).Returns(new List<Studio>()
            {new Studio(1,"SCS Software"),
                new Studio(2,"Contendo media"),
                new Studio(3,"Libredia"),
                new Studio(4,"Activison"),
                new Studio(5,"Rockstar Games"), }.AsQueryable());
            mockStudioRepo.Setup(x => x.Read(1)).Returns(new Studio(1,"SCS Software"));
            mockStudioRepo.Setup(x => x.Read(2)).Returns(new Studio(2,"Contendo media"));
            mockStudioRepo.Setup(x => x.Read(3)).Returns(new Studio(3, "Libredia"));
            mockStudioRepo.Setup(x => x.Read(4)).Returns(new Studio(4, "Activison"));
            mockStudioRepo.Setup(x => x.Read(5)).Returns(new Studio(5, "Rockstar Games"));
            mockMinRepo.Setup(x=> x.ReadAll()).Returns(new List<MinimalSystemRequirements>()
            {new MinimalSystemRequirements(1,"Windows Xp",2048,1.5,"Intel Core 2 Duo",2.4,"Nvidia GeForce GTS 450",1024),
              new MinimalSystemRequirements(2,"Windows 98",256,0.3,"Intel Pentium 3",1,"Nvidia GeForce 4 Ti",128),
              new MinimalSystemRequirements(3,"Windows Xp",512,1,"Intel Pentium 4",1.5,"Nvidia GeForce 6800",128),
              new MinimalSystemRequirements(4,"Windows 98",128,1.4,"Intel Pentium 3",0.6,"Nvidia Geforce 256",32),
              new MinimalSystemRequirements(5,"Windows Xp",512,8,"Intel Pentium 4",2.4,"Nvidia GeForce 6600",256),
              new MinimalSystemRequirements(6,"Windows 7",6144,100,"Intel Core I3-530",2.93,"Nvidia GeForce GTX 470",1024),
              new MinimalSystemRequirements(7,"Windows 7",8192,90,"Intel Core I3-3225",3.3,"Nvidia GeForce GTX 660",2048),
              new MinimalSystemRequirements(8,"Windows 2000",256,3.6,"Intel Pentium 3",1,"Nvidia GeForce 3",256),
              new MinimalSystemRequirements(9,"Windows Xp",1536,16,"Intel Core 2 Duo",1.8,"Nvidia GeForce GTS 7900",256), }.AsQueryable());
            mockMinRepo.Setup(x => x.Read(1)).Returns(new MinimalSystemRequirements(1, "Windows Xp", 2048, 1.5, "Intel Core 2 Duo", 2.4, "Nvidia GeForce GTS 450", 1024));
            mockMinRepo.Setup(x => x.Read(2)).Returns(new MinimalSystemRequirements(2, "Windows 98", 256, 0.3, "Intel Pentium 3", 1, "Nvidia GeForce 4 Ti", 128));
            mockMinRepo.Setup(x => x.Read(3)).Returns(new MinimalSystemRequirements(3, "Windows Xp", 512, 1, "Intel Pentium 4", 1.5, "Nvidia GeForce 6800", 128));
            mockMinRepo.Setup(x => x.Read(4)).Returns(new MinimalSystemRequirements(4, "Windows 98", 128, 1.4, "Intel Pentium 3", 0.6, "Nvidia Geforce 256", 32));
            mockMinRepo.Setup(x => x.Read(5)).Returns(new MinimalSystemRequirements(5, "Windows Xp", 512, 8, "Intel Pentium 4", 2.4, "Nvidia GeForce 6600", 256));
            mockMinRepo.Setup(x => x.Read(6)).Returns(new MinimalSystemRequirements(6, "Windows 7", 6144, 100, "Intel Core I3-530", 2.93, "Nvidia GeForce GTX 470", 1024));
            mockMinRepo.Setup(x => x.Read(7)).Returns(new MinimalSystemRequirements(7, "Windows 7", 8192, 90, "Intel Core I3-3225", 3.3, "Nvidia GeForce GTX 660", 2048));
            mockMinRepo.Setup(x => x.Read(8)).Returns(new MinimalSystemRequirements(8, "Windows 2000", 256, 3.6, "Intel Pentium 3", 1, "Nvidia GeForce 3", 256));
            mockMinRepo.Setup(x => x.Read(9)).Returns(new MinimalSystemRequirements(9, "Windows Xp", 1536, 16, "Intel Core 2 Duo", 1.8, "Nvidia GeForce GTS 7900", 256));

            gamelogic = new GameLogic(mockGameRepo.Object,mockStudioRepo.Object,mockMinRepo.Object);
            minlogic = new MinimalSystemRequriementsLogic(mockMinRepo.Object);
            studiologic = new StudioLogic(mockStudioRepo.Object);
        }

        
        

        [Test]
            public void GameCreateValid()
        { Game cons = new Game(100, 10, 10, "Construction Simulator", 3, 2015, 10);
            gamelogic.Create(cons);
            mockGameRepo.Verify(x => x.Create(cons), Times.Once());
            
        }
        [Test]
        public void StudioCreateValid()
        { Studio stud = new Studio(10, "AdamSoft");
            studiologic.Create(stud);
            mockStudioRepo.Verify(x => x.Create(stud), Times.Once());
        }
        [Test]
        public void MinimialSystemRequrimentsCreateValid()
        { MinimalSystemRequirements min = new MinimalSystemRequirements(100, "Windows 10", 2048, 20, "Intel Core I3", 3, "AMD Radeon R7 360", 2048);
            minlogic.Create(min);
            mockMinRepo.Verify(x => x.Create(min), Times.Once());


}

        [Test]
        public void GameCreateInvalid()
        { Game g = new Game(100, 100, 100, "Game", 3, 2010, 10);
            
            Assert.That(() => gamelogic.Create(g), Throws.TypeOf<ArgumentException>());
        }
        [Test]
        public void StudioCreateInvalid()
        { Studio s = new Studio(100, "Stu");
            Assert.That(() => studiologic.Create(s), Throws.TypeOf<ArgumentException>());
        }
        [Test]
        public void MinimalSystemRequriementCreateInvalid()
        { MinimalSystemRequirements min = new MinimalSystemRequirements(100, "OS", 2048, 20, "Intel Core I5", 3, "Nvidia Geforce 750 Ti", 2048);
            Assert.That(() => minlogic.Create(min), Throws.TypeOf<ArgumentException>());
        }
        [Test]
        public void GameReadValidTest()
        { Game readed = gamelogic.Read(1);
            Game first = new Game(1, 1, 1, "GameA", 3, 2012, 10);
            Assert.That(readed, Is.EqualTo(first));
            
        }
        [Test]
        public void GameReadInvalidTest()
        {
            Assert.That(() => gamelogic.Read(50), Throws.TypeOf<ArgumentException>());
        }
        [Test]
        public void StudioReadValidTest()
        { Studio readed = studiologic.Read(1);
            Studio first = new Studio(1, "SCS Software");
            Assert.That(readed, Is.EqualTo(first));
        }
        [Test]
        public void StudioReadInvalidTest()
        { Assert.That(() => studiologic.Read(20), Throws.TypeOf<ArgumentException>());    }

        [Test]
        public void MinimalSystemRequrimentsReadValidTest()
        { MinimalSystemRequirements readed = minlogic.Read(1);
            MinimalSystemRequirements first = new MinimalSystemRequirements(1, "Windows Xp", 2048, 1.5, "Intel Core 2 Duo", 2.4, "Nvidia GeForce GTS 450", 1024);
            Assert.That(readed, Is.EqualTo(first));
        }

        [Test]
        public void MinimalSystemRequrimentsReadInvalidTest()
        { Assert.That(() => minlogic.Read(78), Throws.TypeOf<ArgumentException>()); }

        //Non Crud Tests

        [Test]
        
        public void CountOfWin98()
        { int? count = gamelogic.CountOfWin98();
            Assert.That(count, Is.EqualTo(2));
        }
        [Test]
        public void FirstRockstarTest()
        {
            int? libredia = gamelogic.FirstRockstar();
            Assert.That(libredia,Is.EqualTo( 2005));
        }
        [Test]
        public void ContendoCountTest()
        { int? contendo = gamelogic.ContendoCount();
            Assert.That(contendo, Is.EqualTo(1));
        }
        [Test]


        public void ActivisionsGamePriceAverageTest()
        {
            var avg = gamelogic.ActivisionsGamePriceAverage();

            Assert.That(avg, Is.EqualTo(14));

        }
        [Test]
        
        public void NewestGameTest()
        {
            var newest = gamelogic.NewestGame();

            Assert.That(newest == "Activison");
        }

    }
}
