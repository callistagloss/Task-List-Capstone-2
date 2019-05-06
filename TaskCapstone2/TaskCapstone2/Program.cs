using System;
using System.Collections.Generic;

namespace Capstone2_TaskList
{
    class Program1
    {
        public static List<Task> tasks = new List<Task>();
        static void Main(string[] args)
        {

            Console.WriteLine("Welcome to the Task Manager!");

            Continue();
        }

        public static void Menu()
        {
            Console.WriteLine();
            Console.WriteLine("  1. List tasks");
            Console.WriteLine("  2. Add task");
            Console.WriteLine("  3. Delete task");
            Console.WriteLine("  4. Mark task complete");
            Console.WriteLine("  5. Quit");
            Console.WriteLine();
            Console.WriteLine($"You currently have {tasks.Count} task{(tasks.Count == 1 ? "" : "s")} in your tasks list.");
        }

        public static void Continue()
        {
            bool run = true;
            while (run)
            {
                Menu();

                Console.WriteLine();
                Console.Write("Please select a number between 1 to 5.\n ");
                string input = Console.ReadLine();

                if (input == "1")
                {
                    ListTasks();
                }
                else if (input == "2")
                {
                    AddTask();
                }
                else if (input == "3")
                {
                    DeleteTask();
                }
                else if (input == "4")
                {
                    CompleteTask();
                }
                else if (input == "5")
                {
                    run = false;
                }
                else
                {
                    Console.WriteLine("I'm sorry. I didn't understand your input. Please try again.");
                    Console.WriteLine();
   
                }

            }

        }


        public static void ListTasks()
        {

            if (tasks.Count > 0 && tasks.Count < 6)
            {
                Console.WriteLine("Tasks:");
                Console.WriteLine();
            }

                foreach (Task item in tasks)
                {
                    Console.WriteLine($"  {item.TaskName} - {(item.TaskCompleted ? "Done " : "To do")}"); }
                }
                

        public static void AddTask()
        {
            Console.WriteLine();
            Console.Write("What task would you like to add? ");

            Task t = new Task(Console.ReadLine());
            tasks.Add(t);

            Console.WriteLine();
            Console.WriteLine("You added a new task.");
            Console.WriteLine();
        }

            public static void DeleteTask()
            {
            int taskNumber = 0;

            if (tasks.Count == 0)
            {
                Console.WriteLine("You do not have any tasks to delete.");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Here is your tasks list:");
                Console.WriteLine();

                for (int i = 0; i < tasks.Count; i++)
                {
                    Console.WriteLine($"  {i + 1}) {tasks[i].TaskName} - {(tasks[i].TaskCompleted ? "Done " : "To do")}");
                }
                Console.WriteLine($"  {tasks.Count + 1}) Return to main menu");
                Console.WriteLine();


                bool run = true;
                while (run)
                {
                    Console.Write("Which task would you like to delete? ");
                    Console.WriteLine();

                    string input = Console.ReadLine();
                    try
                    {
                        taskNumber = Convert.ToInt32(input);
                        if (taskNumber < 1 || taskNumber > tasks.Count + 1)
                        {
                            throw new Exception();
                        }
                        else if (taskNumber == tasks.Count + 1)
                        {
                            Console.Clear();
                            break;
                        }
                        else
                        {
                            run = false;
                            tasks.RemoveAt(taskNumber - 1);
                            Console.WriteLine();
                        }
                    }
                    catch (Exception)
                    {
                        Console.WriteLine();
                        Console.WriteLine("I'm sorry. I didn't understand your input. Please try again.");
                    }

                }

            }

        }



        public static void CompleteTask()
        {
            int taskNumber = 0;
            Console.Clear();

            if (tasks.Count == 0)
            {
                Console.WriteLine("You haven't added any tasks yet.");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Here is your tasks list:");
                Console.WriteLine();

                for (int i = 0; i < tasks.Count; i++)
                {
                    Console.WriteLine($"  {i + 1}) {tasks[i].TaskName} - {(tasks[i].TaskCompleted ? "COMPLETED" : "To Do")}");
                }
                Console.WriteLine($"  {tasks.Count + 1}) Return to main menu");

                bool run = true;
                while (run)
                {
                    Console.WriteLine();
                    Console.Write("Which task would you like to mark as complete? ");

                    string input = Console.ReadLine();
                    try
                    {
                        taskNumber = Convert.ToInt32(input);
                        if (taskNumber < 1 || taskNumber > tasks.Count + 1)
                        {
                            throw new Exception();
                        }
                        else if (taskNumber == tasks.Count + 1)
                        {
                            Console.Clear();
                            break;
                        }
                        else if (tasks[taskNumber - 1].TaskCompleted == true)
                        {
                            throw new Exception();
                        }
                        else
                        {
                            run = false;
                        }
                    }
                    catch (Exception)
                    {
                        Console.WriteLine();
                        Console.WriteLine("I'm sorry. I didn't understand your input. Please try again.");
                    }

                    Console.WriteLine("Task marked completed.");
                    Console.WriteLine();

                    tasks[taskNumber - 1].TaskCompleted = true;
                }

            }

        }

    }

}