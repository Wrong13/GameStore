using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Abstract;

namespace Domain.Concrete
{
    public class EFGameRepository : IGameRepository
    {
        EFDbContext db = new EFDbContext();
        public IEnumerable<Entities.Game> Games
        {
            get { return db.Games; }
        }
    }
}
