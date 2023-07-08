using System;

namespace Assignment3
{

    public class Task : ITask
    {

        public Task(string TaskId, uint TaskCompletionTime, List<string> TaskDependencies)
        {
            id = TaskId;
            completionTime = TaskCompletionTime;
            dependencies = TaskDependencies;
        }

        private string id;
        private uint completionTime;
        private List<string> dependencies;

        public string Id
        {
            get
            {
                return id;
            }
            private set
            {
                if (!IsValidId(value))
                    throw new ArgumentOutOfRangeException(nameof(Id));
                id = value;
            }
        }

        public uint CompletionTime
        {
            get
            {
                return completionTime;
            }
            set
            {
                if (!IsValidCompletionTime(value))
                    throw new ArgumentOutOfRangeException(nameof(CompletionTime));
                completionTime = value;
            }
        }

        public List<string> Dependencies
        {
            get
            {
                return dependencies;
            }
            set
            {
                if (!IsValidDependencies(value))
                    throw new ArgumentOutOfRangeException(nameof(Dependencies));
                dependencies = value;
            }
        }

        public static bool IsValidId(string id)
        {
            if (id.StartsWith("T"))
            {
                return true;
            }
            else
            {
                Console.WriteLine("Task of id {0} is invalid", id);
                return false;
            }
        }

        public static bool IsValidCompletionTime(uint completionTime)
        {
            if (completionTime > 0)
            {
                return true;
            }
            else
            {
                Console.WriteLine("Execution Time of {0} is invalid", completionTime);
                return false;
            }
        }

        public static bool IsValidDependencies(List<string> dependencies)
        {
            if (dependencies.Count == 0)
            {
                return true;
            }
            foreach (string task in dependencies)
            {
                if (task.GetType() != typeof(string) && task.StartsWith("T"))
                {
                    return false;
                }
            }
            return true;
        }

        public override string ToString()
        {
            if (dependencies.Count == 0)
            {
                return $"{id}, {completionTime}";
            }
            else
            {
                return $"{id}, {completionTime}, {string.Join(", ", dependencies)}";
            }
        }
    }
}