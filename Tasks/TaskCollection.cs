using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Reflection;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace Assignment3
{

    public class TaskCollection : ITaskCollection
    {
        private Dictionary<string, Task> Tasks;
        string filename = "tasks.txt";

        public TaskCollection()
        {
            Tasks = new Dictionary<string, Task>();
        }

        /// <summary>A method used as a means to improve the UI.</summary>
        /// <returns>The string input given from the user.</returns>
        static public string Input()
        {
            Console.Write("> ");
            string input = Console.ReadLine();
            return input;
        }

        /// <summary>Reads data FROM a file.</summary>
        public void DataRead()
        {
            Console.WriteLine("Please enter the name of the text file storing task information: ");
            filename = Input();
            try
            {// Creates the stream reader
                using StreamReader reader = new(filename);
                string data = reader.ReadToEnd();
                string[] taskData = data.Split("\n");
                int capacity = taskData.Length;
                foreach (string task in taskData)
                {
                    string[] taskInfo = task.Split(",");
                    int loopCount = taskInfo.Length;
                    if (taskInfo[0].StartsWith("T"))
                    {
                        // Adding Dependencies
                        List<string> tempDepends = new();
                        for (int i = 2; i < loopCount; i++)
                        {
                            tempDepends.Add(taskInfo[i].Trim());
                        }
                        Task tempTask = new(taskInfo[0], Convert.ToUInt32(taskInfo[1]), tempDepends);
                        Tasks.Add(taskInfo[0], tempTask);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Data was not successfully loaded!");
            }
        }

        /// <summary>Adds a Task TO the collection.</summary>
        public void AddTask()
        {
            Console.WriteLine("Please enter a new task: ");
            string newTask = Input();
            try
            {
                string[] taskInfo = newTask.Split(",");
                int loopCount = taskInfo.Length;
                if (taskInfo[0].StartsWith("T") && !(taskInfo[1] == null))
                {
                    // Adding Dependencies
                    List<string> tempDepends = new();
                    for (int i = 2; i < loopCount; i++)
                    {
                        tempDepends.Add(taskInfo[i].Trim());
                    }
                    Task tempTask = new(taskInfo[0], Convert.ToUInt32(taskInfo[1]), tempDepends);
                    Tasks.Add(taskInfo[0], tempTask);
                }
                else
                {
                    Console.WriteLine("Invalid task given! Follow the {ID, Completion Time, Dependencies (optional)} structure.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Task was not added!");
            }
        }

        /// <summary>Removes a Task FROM the collection.</summary>
        public void RemoveTask()
        {
            Console.WriteLine("Please enter a task to remove: ");
            string taskIdRemove = Input();
            try
            {
                Remove(taskIdRemove);
            }
            catch
            {
                Console.WriteLine("Task was not remove!");
            }
        }

        /// <summary>Removes a Task and checks all Tasks for dependencies.</summary>
        public void Remove(string taskIdRemove)
        {
            // Checks if this Task is dependent on the Task we're trying to remove
            foreach (Task task in Tasks.Values)
            {
                foreach (string dependency in task.Dependencies)
                {
                    if (dependency == taskIdRemove)
                    {
                        task.Dependencies.Remove(dependency);
                        break;
                    }
                }
            }
            Tasks.Remove(taskIdRemove);
        }

        /// <summary>Writes data TO a file.</summary>
        public void DataWrite()
        {
            // Creates the stream writer
            using StreamWriter writer = new(filename);
            // For every Task in the system, write the Task's information
            foreach (Task task in Tasks.Values)
            {
                writer.Write(task.ToString() + '\n');
            }
            Console.WriteLine("File has been updated!");
        }

        /// <summary>Updates the completion time of a Task.</summary>
        public void ChangeTime()
        {
            Console.WriteLine("Please enter a task to update: ");
            string taskUpdate = Input();
            Console.WriteLine("Please enter the new completion time for task, {0}: ", taskUpdate);
            string newCompTime = Input();
            try
            {
                Tasks[taskUpdate].CompletionTime = Convert.ToUInt32(newCompTime);
            }
            catch
            {
                Console.WriteLine("Task was not updated!");
            }
        }

        /// <summary>Finds a sequence of Tasks that doesn't violate Task dependencies.</summary>
        public void Sequence()
        {
            if (CheckDependency() && CheckLoops())
            {
                int tempCount = Tasks.Count;
                Dictionary<string, Task> tempTasks = new();
                foreach (Task task in Tasks.Values)
                {
                    List<string> tempDepends = new();
                    foreach (string dependency in task.Dependencies)
                    {
                        tempDepends.Add(dependency);
                    }
                    tempTasks.Add(task.Id, new Task(task.Id, task.CompletionTime, tempDepends));
                }
                string seqFile = "Sequence.txt";
                // Creates the stream writer
                using StreamWriter writer = new(seqFile);
                // For every Task in the system, check which Task has no dependencies, then remove this Task
                while (Tasks.Count != 0)
                {
                    foreach (Task task in Tasks.Values)
                    {
                        if (task.Dependencies.Count == 0)
                        {
                            if (Tasks.Count == tempCount)
                            {
                                writer.Write(task.Id);
                            }
                            else
                            {
                                writer.Write(", " + task.Id);
                            }
                            Remove(task.Id);
                            break;
                        }
                    }
                }
                //reverts changes
                Tasks = tempTasks;
                Console.WriteLine("Sequence has been created in {0}", seqFile);
            }
            else
            {
                Console.WriteLine("Please check that all dependencies exist and that no jobs create an unexpected loop!");
            }
        }

        /// <summary>Finds the earliest possible commencement time for each Task.</summary>
        public void EarliestTime()
        {
            if (CheckDependency() && CheckLoops())
            {
                string earlTimeFile = "EarliestTime.txt";
                // Creates the stream writer
                using StreamWriter writer = new(earlTimeFile);
                foreach (Task task in Tasks.Values)
                {
                    uint time = EarlTimeRec(task);
                    writer.Write(task.Id + ", " + time + "\n");
                }
                Console.WriteLine("Earliest Times of tasks have been recorded in {0}", earlTimeFile);
            }
            else
            {
                Console.WriteLine("Please check that all dependencies exist and that no jobs create an unexpected loop!");
            }   
        }

        /// <summary>Recursively finds the earliest possible time for a Task to be executed.</summary>
        public uint EarlTimeRec(Task earlTimeTask)
        {
            uint time = 0;
            if (earlTimeTask.Dependencies.Count == 0)
            {
                return time;
            }
            else
            {
                uint maxDependTime = 0;
                foreach (string dependency in earlTimeTask.Dependencies)
                {
                    foreach (Task task in Tasks.Values)
                    {
                        if (task.Id == dependency)
                        {
                            uint dependTime = EarlTimeRec(task) + task.CompletionTime;
                            if (dependTime > maxDependTime) { maxDependTime = dependTime; }
                        }
                    }
                }
                return maxDependTime;
            }
        }

        public bool CheckDependency()
        {
            List<string> dependenciesCheck = new();
            foreach (Task task in Tasks.Values)
            {
                foreach (string dependency in task.Dependencies)
                {
                    dependenciesCheck.Add(dependency);
                }
            }
            List<string> unique = dependenciesCheck.Distinct().ToList();

            //checks through all dependencies to confirm the task existsh
            int dependsCount = 0;
            foreach (string dependency in unique)
            {
                bool idCheck = false;
                foreach (string id in Tasks.Keys)
                {
                    if (dependency == id)
                    {
                        idCheck = true;
                        break;
                    }
                }
                if (idCheck)
                {
                    dependsCount++;
                }
            }
            if (dependsCount == unique.Count)
            {
                return true;
            }
            return false;
        }

        public bool CheckLoops()
        {
            // Uses Kahn's Algorithm to confirm if loops are present

            // Defining the array to store indegrees.
            int[] deg = new int[Tasks.Count];

            uint[,] G = CreateGraph();
            uint INF = 999999;
            // Computing indegree of each vertex using.
            //cols
            for (int m = 0; m < Tasks.Count; m++)
            {
                int indegreeCount = 0;
                //rows
                for (int n = 0; n < Tasks.Count; n++)
                {
                    if (G[n, m] != INF)
                    {
                        indegreeCount++;
                    }
                }
                deg[m] = indegreeCount;
            }

            // Queue to store vertices 
            // with  having 0 indegree.
            Queue<int> q = new Queue<int>();

            // Iterate from i = 0 To i 
            // = V - 1 and find vertices 
            // having indegree as 0.
            for (int m = 0; m < Tasks.Count; m++)
            {
                if (deg[m] == 0)
                {
                    q.Enqueue(m);
                }
            }

            // Defining the counter.
            int counter = 0;

            // Iterating while the queue is 
            // not empty.
            while (q.Count != 0) {
                // Dequeue from 'q'.
                int u = q.Dequeue();

                // Increase the counter.
                counter++;

                // Iterate for all neighours 
                // of vertex 'u'.
                for (int v = 0; v < Tasks.Count; v++)
                {
                    if (G[u, v] != INF)
                    {
                        // Decrease the indegree.
                        deg[v]--;
                        // If deg[v] is 0, insert
                        // it the q.
                        if (deg[v] == 0)
                        {
                            q.Enqueue(v);
                        }
                    }
                }
            }
            // Returning true if counter != V.
            return counter == Tasks.Count;
        }

        public uint[,] CreateGraph()
        {
            uint[,] graph = new uint[Tasks.Count, Tasks.Count];
            uint INF = 999999;
            int i = 0;
            int j = 0;
            foreach (Task rows in Tasks.Values)
            {
                foreach (Task cols in Tasks.Values)
                {
                    graph[i,j] = INF;
                    foreach (string depends in cols.Dependencies)
                    {
                        if (depends == rows.Id)
                        {
                            graph[i, j] = rows.CompletionTime;
                        }
                    }
                    j++;
                }
                j = 0;
                i++;
            }
            return graph;
        }
    }
}