namespace Assignment3
{
    /// <summary>A class to represent the main menu, inherits from the generic menu.</summary>
    class MainMenu : GenericMenu
    {
        /// <summary>A constructor of the MainMenu class.</summary>
        public MainMenu()
        {
        }

        /// <summary>A method that displays the main menu in the console.</summary>
        /// <param name="taskMaster">A TaskCollection object.</param>
        public void Menu(TaskCollection taskMaster)
        {
            Console.WriteLine("Welcome to the Project Management System!");
            Console.WriteLine("-----------------------------------------");
            // Loop until the user chooses to exit
            while (true){
                const string READ = "1", ADD = "2", REMOVE = "3", CHANGE = "4", WRITE = "5", SEQUENCE = "6", EARLY = "7", EXIT = "8";
                Console.WriteLine(@"1. Enter Text File
2. Add A Job
3. Remove A Job
4. Change Completion Time
5. Save Job Information
6. Sequence Tasks
7. Earliest Times
8. Exit");
                Console.WriteLine("Please choose from the options above: ");
                string choice = Input();
                if (choice == READ)
                {
                    // Reads Task data from a file
                    taskMaster.DataRead();
                } 
                else if (choice == ADD)
                {
                    // Adds a Task to the collection
                    taskMaster.AddTask();
                }
                else if (choice == REMOVE)
                {
                    // Removes a Task from the collection
                    taskMaster.RemoveTask();
                }
                else if (choice == CHANGE)
                {
                    // Changes the completion time of a Task
                    taskMaster.ChangeTime();
                }
                else if (choice == WRITE)
                {
                    // Writes Task data to a file
                    taskMaster.DataWrite();
                }
                else if (choice == SEQUENCE)
                {
                    // Finds a sequence of Tasks that doesn't violate Task dependencies
                    taskMaster.Sequence();
                }
                else if (choice == EARLY)
                {
                    // Finds the earliest possible commencement time for each Task
                    taskMaster.EarliestTime();
                }
                else if (choice == "9")
                {
                    // Finds the earliest possible commencement time for each Task
                    taskMaster.CheckLoops();
                }
                else if (choice == "10")
                {
                    // Finds the earliest possible commencement time for each Task
                    taskMaster.CheckDependency();
                }
                else if (choice == EXIT)
                {
                    Console.WriteLine(@"+--------------------------------------------------------------+
| Good bye, thank you for using the Project Management System! |
+--------------------------------------------------------------+");
                    break;
                }
                else {
                    Console.WriteLine("Please enter a number from 1-8");
                }
            }
        }
    }
}