using System.Threading.Tasks;

namespace Assignment3
{
    /// <summary>
    /// This ADT represents a collection of Tasks.
    /// </summary>

    public interface ITaskCollection
    {

        /// <summary>
        /// Reads data FROM a file.
        /// </summary>
        public void DataRead();

        /// <summary>
        /// Adds a Task TO the collection.
        /// </summary>
        public void AddTask();

        /// <summary>
        /// Removes a Task FROM the collection.
        /// </summary>
        public void RemoveTask();

        /// <summary>
        /// Removes a Task and checks all Tasks for dependencies.
        /// </summary>
        public void Remove(string taskIdRemove);

        /// <summary>
        /// Writes data TO a file.
        /// </summary>
        public void DataWrite();

        /// <summary>
        /// Updates the completion time of a Task.
        /// </summary>
        public void ChangeTime();

        /// <summary>
        /// Finds a sequence of Tasks that doesn't violate Task dependencies.
        /// </summary>
        public void Sequence();

        /// <summary>
        /// Finds the earliest possible commencement time for each Task.
        /// </summary>
        public void EarliestTime();

        /// <summary>
        /// Recursively finds the earliest possible time for a Task to be executed.
        /// </summary>
        public uint EarlTimeRec(Task earlTimeTask);

    }
}