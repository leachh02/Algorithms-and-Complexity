using System;
using System.Drawing;
using System.Linq.Expressions;
using System.Text;

namespace Movies
{
    class Program
    {
        static void Main(string[] args)
        {
            //MovieTest();
            MovieCollectionTest();

            // Count Analysis
            //int noOfRuns = 1;
            //for (int size = 100000; size <= 1000000; size += 100000)
            //{
            //    long totalCounts = 0;
            //    for (int i = 1; i <= noOfRuns; i++)
            //    {
            //        InsertRandomMovies(movieColl1, size);
            //        int count = movieColl1.NoDVDs();
            //        totalCounts += count;
            //        movieColl1.Clear();
            //    }
            //    double averageCount = totalCounts * 1.0 / noOfRuns;
            //    Console.WriteLine("Size = " + size + "; Average Count = " + averageCount);
            //}

            //Time Analysis
            //int noOfRuns = 5;
            //for (int size = 100000; size <= 1000000; size += 100000)
            //{
            //    double totalTime = 0;
            //    for (int i = 1; i <= noOfRuns; i++)
            //    {
            //        InsertRandomMovies(movieColl1, size);
            //        long then = DateTime.Now.Ticks;
            //        movieColl1.NoDVDs();
            //        long now = DateTime.Now.Ticks;
            //        TimeSpan elapsedSpan = new TimeSpan(now - then);
            //        double time = elapsedSpan.TotalSeconds;
            //        totalTime += time;
            //        movieColl1.Clear();
            //    }
            //    double averageTime = totalTime * 1.0 / noOfRuns;
            //    Console.WriteLine("Size = " + size + "; Average Time = " + averageTime + " seconds");
            //}
        }

        ///<summary>
        /// insert random movies into a movie collection a random array
        /// </summary>
        /// <param name="movieColl">the movie collection</param>
        /// <param name="size">the number of times a movie will be inserted into the movie collection</param>
        static public void InsertRandomMovies(MovieCollection movieColl, int size)
        {
            int seed = (int)DateTime.Now.Ticks;
            Random rnd = new Random(seed);

            for (int i = 0; i < size; i++)
            {
                string title = RandomString();
                int genreInt = rnd.Next(1, 6);
                var genre = genreInt switch
                {
                    1 => MovieGenre.Action,
                    2 => MovieGenre.Comedy,
                    3 => MovieGenre.History,
                    4 => MovieGenre.Drama,
                    _ => MovieGenre.Western,
                };
                int classInt = rnd.Next(1, 5);
                var claassification = classInt switch
                {
                    1 => MovieClassification.G,
                    2 => MovieClassification.PG,
                    3 => MovieClassification.M,
                    _ => MovieClassification.M15Plus,
                };
                
                int duration = rnd.Next(90, 120);
                int copies = rnd.Next(1, 13);
                Movie movieTBA = new(title, genre, claassification, duration, copies);
                movieColl.Insert(movieTBA);
            }
        }
        // Generates a random string of length 10.
        static string RandomString()
        {
            string str = "";
            int seed = (int)DateTime.Now.Ticks;
            Random rnd = new Random(seed);
            for (var i = 0; i < 10; i++)
            {
                char letter = (char)rnd.Next('A', 'Z');
                str += letter;
            }
            return str;
        }

        public static void MovieTest()
        {
            Console.WriteLine("Movie Class Tests");

            //Movie ToString Tests
            Console.WriteLine();
            Console.WriteLine("Movie ToString() Tests");

            //TEST 01
            Console.WriteLine("Test 01:");
            Movie movie1 = new("Back to the Future", MovieGenre.Action, MovieClassification.M, 116, 8);
            Console.WriteLine(movie1.ToString());

            //TEST 02
            Console.WriteLine("Test 02:");
            try
            {
                Movie movie2 = null;
                Console.WriteLine(movie2.ToString());
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine(ex.Message);
            }

            //Movie CompareTo Tests
            Console.WriteLine();
            Console.WriteLine("Movie CompareTo() Tests");

            //TEST 01
            Console.WriteLine("Test 01:");
            Movie movie3 = new("Shrek", MovieGenre.Comedy, MovieClassification.G, 90, 7);
            Movie movie4 = new("Avatar", MovieGenre.Action, MovieClassification.M, 161, 4);
            Console.WriteLine(movie3.CompareTo(movie4));

            //TEST 02
            Console.WriteLine("Test 02:");
            Movie movie5 = new("2001: A Space Odyssey", MovieGenre.Action, MovieClassification.M, 143, 6);
            Movie movie6 = new("The Godfather", MovieGenre.Action, MovieClassification.M, 175, 2);
            Console.WriteLine(movie5.CompareTo(movie6));

            //TEST 03
            Console.WriteLine("Test 03:");
            Movie movie7 = new("Star Wars", MovieGenre.Action, MovieClassification.M, 121, 10);
            Console.WriteLine(movie7.CompareTo(movie7));

            //TEST 04
            Console.WriteLine("Test 04:");
            try
            {
                Movie movie8 = new("Citizen Kane", MovieGenre.Drama, MovieClassification.M, 119, 3);
                Console.WriteLine(movie8.CompareTo(null));
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public static void MovieCollectionTest()
        {
            
            Console.WriteLine("Movie Collection Class Tests");

            //Movie Collection IsEmpty Tests
            Console.WriteLine();
            Console.WriteLine("Movie Collection IsEmpty() Tests");

            //TEST 01
            Console.WriteLine("Test 01:");
            MovieCollection movieColl1 = new();
            Console.WriteLine(movieColl1.IsEmpty());

            //TEST 02
            Console.WriteLine("Test 02:");
            MovieCollection movieColl2 = new();
            Movie movie9 = new("Raiders of the Lost Ark", MovieGenre.Action, MovieClassification.M, 115, 12);
            movieColl2.Insert(movie9);
            Console.WriteLine(movieColl2.IsEmpty());

            //TEST 03
            Console.WriteLine("Test 03:");
            MovieCollection movieColl3 = new();
            Movie movie10 = new("Seven Samurai", MovieGenre.Action, MovieClassification.M, 207, 1);
            Movie movie11 = new("In The Mood For Love", MovieGenre.Drama, MovieClassification.M, 98, 2);
            movieColl3.Insert(movie10);
            movieColl3.Insert(movie11);
            Console.WriteLine(movieColl3.IsEmpty());

            //TEST 04
            Console.WriteLine("Test 04:");
            try
            {
                MovieCollection movieColl4 = null;
                Console.WriteLine(movieColl4.IsEmpty());
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine(ex.Message);
            }

            //TEST 05
            Console.WriteLine("Test 05:");
            MovieCollection movieColl5 = new();
            movieColl5.Insert(null);
            Console.WriteLine(movieColl5.IsEmpty());

            //Movie Collection Insert Tests
            Console.WriteLine();
            Console.WriteLine("Movie Collection Insert() Tests");

            //TEST 01
            Console.WriteLine("Test 01:");
            MovieCollection movieColl6 = new();
            Movie movie12 = new("There Will Be Blood", MovieGenre.Action, MovieClassification.M15Plus, 158, 3);
            Console.WriteLine(movieColl6.Insert(movie12));

            //TEST 02
            Console.WriteLine("Test 02:");
            MovieCollection movieColl7 = new();
            Movie movie13 = new("Signin' In The Rain", MovieGenre.Comedy, MovieClassification.PG, 103, 2);
            Movie movie14 = new("Goodfellas", MovieGenre.Action, MovieClassification.M15Plus, 146, 5);
            Console.WriteLine(movieColl7.Insert(movie13));
            Console.WriteLine(movieColl7.Insert(movie14));

            //TEST 03
            Console.WriteLine("Test 03:");
            MovieCollection movieColl8 = new();
            Movie movie15 = new("The Dark Knight", MovieGenre.Action, MovieClassification.M, 140, 10);
            Console.WriteLine(movieColl8.Insert(movie15));
            Console.WriteLine(movieColl8.Insert(movie15));

            //TEST 04
            Console.WriteLine("Test 04:");
            MovieCollection movieColl9 = new();
            Console.WriteLine(movieColl9.Insert(null));
            
            //TEST 05
            Console.WriteLine("Test 05:");
            try
            {
                MovieCollection movieColl10 = new();
                Console.WriteLine(movieColl10.Insert(null));
                Console.WriteLine(movieColl10.Insert(null));
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine(ex.Message);
            }

            //Movie Collection Delete Tests
            Console.WriteLine();
            Console.WriteLine("Movie Collection Delete() Tests");

            //TEST 01
            Console.WriteLine("Test 01:");
            MovieCollection movieColl11 = new();
            Movie movie16 = new("Vertigo", MovieGenre.Drama, MovieClassification.PG, 128, 6);
            movieColl11.Insert(movie16);
            Console.WriteLine(movieColl11.Delete(movie16));

            //TEST 02
            Console.WriteLine("Test 02:");
            MovieCollection movieColl12 = new();
            Movie movie17 = new("Jaws", MovieGenre.Action, MovieClassification.M, 124, 8);
            Console.WriteLine(movieColl12.Delete(movie17));

            //TEST 03
            Console.WriteLine("Test 03:");
            MovieCollection movieColl13 = new();
            Movie movie18 = new("Alien", MovieGenre.Action, MovieClassification.M, 117, 4);
            Movie movie19 = new("Pulp Fiction", MovieGenre.Action, MovieClassification.M15Plus, 165, 5);
            Movie movie20 = new("The Truman Show", MovieGenre.Comedy, MovieClassification.PG, 107, 3);
            movieColl13.Insert(movie18);
            movieColl13.Insert(movie19);
            movieColl13.Insert(movie20);
            Console.WriteLine(movieColl13.Delete(movie18));
            Console.WriteLine(movieColl13.Delete(movie19));
            Console.WriteLine(movieColl13.Delete(movie20));

            //TEST 04
            Console.WriteLine("Test 04:");
            MovieCollection movieColl14 = new();
            Console.WriteLine(movieColl14.Delete(null));

            //Movie Collection Search Tests
            Console.WriteLine();
            Console.WriteLine("Movie Collection Search() Tests");

            //TEST 01
            Console.WriteLine("Test 01:");
            MovieCollection movieColl15 = new();
            Movie movie21 = new("Lost In Translation", MovieGenre.Drama, MovieClassification.M, 101, 2);
            movieColl15.Insert(movie21);
            Console.WriteLine(movieColl15.Search("Lost In Translation"));
            
            //TEST 02
            Console.WriteLine("Test 02:");
            MovieCollection movieColl16 = new();
            Console.WriteLine(movieColl16.Search("Psycho"));

            //TEST 03
            Console.WriteLine("Test 03:");
            MovieCollection movieColl17 = new();
            Console.WriteLine(movieColl17.Search(null));

            //Movie Collection NoDVDs Tests
            Console.WriteLine();
            Console.WriteLine("Movie Collection NoDVDs() Tests");

            //TEST 01
            Console.WriteLine("Test 01:");
            MovieCollection movieColl18 = new();
            Console.WriteLine(movieColl18.NoDVDs());

            //TEST 02
            Console.WriteLine("Test 02:");
            MovieCollection movieColl19 = new(); 
            Movie movie22 = new("Taxi Driver", MovieGenre.Action, MovieClassification.M, 114, 7);
            movieColl19.Insert(movie22);
            Console.WriteLine(movieColl19.NoDVDs());

            //TEST 03
            Console.WriteLine("Test 03:");
            MovieCollection movieColl20 = new();
            Movie movie23 = new("Spirited Away", MovieGenre.Comedy, MovieClassification.PG, 140, 8);
            Movie movie24 = new("Night Of The Living Dead", MovieGenre.Action, MovieClassification.M, 96, 14);
            Movie movie25 = new("Blade Runner", MovieGenre.Drama, MovieClassification.M, 117, 4);
            movieColl20.Insert(movie23);
            movieColl20.Insert(movie24);
            movieColl20.Insert(movie25);
            Console.WriteLine(movieColl20.NoDVDs());

            //Movie Collection ToArray Tests
            Console.WriteLine();
            Console.WriteLine("Movie Collection ToArray() Tests");

            //TEST 01
            Console.WriteLine("Test 01:");
            MovieCollection movieColl21 = new();
            IMovie[] movieList1;
            movieList1 = movieColl21.ToArray();
            foreach (IMovie movie in movieList1)
            {
                Console.WriteLine(movie);
            }

            //TEST 02
            Console.WriteLine("Test 02:");
            MovieCollection movieColl22 = new();
            Movie movie26 = new("Nosferatu", MovieGenre.Action, MovieClassification.M, 94, 1);
            movieColl22.Insert(movie26);
            IMovie[] movieList2;
            movieList2 = movieColl22.ToArray();
            foreach (IMovie movie in movieList2)
            {
                Console.WriteLine(movie);
            }

            //TEST 03
            Console.WriteLine("Test 03:");
            MovieCollection movieColl23 = new();
            Movie movie27 = new("The Lord of the Rings", MovieGenre.Action, MovieClassification.M, 178, 7);
            Movie movie28 = new("Forrest Gump", MovieGenre.Comedy, MovieClassification.M, 142, 6);
            Movie movie29 = new("The Shawshank Redemption", MovieGenre.Drama, MovieClassification.M, 142, 3);
            movieColl23.Insert(movie27);
            movieColl23.Insert(movie28);
            movieColl23.Insert(movie29);
            IMovie[] movieList3;
            movieList3 = movieColl23.ToArray();
            foreach (IMovie movie in movieList3)
            {
                Console.WriteLine(movie);
            }

            //TEST 04
            Console.WriteLine("Test 04:");
            try
            {
                MovieCollection movieColl24 = null;
                IMovie[] movieList4;
                movieList4 = movieColl24.ToArray();
                foreach (IMovie movie in movieList4)
                {
                    Console.WriteLine(movie);
                }
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine(ex.Message);
            }

            //TEST 05
            Console.WriteLine("Test 05:");
            try
            {
                MovieCollection movieColl25 = new();
                movieColl23.Insert(null);
                IMovie[] movieList5;
                movieList5 = movieColl25.ToArray();
                foreach (IMovie movie in movieList5)
                {
                    Console.WriteLine(movie);
                }
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine(ex.Message);
            }

            //Movie Collection Clear Tests
            Console.WriteLine();
            Console.WriteLine("Movie Collection Clear() Tests");

            //TEST 01
            Console.WriteLine("Test 01:");
            MovieCollection movieColl26 = new();
            Console.WriteLine(movieColl26.IsEmpty());
            movieColl26.Clear();
            Console.WriteLine(movieColl26.IsEmpty());

            //TEST 02
            Console.WriteLine("Test 02:");
            MovieCollection movieColl27 = new();
            Movie movie30 = new("Braveheart", MovieGenre.History, MovieClassification.M, 177, 3);
            movieColl27.Insert(movie30);
            Console.WriteLine(movieColl27.IsEmpty());
            movieColl27.Clear();
            Console.WriteLine(movieColl27.IsEmpty());

            //TEST 03
            Console.WriteLine("Test 03:");
            MovieCollection movieColl28 = new();
            Movie movie31 = new("The Matrix", MovieGenre.Action, MovieClassification.M, 136, 4);
            Movie movie32 = new("Schindler's List", MovieGenre.History, MovieClassification.M, 195, 2);
            Movie movie33 = new("Inception", MovieGenre.Action, MovieClassification.M, 148, 5);
            movieColl28.Insert(movie31);
            movieColl28.Insert(movie32);
            movieColl28.Insert(movie33);
            Console.WriteLine(movieColl28.IsEmpty());
            movieColl28.Clear();
            Console.WriteLine(movieColl28.IsEmpty());
        }
    }
}


