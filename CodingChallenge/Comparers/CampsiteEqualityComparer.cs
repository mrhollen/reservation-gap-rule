using System.Collections;
using System.Collections.Generic;
using CodingChallenge.Models;

namespace CodingChallenge
{
    public class CampsiteEqualityComparer : IEqualityComparer<Campsite>
    {
        public bool Equals(Campsite a, Campsite b)
        {
            return a.Id == b.Id;
        }

        public int GetHashCode(Campsite campsite)
        {
            return campsite.Id;
        }
    }
}