using System;
using Mandatory_assignment_1;
using Mandatory_assignment_4.Manager;
using System.ComponentModel.DataAnnotations;

namespace Mandatory_assignment_4_User_tests
{
    [TestClass]
    public class TestFootballPlayersManager
    {
        [TestMethod]
        public void TestGetAll()
        {
            // Arrange
            List<FootballPlayer> Data = new List<FootballPlayer>
            {
            new FootballPlayer(1, "Johan H. Rauer", 24, 99),
            new FootballPlayer(2, "Bob Andersen", 8, 2),
            new FootballPlayer(3, "Hajdi Christensen", 67, 31),
            new FootballPlayer(4, "Muhammed", 33, 3),
            };
            FootballPlayersManager FBPM = new FootballPlayersManager();
            // Act
            List<FootballPlayer> newData = FBPM.GetAll();
            // Assert
            Assert.AreEqual(newData.Count, Data.Count);

        }

        [TestMethod]
        public void TestGetByID()
        {
            // Arrange
            List<FootballPlayer> Data = new List<FootballPlayer>
            {
            new FootballPlayer(1, "Johan H. Rauer", 24, 99),
            new FootballPlayer(2, "Bob Andersen", 8, 2),
            new FootballPlayer(3, "Hajdi Christensen", 67, 31),
            new FootballPlayer(4, "Muhammed", 33, 3),
            };
            FootballPlayersManager FBPM = new FootballPlayersManager();
            // Act
            FootballPlayer ID1 = FBPM.GetById(1);
            FootballPlayer ID2 = FBPM.GetById(2);
            FootballPlayer ID3 = FBPM.GetById(3);
            FootballPlayer ID4 = FBPM.GetById(4);
            // Assert
            Assert.AreEqual(ID1.Id, Data.Find(x => x.Id == 1).Id);
            Assert.AreEqual(ID1.Name, Data.Find(x => x.Id == 1).Name);
            Assert.AreEqual(ID1.Age, Data.Find(x => x.Id == 1).Age);
            Assert.AreEqual(ID1.ShirtNumber, Data.Find(x => x.Id == 1).ShirtNumber);
            Assert.AreEqual(ID2.Name, Data.Find(x => x.Id == 2).Name);
            Assert.AreEqual(ID3.Name, Data.Find(x => x.Id == 3).Name);
            Assert.AreEqual(ID4.Name, Data.Find(x => x.Id == 4).Name);

        }
    }
}