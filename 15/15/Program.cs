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
            List<List<PlacesV>> Places = new List<List<PlacesV>>() { Cities, Megapolises, Adreses };
            GettingData(Places);
            Console.WriteLine();
        }

        private static void GettingDate(List<List<PlacesV>> Places)
        {
            var CitiesT = from list in Places from place in list where place.ToString().Length >= 9 orderby place select place;
            var CitiesL = Places.SelectMany(List => List.ToArray().Where(place => place is City).Select(place => place));
            //Func<List<PlacesV>, bool> searchFilter = delegate (List<PlacesV> place) { return place.ToArray().Select(delegate(PlacesV pla) { return pla is City; }); };
            //Func<PlacesV[], PlacesV[]> Item = delegate (PlacesV[] s) { return s; };
            //Func<PlacesV, bool> searchFilter2 = delegate (PlacesV place) { return place is City; };
            //var nameCitiesAn = Places.Where(searchFilter).OrderBy(Item).Select(Item);
            var CitiesAn = Places.SelectMany(delegate (List<PlacesV> list) { return list.ToArray().Select(delegate (PlacesV place) { return place as City; }); }); //так и не смог нормально сделать, нулл везде если не город
            Console.WriteLine("linq");
            foreach (PlacesV name in CitiesT)
                Console.WriteLine(name.ToString() + " ");
            Console.WriteLine();

            Console.WriteLine("Лямбда");
            foreach (PlacesV name in CitiesL)
                Console.WriteLine(name.ToString() + " ");
            Console.WriteLine();

            Console.WriteLine("Анонимные методы");
            foreach (PlacesV name in CitiesAn)
                if (name != null)
                    Console.WriteLine(name.ToString() + " ");
            Console.WriteLine();
        }
    }
}
