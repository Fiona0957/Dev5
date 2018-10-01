using System;
using Model;
using System.Linq;

namespace Dev_Practice
{
    class Program
    {
        static void Main(string[] args)
        {
            Projection();
        }
        //using (var db = new MovieContext())
        //{
        //Movie m = new Movie
        //{
        //    Title = "Divorce Italian Style",
        //    Release = DateTime.Now,
        //    Actors = new System.Collections.Generic.List<Actor> {
        //new Actor{ Name = "Marcello Mastroianni",
        //            Birth = new DateTime(1988, 8, 29),
        //            Gender=  "Male",
        //            },
        //new Actor{ Name = "Daniela Rocca",
        //            Birth = new DateTime(1986, 5, 1),
        //            Gender=  "Female",
        //            }
        //    }
        //};

        //db.Add(m);        
        static void Projection()
        {
            using (var db = new MovieContext())
            {
                var projected_movies = from movie in db.Movies let actors_of_movie = (from actor in db.Actors where actor.MovieId == movie.Id select actor) where actors_of_movie.Count() > 3 select new { Title = movie.Title, ActorsCount = actors_of_movie.Count() };
            foreach (var item in projected_movies)
                {
                    Console.WriteLine(item.Title, item.ActorsCount);
                }
                db.SaveChanges();
            }
        }
    }
}
