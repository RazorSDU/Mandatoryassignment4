using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using Mandatory_assignment_1;

namespace Mandatory_assignment_4.Manager
{
    public class FootballPlayersManager
    {
        private static int _nextId = 1;
        private static readonly List<FootballPlayer> Data = new List<FootballPlayer>
        {
            new FootballPlayer(1, "Johan H. Rauer", 24, 99),
            new FootballPlayer(2, "Bob Andersen", 8, 2),
            new FootballPlayer(3, "Hajdi Christensen", 67, 31),
            new FootballPlayer(4, "Muhammed", 33, 3),
        };

        public List<FootballPlayer> GetAll()
        {
            return new List<FootballPlayer>(Data);
            // copy constructor
            // Callers should no get a reference to the Data object, but rather get a copy
        }

        public FootballPlayer GetById(int? id)
        {
            if (id == null)
            {
                throw new ArgumentNullException();
            }
            return Data.Find(x => x.Id == id);
        }

        public FootballPlayer Add(FootballPlayer newFBP)
        {
            newFBP.Id = _nextId++;
            Data.Add(newFBP);
            return newFBP;
        }

        public FootballPlayer Delete(int id)
        {
            FootballPlayer FBP = Data.Find(FBP => FBP.Id == id);
            if (FBP == null) return null;
            Data.Remove(FBP);
            return FBP;
        }

        public FootballPlayer Update(int id, FootballPlayer updates)
        {
            FootballPlayer FBP = Data.Find(FBP => FBP.Id == id);
            if (FBP == null) return null;
            FBP.ShirtNumber = updates.ShirtNumber;
            FBP.Age = updates.Age;
            FBP.Name = updates.Name;
            return FBP;
        }
    }
}
