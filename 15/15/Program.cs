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
            GettingCounter(Places);
            Console.WriteLine();
        }

        private static void GettingCounter(List<List<PlacesV>> Places)
        {
            int NumberCities = (from list in Places from place in list where place is City select place).Count();
            int NumberCitiesL = Places.SelectMany(list => list.ToArray().Where(place => place is City).Select(place => place)).Count();
            Func<PlacesV, bool> searchFilter = delegate (PlacesV place) { return place is City; };
            int NumberCitiesAn = Places.SelectMany(delegate (List<PlacesV> list) { return list.ToArray().Where(searchFilter).Select(delegate (PlacesV place) { return place; }); }).Count();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Кол-во городов");
            Console.ResetColor();
            Console.WriteLine("linq");
            Console.WriteLine(NumberCities);
            Console.WriteLine("Лямбда");
            Console.WriteLine(NumberCitiesL);
            Console.WriteLine("Анонимные методы");
            Console.WriteLine(NumberCitiesAn);
        }

        private static void GettingData(List<List<PlacesV>> Places)
        {
            var CitiesT = from list in Places from place in list where place.ToString().Length >= 9 orderby place select place;
            var CitiesL = Places.SelectMany(List => List.ToArray().Where(place => place is City).Select(place => place));
            Func<PlacesV, bool> searchFilter = delegate (PlacesV place) { return place is City; };
            var CitiesAn = Places.SelectMany(delegate (List<PlacesV> list) { return list.ToArray().Where(searchFilter).Select(delegate (PlacesV place) { return place as City; }); }); //так и не смог нормально сделать, нулл везде если не город
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Выборка данных");
            Console.ResetColor();
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
                    Console.WriteLine(name.ToString() + " ");
            Console.WriteLine();
        }
    }
}
