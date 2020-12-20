using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQQueryExpressions
{
    class LINQQueryExpressions
    {
        static void Main()
        {
            // Create a new dictionary of strings, with string keys.
            //
            Dictionary<string, dynamic> openWith =
                new Dictionary<string, dynamic>();

            // Add some elements to the dictionary. There are no
            // duplicate keys, but some of the values are duplicates.
            openWith.Add("txt", 23);
            openWith.Add("bmp", "paint.exe");
            openWith.Add("dib", "paint.exe");
            openWith.Add("rtf", "wordpad.exe");
            Console.WriteLine(openWith);
            
            foreach(var value in openWith)
            {
                Console.WriteLine(value);
            }

            // Specify the data source.
            int[] scores = new int[] { 97, 92, 81, 60, 101};

            // Define the query expression.
            IEnumerable<int> scoreQuery =
                from score in scores
                where score >= 97 && score <= 102 
                select score;
            // Execute the query.
            foreach (int i in scoreQuery)
            {
                Console.Write(i + " ");
            }

            IEnumerable<string> highScoresQuery2 = from score in scores
                                                   where score > 80
                                                   orderby score descending
                                                   select $"The score is {score}";
            foreach (string i in highScoresQuery2)
            {
                Console.Write(i + " ");
            }

            int highScoreCount = (from score in scores
                                   where score > 80
                                   select score).Count();

            Console.Write("\nEscore: "+highScoreCount);

            IEnumerable<int> highScoresQuery3 =  from score in scores
                                                 where score > 80
                                                 select score;

            int scoreCount = highScoresQuery3.Count();
            Console.Write("\nEscore: " + scoreCount);
            //LINQ en clases
            City[] cities = { new City("CDMX", 1000), new City("New York",800), new City("Tokyo",500) };
            //Query syntax
            IEnumerable<City> queryMajorCities =
                              from city in cities
                              where city.population > 10
                              select city;

            foreach (City city_ in queryMajorCities)
            {
                Console.Write("\nPais: " + city_.name + " poblacion: " + city_.population);
            }
            // Method-based syntax
            IEnumerable<City> queryMajorCities2 = cities.Where(c => c.population > 100);

            foreach (City city_ in queryMajorCities2)
            {
                Console.Write("\nPais: " + city_.name + " poblacion: " + city_.population);
            }
            //Max() ToList()

            // Esto seria muy parecido a un queryset object.filter() en Django 
            List<City> largeCitiesList =  (from city in cities
                                          where city.population > 10
                                          select city).ToList();
            
            foreach (City city_ in largeCitiesList)
            {
                Console.Write("\n" + city_.name);
            }
            // Here var is required because the query
            // produces an anonymous type.
            var queryNameAndPop =
                from city in cities
                where city.population >= 800
                select new { Name = city.name, Pop = city.population };

            foreach (var city_ in queryNameAndPop)
            {
                Console.Write("\n" + city_);
            }

            // percentileQuery is an IEnumerable<IGrouping<int, Country>>
            var percentileQuery =
                from country in cities
                let percentile = (int)country.population / 10_000_000
                group country by percentile into countryGroup
                where countryGroup.Key >= 20
                orderby countryGroup.Key
                select countryGroup;

            // grouping is an IGrouping<int, Country>
            foreach (var grouping in percentileQuery)
            {
                Console.WriteLine(grouping.Key);
                foreach (var country in grouping)
                    Console.WriteLine(country.name + ":" + country.population);
            }

            Category category1 = new Category("Calzado");
            Category category2 = new Category("Relojes");

            Product producto1 = new Product("Reloj Ck", category2);
            Product producto2 = new Product("Reloj Hugo Boss", category2);
            Product producto3 = new Product("Zapatos Hermes", category1);
            Category[] categories = { category1, category2 };
            Product[] products = {producto1,producto2,producto3 };

            var categoryQuery =
                               from cat in categories
                               join prod in products on cat equals prod.category
                               select new { Category = cat.name, Name = prod.name };

            foreach (var cat in categoryQuery)
            {
                Console.WriteLine("\n"+cat);
            }
            
        }
    }
}
