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
            GettingVariety(Places);
            GettingAgregate(Places);
            GettingMinMax(Places);
            Console.WriteLine();
        }

        private static void GettingAgregate(List<List<PlacesV>> Places)
        {
            Func<PlacesV, int> temp = delegate (PlacesV pl) { return 1; };
            int CountPlaces = (from list in Places from place in list select place).Sum(temp);
            int AllLengthL = Places.SelectMany(list => list.ToArray().Select(place => place.ToString().Length)).Aggregate((a, b) => a + b);
            int AllLengthL2 = Places.SelectMany(list => list.ToArray().Where(place => place is City).Select(place => place.ToString().Length)).Aggregate((a, b) => a + b);
            Func<int, int, int> sum = delegate (int a, int b) { return a + b; };
            Func<PlacesV, bool> searchFilter = delegate (PlacesV place) { return place is City; };
            int AllLengthAn = Places.SelectMany(delegate (List<PlacesV> list) { return list.ToArray().Where(searchFilter).Select(delegate (PlacesV place) { return place.ToString().Length; }); }).Aggregate(sum);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Агрегирование");
            Console.ResetColor();
            Console.WriteLine("linq Количество мест");
            Console.WriteLine(CountPlaces);
            Console.WriteLine("Лямбда Длина нвзывний всех мест");
            Console.WriteLine(AllLengthL);
            Console.WriteLine("Лямбда Длина названий городов");
            Console.WriteLine(AllLengthL2);
            Console.WriteLine("Лямбда Длина названий городов");
            Console.WriteLine(AllLengthAn);
        }

        private static void GettingMinMax(List<List<PlacesV>> Places)
        {
            PlacesV Place = (from list in Places from place in list select place).Max();
            PlacesV PlaceL = (Places.SelectMany(list => list.ToArray().Select(place => place))).Min();
            PlacesV PlaceAN = Places.SelectMany(delegate (List<PlacesV> list) { return list.ToArray().Select(delegate (PlacesV place) { return place; }); }).Max();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Запрос 5");
            Console.ResetColor();
            Console.WriteLine("linq Самое короткое название места");
            Console.WriteLine(Place);
            Console.WriteLine("Лямбда Самое длинное название места");
            Console.WriteLine(PlaceL);
            Console.WriteLine("Анонимные методы Самое короткое название места");
            Console.WriteLine(PlaceAN);
        }

        private static void GettingVariety(List<List<PlacesV>> Places)
        {
            var PlacesDIf = (from list in Places from place in list where place is City select place).Except(from list2 in Places from place in list2 where place.ToString().Length > 12 select place);
            var PlacesDifL = Places.SelectMany(list => list.ToArray().Where(place => place is City).Select(place => place)).Except(Places.SelectMany(list => list.ToArray().Where(place => place.ToString().Length > 12).Select(place => place)));
            Func<PlacesV, bool> searchFilter = delegate (PlacesV place) { return place is City; };
            Func<PlacesV, bool> searchFilter2 = delegate (PlacesV place) { return place.ToString().Length > 12; };
            var PlacesDifAn = Places.SelectMany(delegate (List<PlacesV> list) { return list.ToArray().Where(searchFilter).Select(delegate (PlacesV place) { return place; }); }).Except
                (Places.SelectMany(delegate (List<PlacesV> list) { return list.ToArray().Where(searchFilter2).Select(delegate (PlacesV place) { return place; }); }));
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Множества");
            Console.ResetColor();
            Console.WriteLine("linq");
            foreach (PlacesV name in PlacesDIf)
                Console.WriteLine(name.ToString() + " ");
            Console.WriteLine();
            Console.WriteLine("Лямбда");
            foreach (PlacesV name in PlacesDifL)
                Console.WriteLine(name.ToString() + " ");
            Console.WriteLine();
            Console.WriteLine("Анонимные методы");
            foreach (PlacesV name in PlacesDifAn)
                Console.WriteLine(name.ToString() + " ");
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
