using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MainLibrary;
using System.Threading.Tasks;

namespace _15
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            List<PlacesV> Cities = new List<PlacesV>();
            for (int i = 0; i < 5; i++)
                Cities.Add(new City(City.RandomCity(rand)));
            List<PlacesV> Megapolises = new List<PlacesV>();
            for (int i = 0; i < 6; i++)
                Megapolises.Add(new Megapolis(Megapolis.RandomMegapolis(rand)));
            List<PlacesV> Adreses = new List<PlacesV>();
            for (int i = 0; i < 7; i++)
                Adreses.Add(new Adres(Adres.RandomAdres(rand)));
            List<List<PlacesV>> Places = new List<List<PlacesV>>() {Cities,Megapolises,Adreses };
            var namesCities = from list in Places from place in list where place.ToString().Length>=9 orderby place select place;
            var namesCitiesL = Places.SelectMany(List => List.ToArray().Where(place => place is City).Select(place => place));
            Console.WriteLine();
        }
    }
}
