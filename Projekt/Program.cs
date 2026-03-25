namespace  Projekt;

using Projekt.Models;
using Projekt.Models.Users;
using Projekt.Models.Devices;
using Projekt.Infrastructure;

public class Program
{
    // Repozytoria
    static Repository<User> Users;
    static Repository<Due> Dues;
    static Repository<Equipment> Equipments;
    static Repository<Lease> Leases;
    
    // bool podtrzymujący program przy życiu
    static bool isRunning = true;
    
    static void Main(String[] args)
    {
        LoadDatabase();
        
        StartProgram();
    }

    private static void StartProgram()
    {
        Console.WriteLine("Program Started");
        while (isRunning)
        {
            Console.Write("> ");
            string input = Console.ReadLine();
            
            string[] inputArgs = input.Split(' ');
            string command = inputArgs[0];
            int args =  inputArgs.Length - 1;

            switch (command)
            {
                case "exit":
                    isRunning = false;
                    break;
                case "help":
                    HelpCommand();
                    break;
                case "list" or "ls":
                    ListCommand(inputArgs, args);
                    break;
                case "add":
                    AddCommand(inputArgs, args);
                    break;
                case "remove" or "rm":
                    if (args > 1)
                    {
                        
                    }
                    else
                    {
                        
                    }
                    
                    break;
                case "lease":
                    LeaseCommand(inputArgs, args);
                    break;
                case "report" or "rp":
                    ReportCommand();
                    break;
                default:
                    Console.WriteLine($"'{input}' is not recognized as an available command");
                    break;
                    
            }
        }
    }
    
    // Ładowanie bazy danych
    private static void LoadDatabase()
    {
        string basePath = AppDomain.CurrentDomain.BaseDirectory;
        
        Users = new Repository<User>(GetPath("users.json"));
        Dues = new Repository<Due>(GetPath("dues.json"));
        Equipments = new Repository<Equipment>(GetPath("equipments.json"));
        Leases = new Repository<Lease>(GetPath("leases.json"));
        
        Console.WriteLine("Database Loaded");
    }
    
    // Wyświetlanie całej listy (Trzeba dodać do każdej głównej klasy ovveride na String)
    public static void PrintList<T>(List<T> list)
    {
        foreach (T item in list)
        {
            Console.WriteLine(item);
        }
    }
    
    // Pobieranie ścieżki
    private static string GetPath(string file)
    {
        return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, file);
    }
    
    
    
    
    
    // Komendy
    
    public static void HelpCommand()
    {
        Console.WriteLine("Available commands:\n\n" +
                          "help - Shows available commands.\n\n" +
                          "add - Adds the type you want to the database\n" +
                          "Types: user, lease, equipment, due\n\n" +
                          "remove - Removes the type you want from the database (short form: rm)\n" +
                          "Types: user, lease, equipment, due\n\n" +
                          "list - Makes a list of objects currently in the database. (short form: ls)\n" +
                          "Example: list users\n" +
                          "You can choose from: equipment, lease, due, user, all\n\n" +
                          "repot - Makes a simple report (short form: rp)\n\n");
    }

    public static void ListCommand(string[] inputArgs,int args)
    {
        if (args >= 1)
        {
            if (inputArgs[1] == "equipment")
            {
                if (inputArgs.Length > 2 && inputArgs[2] == "availible")
                {
                    Console.WriteLine("Available Equipments: ");
                    PrintList(Equipments.GetList().Where(e => e.Availibility).ToList());
                }
                else
                {
                    Console.WriteLine("Equipments: ");
                    PrintList(Equipments.GetList().ToList());
                }
            }else if (inputArgs[1] == "lease")
            {
                Console.WriteLine("Leases: ");
                PrintList(Users.GetList().ToList());    
            }else if (inputArgs[1] == "due")
            {
                Console.WriteLine("Dues: ");
                PrintList(Dues.GetList().ToList());
            }else if (inputArgs[1] == "user")
            {
                Console.WriteLine("Users: ");
                PrintList(Users.GetList().ToList());
            }else if (inputArgs[1] == "all")
            {
                Console.WriteLine("Users: ");
                PrintList(Users.GetList().ToList());
                Console.WriteLine("Equipments: ");
                PrintList(Equipments.GetList().ToList());
                Console.WriteLine("Leases: ");
                PrintList(Leases.GetList().ToList());
                Console.WriteLine("Dues: ");
                PrintList(Dues.GetList().ToList());
            }
            else
            {
                Console.WriteLine("Proper use of the command: list <nameTolist>");
                Console.WriteLine("Names to list: equipments, leases, dues, users, all");
            }
        }
        else
        {
            Console.WriteLine("Proper use of the command: list <nameTolist>");
            Console.WriteLine("Names to list: equipments, leases, dues, users, all");
        }
    }

    public static void AddCommand(string[] inputArgs, int args)
    {
        if (args > 1)
        {
            if (inputArgs[1] == "equipment")
            {
                if (inputArgs[2].ToLower() == "laptop")
                {
                    Equipments.Add(new Laptop());
                }if (inputArgs[2].ToLower() == "camera")
                {
                    Equipments.Add(new Camera());
                }if (inputArgs[2].ToLower() == "projector")
                {
                    Equipments.Add(new Projector());
                }
            }else if (inputArgs[1] == "lease")
            {
                
            }else if (inputArgs[1] == "user")
            {
                if (inputArgs.Length >= 5 && inputArgs[2].ToLower() == "student" && inputArgs[3] != "" && inputArgs[4] != "")
                {
                    Users.Add(new Student(inputArgs[3],  inputArgs[4]));
                }else if (inputArgs.Length >= 5 && inputArgs[2].ToLower() == "employee" && inputArgs[3] != "" && inputArgs[4] != "")
                {
                    Users.Add(new Employee(inputArgs[3],  inputArgs[4]));
                }
                else
                {
                    Console.WriteLine("Invalid input");
                    Console.WriteLine("Correct Input: add user <type> <name> <surname>");
                    Console.WriteLine("Existing types: student, employee");
                }
            }else if (inputArgs[1] == "due")
            {
                            
            }else
            {
                Console.WriteLine("Proper use of the command: add <nameToAdd>");
                Console.WriteLine("Names to add: equipment, lease, due, user");
                Console.WriteLine("The rest of the command depends on the type you selected.");
            }
                        
        }else
        {
            Console.WriteLine("Proper use of the command: add <nameToAdd>");
            Console.WriteLine("Names to add: equipment, lease, due, user"); Console.WriteLine("The rest of the command depends on the type you selected.");
        }
    }

    public static void RemoveCommand(string[] inputArgs, int args)
    {
        
    }

    public static void LeaseCommand(string[] inputArgs, int args)
    {
        
    }

    public static void ReportCommand()
    {
        Console.WriteLine($"Total equipments: {Equipments.GetList().Count}");
        Console.WriteLine($"Available equipments: {Equipments.GetList().Count(e => e.Availibility)}");
        Console.WriteLine($"Active leases: {Leases.GetList().Count(l => l.ReturnDate == null)}");
        Console.WriteLine($"Overdue leases: {Leases.GetList().Count(l => l.ReturnDate == null && l.ExpiryDate < DateTime.Now)}");
    }
}