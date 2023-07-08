namespace Assignment3
{
    /// <summary>
    /// This ADT represents a Task
    /// </summary>

    public interface ITask
    {

        /// <summary>
        /// Get the id of this Task.
        /// </summary>
        public string Id { get; }

        /// <summary>
        /// Get the time to complete this Task.
        /// </summary>
        public uint CompletionTime { get; set; }

        /// <summary>
        /// Get all the dependencies of this Task.
        /// </summary>
        public List<string> Dependencies { get; set; }

        /// <summary>
        /// Determines whether a supplied Task id is valid.
        /// 
        /// Pre: nil
        /// 
        /// Post: returns true if the id starts with a 'T'; return false, otherwise.
        /// 
        /// Interpretation: In all circumstances, the method returns true if the supplied
        /// Task id begins with a T; return false otherwise.
        /// </summary>
        public static bool IsValidId(string id)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Determines whether a supplied Task completion time is valid.
        /// 
        /// Pre: nil
        /// 
        /// Post: returns true if completionTime > 0; return false, otherwise.
        /// 
        /// Interpretation: In all circumstances, the method returns true if the supplied
        /// execution time is greater than 0; return false otherwise.
        /// </summary>
        public static bool IsValidCompletionTime(uint completionTime)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Determines whether the supplied dependencies of a Task are valid.
        /// 
        /// Pre: nil
        /// 
        /// Post: returns true if all dependencies are of type string > 0; return false, otherwise.
        /// 
        /// Interpretation: In all circumstances, the method returns true if the supplied
        /// dependencies are of type string; return false otherwise.
        /// </summary>
        public static bool IsValidDependencies(List<string> dependencies)
        {
            throw new System.NotImplementedException();
        }
    }
}