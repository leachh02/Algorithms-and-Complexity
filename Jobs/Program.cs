using System;

namespace Jobs
{
    class Program
    {
        static void Main(string[] args)
        {
            //TEST PLAN
            //JobTest();
            //JobCollectionTest();
            SchedulerTest();
        }
        public static void JobTest()
        {
            //Job ID Tests
            //TEST 01
            try
            {
                Job jobTest = new(0, 1, 1, 1);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }

            //TEST 02
            try
            {
                Job jobTest = new(1000, 1, 1, 1);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }

            //TEST 03
            try
            {
                Job jobTest = new(1, 1, 1, 1);
                Console.WriteLine(jobTest);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }

            //TEST 04
            try
            {
                Job jobTest = new(999, 1, 1, 1);
                Console.WriteLine(jobTest);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }

            //TEST 05
            try
            {
                Job jobTest = new(500, 1, 1, 1);
                Console.WriteLine(jobTest);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }



            //Job Time Received Tests
            //TEST 01
            try
            {
                Job jobTest = new(500, 0, 1, 1);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            //TEST 02
            try
            {
                Job jobTest = new(500, 1, 1, 1);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            //TEST 03
            try
            {
                Job jobTest = new(500, 500, 1, 1);
                Console.WriteLine(jobTest);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }



            //Job Execution Time Tests
            //TEST 01
            try
            {
                Job jobTest = new(500, 500, 0, 1);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            //TEST 02
            try
            {
                Job jobTest = new(500, 500, 1, 1);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            //TEST 03
            try
            {
                Job jobTest = new(500, 500, 500, 1);
                Console.WriteLine(jobTest);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }



            //Job Priority Tests
            //TEST 01
            try
            {
                Job jobTest = new(500, 500, 500,0);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }

            //TEST 02
            try
            {
                Job jobTest = new(500, 500, 500, 10);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }

            //TEST 03
            try
            {
                Job jobTest = new(500, 500, 500, 1);
                Console.WriteLine(jobTest);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }

            //TEST 04
            try
            {
                Job jobTest = new(500, 500, 500, 9);
                Console.WriteLine(jobTest);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }

            //TEST 05
            try
            {
                Job jobTest = new(500, 500, 500, 5);
                Console.WriteLine(jobTest);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void JobCollectionTest()
        {
            Job jobTest1 = new(1, 12, 32, 4);
            Job jobTest2 = new(2, 98, 2, 9);
            Job jobTest3 = new(3, 43, 12, 7);
            Job jobTest4 = new(4, 8, 20, 5);
            Job jobTest5 = new(5, 65, 35, 2);
            Job jobTest6 = new(6, 487, 4, 8);
            Job jobTest7 = new(1, 12, 20, 5);

            //Job Collection Capacity Tests
            //TEST 01
            try
            {
                JobCollection jobColl = new(0);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            //TEST 02
            try
            {
                JobCollection jobColl = new(1);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            //TEST 03
            try
            {
                JobCollection jobColl = new(5);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }



            //Job Collection Add Tests
            //TEST 01
            try
            {
                JobCollection jobColl = new(5);
                jobColl.Add(jobTest1);
                jobColl.Add(jobTest2);
                jobColl.Add(jobTest3);
                jobColl.Add(jobTest4);
                jobColl.Add(jobTest5);
                jobColl.Add(jobTest6);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            //TEST 02
            try
            {
                JobCollection jobColl = new(5);
                jobColl.Add(jobTest1);
                jobColl.Add(jobTest2);
                jobColl.Add(jobTest3);
                jobColl.Add(jobTest4);
                jobColl.Add(jobTest5);
                jobColl.Add(jobTest7);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            //TEST 03
            try
            {
                JobCollection jobColl = new(5);
                jobColl.Add(jobTest1);
                jobColl.Add(jobTest2);
                jobColl.Add(jobTest3);
                jobColl.Add(jobTest4);
                jobColl.Add(jobTest5);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }



            //Job Collection Contains Tests
            //TEST 01
            try
            {
                JobCollection jobColl = new(5);
                Console.WriteLine(jobColl.Contains(1));
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            //TEST 02
            try
            {
                JobCollection jobColl = new(5);
                Console.WriteLine(jobColl.Contains(0));
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            //TEST 03
            try
            {
                JobCollection jobColl = new(5);
                Console.WriteLine(jobColl.Contains(6));
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            //TEST 04
            try
            {
                JobCollection jobColl = new(5);
                jobColl.Add(jobTest1);
                Console.WriteLine(jobColl.Contains(1));
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }



            //Job Collection Find Tests
            //TEST 01
            try
            {
                JobCollection jobColl = new(5);
                Console.WriteLine(jobColl.Find(1));
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            //TEST 02
            try
            {
                JobCollection jobColl = new(5);
                Console.WriteLine(jobColl.Find(0));
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            //TEST 03
            try
            {
                JobCollection jobColl = new(5);
                Console.WriteLine(jobColl.Find(6));
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            //TEST 04
            try
            {
                JobCollection jobColl = new(5);
                jobColl.Add(jobTest1);
                Console.WriteLine(jobColl.Find(1));
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }


            //Job Collection Remove Tests
            //TEST 01
            try
            {
                JobCollection jobColl = new(5);
                jobColl.Add(jobTest1);
                jobColl.Add(jobTest2);
                jobColl.Add(jobTest3);
                jobColl.Add(jobTest4);
                jobColl.Add(jobTest5);
                jobColl.Remove(6);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            //TEST 02
            try
            {
                JobCollection jobColl = new(5);
                jobColl.Remove(0);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            //TEST 03
            try
            {
                JobCollection jobColl = new(5);
                jobColl.Add(jobTest1);
                jobColl.Add(jobTest2);
                jobColl.Add(jobTest3);
                jobColl.Add(jobTest4);
                jobColl.Add(jobTest5);
                jobColl.Remove(5);
                jobColl.Add(jobTest6);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }


            //Job Collection ToArray Tests
            //TEST 01
            try
            {
                JobCollection jobColl = new(5);
                IJob[] jobsArray = jobColl.ToArray();
                foreach (IJob job in jobsArray)
                {
                    Console.WriteLine(job);
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            //TEST 02
            try
            {
                JobCollection jobColl = new(5);
                jobColl.Add(jobTest1);
                jobColl.Add(jobTest2);
                jobColl.Add(jobTest3);
                jobColl.Add(jobTest4);
                jobColl.Add(jobTest5);
                IJob[] jobsArray = jobColl.ToArray();
                foreach (IJob job in jobsArray)
                {
                    Console.WriteLine(job);
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void SchedulerTest()
        {
            // Test Jobs
            Job jobTest1 = new(1, 12, 32, 4);
            Job jobTest2 = new(2, 98, 2, 9);
            Job jobTest3 = new(3, 43, 12, 7);
            Job jobTest4 = new(4, 8, 20, 5);
            Job jobTest5 = new(5, 65, 35, 2);
            Job jobTest6 = new(6, 487, 4, 8);
            Job jobTest7 = new(7, 12, 20, 5);
            Job jobTest8 = new(8, 81, 335, 3);
            Job jobTest9 = new(9, 47, 4423, 6);
            Job jobTest10 = new(10, 9032, 21, 1);

            //Scheduler with 0 Jobs
            JobCollection jobColl0 = new(1);
            Scheduler jobScheduler0 = new(jobColl0);

            //Scheduler with 1 Job
            JobCollection jobColl1 = new(1);          
            jobColl1.Add(jobTest1);
            Scheduler jobScheduler1 = new(jobColl1);

            //Scheduler with 2 Jobs
            JobCollection jobColl2 = new(2);
            jobColl2.Add(jobTest1);
            jobColl2.Add(jobTest2);
            Scheduler jobScheduler2 = new(jobColl2);

            //Scheduler with 10 Jobs
            JobCollection jobColl3 = new(10);
            jobColl3.Add(jobTest1);
            jobColl3.Add(jobTest2);
            jobColl3.Add(jobTest3);
            jobColl3.Add(jobTest4);
            jobColl3.Add(jobTest5);
            jobColl3.Add(jobTest6);
            jobColl3.Add(jobTest7);
            jobColl3.Add(jobTest8);
            jobColl3.Add(jobTest9);
            jobColl3.Add(jobTest10);
            Scheduler jobScheduler3 = new(jobColl3);


            //Job Scheduler First Come First Served Tests
            Console.WriteLine("First Come First Served Tests");
            //TEST 01
            try
            {
                Console.WriteLine("Scheduler: 0 Jobs");
                IJob[] jobsArray = jobScheduler0.FirstComeFirstServed();
                foreach (IJob job in jobsArray)
                {
                    Console.WriteLine(job);
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            //TEST 02
            try
            {
                Console.WriteLine("Scheduler: 1 Job");
                IJob[] jobsArray = jobScheduler1.FirstComeFirstServed();
                foreach (IJob job in jobsArray)
                {
                    Console.WriteLine(job);
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            //TEST 03
            try
            {
                Console.WriteLine("Scheduler: 2 Jobs");
                IJob[] jobsArray = jobScheduler2.FirstComeFirstServed();
                foreach (IJob job in jobsArray)
                {
                    Console.WriteLine(job);
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            //TEST 04
            try
            {
                Console.WriteLine("Scheduler: 10 Jobs");
                IJob[] jobsArray = jobScheduler3.FirstComeFirstServed();
                foreach (IJob job in jobsArray)
                {
                    Console.WriteLine(job);
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }


            //Job Scheduler Shortest Job First Tests
            Console.WriteLine("Shortest Job First Tests");
            //TEST 01
            try
            {
                Console.WriteLine("Scheduler: 0 Jobs");
                IJob[] jobsArray = jobScheduler0.ShortestJobFirst();
                foreach (IJob job in jobsArray)
                {
                    Console.WriteLine(job);
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            //TEST 02
            try
            {
                Console.WriteLine("Scheduler: 1 Job");
                IJob[] jobsArray = jobScheduler1.ShortestJobFirst();
                foreach (IJob job in jobsArray)
                {
                    Console.WriteLine(job);
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            //TEST 03
            try
            {
                Console.WriteLine("Scheduler: 2 Jobs");
                IJob[] jobsArray = jobScheduler2.ShortestJobFirst();
                foreach (IJob job in jobsArray)
                {
                    Console.WriteLine(job);
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            //TEST 04
            try
            {
                Console.WriteLine("Scheduler: 10 Jobs");
                IJob[] jobsArray = jobScheduler3.ShortestJobFirst();
                foreach (IJob job in jobsArray)
                {
                    Console.WriteLine(job);
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }



            //Job Scheduler Priority
            Console.WriteLine("Priority Tests");
            //TEST 01
            try
            {
                Console.WriteLine("Scheduler: 0 Jobs");
                IJob[] jobsArray = jobScheduler0.Priority();
                foreach (IJob job in jobsArray)
                {
                    Console.WriteLine(job);
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            //TEST 02
            try
            {
                Console.WriteLine("Scheduler: 1 Job");
                IJob[] jobsArray = jobScheduler1.Priority();
                foreach (IJob job in jobsArray)
                {
                    Console.WriteLine(job);
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            //TEST 03
            try
            {
                Console.WriteLine("Scheduler: 2 Jobs");
                IJob[] jobsArray = jobScheduler2.Priority();
                foreach (IJob job in jobsArray)
                {
                    Console.WriteLine(job);
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            //TEST 04
            try
            {
                Console.WriteLine("Scheduler: 10 Jobs");
                IJob[] jobsArray = jobScheduler3.Priority();
                foreach (IJob job in jobsArray)
                {
                    Console.WriteLine(job);
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}


