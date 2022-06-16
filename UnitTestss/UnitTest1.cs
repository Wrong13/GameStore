using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace UnitTestss
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Can_Paginate()
        {
        //    // Организация

        //    Mock<Domain.Abstract.IGameRepository> mock = new Mock<Domain.Abstract.IGameRepository>();
        //    mock.Setup(x => x.Games).Returns(new List<Domain.Entities.Game>
        //    {
        //        new Domain.Entities.Game { GameId = 1,Name = "Игра1"},
        //        new Domain.Entities.Game { GameId = 2,Name = "Игра2"},
        //        new Domain.Entities.Game { GameId = 3,Name = "Игра3"},
        //        new Domain.Entities.Game { GameId = 4,Name = "Игра4"},
        //        new Domain.Entities.Game { GameId = 5,Name = "Игра5"}

        //    });
        //    WebUI.Controllers.GameController controller = new WebUI.Controllers.GameController(mock.Object);
        //    controller.pageSize = 3;

        //    // Действие

        //    IEnumerable<Domain.Entities.Game> rezult =
        //        (IEnumerable<Domain.Entities.Game>)controller.List(2).Model;

        //    // Утверждение

        //    List<Domain.Entities.Game> games = rezult.ToList();
        //    Assert.IsTrue(games.Count == 2);
        //    Assert.AreEqual(games[0].Name, "Игра4");
        //    Assert.AreEqual(games[1].Name, "Игра5");
        }
    }
}
