using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Abstract;
using Domain.Entities;

namespace Domain.Concrete
{
    public class EFGameRepository : IGameRepository
    {
        EFDbContext db = new EFDbContext();
        public IEnumerable<Entities.Game> Games
        {
            get { return db.Games; }
        }
        public void SaveGame(Game game)
        {
            if (game.GameId == 0)
                db.Games.Add(game);
            else
            {
                Game dbEntry = db.Games.Find(game.GameId);
                if (dbEntry != null)
                {
                    dbEntry.Name = game.Name;
                    dbEntry.Description = game.Description;
                    dbEntry.Price = game.Price;
                    dbEntry.Category = game.Category;
                }
            }
            db.SaveChanges();
        }
    }
}
