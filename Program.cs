using System;
using System.Collections.Generic;
using System.IO;

namespace todoconsoleapp
{
    /// <summary>
    /// The main class for the Todo Console App.
    /// </summary>
    class Program
    {
        /// <summary>
        /// The list of tasks.
        /// </summary>
        static List<string> tasks = new List<string>();

        /// <summary>
        /// The entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            LoadTasks();
            while (true)
            {
                Console.WriteLine("1. Add Task");
                Console.WriteLine("2. Remove Task");
                Console.WriteLine("3. View Tasks");
                Console.WriteLine("4. Exit");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddTask();
                        break;
                    case "2":
                        RemoveTask();
                        break;
                    case "3":
                        ViewTasks();
                        break;
                    case "4":
                        SaveTasks();
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }
            }
        }

        /// <summary>
        /// Adds a task to the list.
        /// </summary>
        static void AddTask()
        {
            Console.Write("Enter task: ");
            var task = Console.ReadLine();
            tasks.Add(task);
            Console.WriteLine("Task added!");
        }

        /// <summary>
        /// Removes a task from the list.
        /// </summary>
        static void RemoveTask()
        {
            ViewTasks();
            Console.Write("Enter task number to remove: ");
            if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= tasks.Count)
            {
                tasks.RemoveAt(index - 1);
                Console.WriteLine("Task removed!");
            }
            else
            {
                Console.WriteLine("Invalid task number.");
            }
        }

        /// <summary>
        /// Displays the list of tasks.
        /// </summary>
        static void ViewTasks()
        {
            if (tasks.Count == 0)
            {
                Console.WriteLine("No tasks available.");
                return;
            }

            for (int i = 0; i < tasks.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {tasks[i]}");
            }
        }

        /// <summary>
        /// Loads the tasks from the file.
        /// </summary>
        static void LoadTasks()
        {
            if (File.Exists("tasks.txt"))
            {
                tasks.AddRange(File.ReadAllLines("tasks.txt"));
            }
        }

        /// <summary>
        /// Saves the tasks to the file.
        /// </summary>
        static void SaveTasks()
        {
            File.WriteAllLines("tasks.txt", tasks);
        }
    }
}
