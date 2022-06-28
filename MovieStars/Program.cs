using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace MovieStars
{
    class Program
    {
        public class MovieStar
        {
            public DateTime dateOfBirth { get; set; }
            public string Name { get; set; }
            public string Surname { get; set; }
            public string Sex { get; set; }
            public string Nationality { get; set; }
            public int age { get; set; }
        }
        static void Main(string[] args)
        {
            List<MovieStar> movieStars = new List<MovieStar>();
            string filePath = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, @"C:\Users\admin 1\Documents\Visual Studio 2017\Projects\MovieStars")) + @"\input.txt";
            string movieStarJson = File.ReadAllText(filePath);
            movieStars = (JsonConvert.DeserializeObject<List<MovieStar>>(movieStarJson));

            foreach (MovieStar star in movieStars)
            {
                int totalDays = DateTime.Now.Subtract(star.dateOfBirth).Days;
                star.age = totalDays / 365;

                Console.WriteLine("{0} {1}", star.Name, star.Surname);
                Console.WriteLine(star.Sex);
                Console.WriteLine(star.Nationality);
                Console.WriteLine(star.age);
                Console.WriteLine(' ');
                
            }

        }
        
    }
}
