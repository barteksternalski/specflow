using specflowPoC.Learner;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using TechTalk.SpecFlow;

namespace specflowPoC.StepsDefinition
{
    [Binding]
    class LinqSteps
    {
        [Given(@"Show me how to use linq")]
        public void GivenShowMeHowToUseLinq()
        {
            var cars = ProcessFile(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"..\..\TestFiles\", "fuel.csv"));

            var query = cars.OrderByDescending(c => c.Combined)
                            .ThenBy(c => c.Name)
                            .Where(c => c.Manufacturer == "BMW" && c.Year == 2016);

            var query2 = cars.GroupBy(c => c.Manufacturer.ToUpper())
                .OrderBy(g => g.Key);

            foreach (var car in query.Take(10))
            {
                Console.WriteLine($"{car.Manufacturer} {car.Name}: {car.Combined}");
            }

            foreach (var group in query2)
            {
                Console.WriteLine($"{group.Key}");
                foreach(var car in group.OrderByDescending(c => c.Combined).Take(2))
                {
                    Console.WriteLine($"\t{car.Name} : {car.Combined}");
                }
            }

        }

        private static List<Car> ProcessFile(string path)
        {
            return
                File.ReadAllLines(path)
                    .Skip(1)
                    .Where(line => line.Length > 1)
                    .Select(Car.ParseFromCsv)
                    .ToList();
        }

    }
}
