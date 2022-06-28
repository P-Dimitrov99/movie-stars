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
        //First we need our MovieStar class with all the necessary properties.
        //I added an extra property "age" because we will need to print the age instead of the date of birth.
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
            //Here I am creating a list which will be holding the objects once read from the input.txt file.
            List<MovieStar> movieStars = new List<MovieStar>();
            //First we need to find the path to the file.
            string filePath = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, @"C:\Users\admin 1\Documents\Visual Studio 2017\Projects\MovieStars")) + @"\input.txt";
            //Once we have the path all we need to do is read the full file because it is already in Json format
            //save it in a string because it is still a text file.
            string movieStarJson = File.ReadAllText(filePath);
            //Then we populate the list by deserializing the string with the text.
            movieStars = (JsonConvert.DeserializeObject<List<MovieStar>>(movieStarJson));

            //Now we need a loop to go through every object in the list and calculate the age
            //of every movie star. I do this by transforming the date into days and dividing by 365.
            //All that is left is to print it on the console.
            foreach (MovieStar star in movieStars)
            {
                int totalDays = DateTime.Now.Subtract(star.dateOfBirth).Days;
                star.age = totalDays / 365;

                Console.WriteLine("{0} {1}", star.Name, star.Surname);
                Console.WriteLine(star.Sex);
                Console.WriteLine(star.Nationality);
                Console.WriteLine("{0} years old", star.age);
                Console.WriteLine(' ');
                
            }

        }
        
    }
}
