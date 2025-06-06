using Avengers.Models;
using System.Collections.Generic;
using System.Linq;

namespace Avengers.Services
{
    public class AvgServices
    {
        private List<Avenger> avengers;

        public AvgServices()
        {
            avengers = new List<Avenger>();

            avengers.Add(new Avenger()
            {
                Id = 1,
                Name = "IronMan",
                SuperPowers = "Intelligence,Billionaire"
            });

            avengers.Add(new Avenger()
            {
                Id = 2,
                Name = "SpiderMan",
                SuperPowers = "Web-shooting,Durability,Super-human strength"
            });
        }

        public List<Avenger> GetAvengers()
        {
            return avengers;
        }

        public Avenger GetAvengerById(int id)
        {
            Avenger avenger = avengers.FirstOrDefault(a => a.Id == id);
            if (avenger == null)
            {
                return null;
            }
            return avenger;
        }

        public void AddAvenger(Avenger avenger)
        {
            avenger.Id = avengers.Count + 1;  // Consistent with BookService style
            avengers.Add(avenger);
        }

        public int UpdateAvenger(Avenger avenger)
        {
            Avenger avengerToBeUpdated = GetAvengerById(avenger.Id);
            if (avengerToBeUpdated == null)
            {
                return -1;
            }
            else
            {
                avengerToBeUpdated.Name = avenger.Name;
                avengerToBeUpdated.SuperPowers = avenger.SuperPowers;
                return 1;
            }
        }

        public int DeleteAvenger(int id)
        {
            Avenger avengerToBeRemoved = GetAvengerById(id);
            if (avengerToBeRemoved == null)
            {
                return -1;
            }
            else
            {
                avengers.Remove(avengerToBeRemoved);
                return 1;
            }
        }
    }
}
