using System.Security.AccessControl;

namespace  Projekt;

using System.Text.Json;

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
                    Console.WriteLine("Available commands:\n\n" +
                                      "help - Shows available commands.\n\n" +
                                      "add - Adds the type you want to the database\n" +
                                      "Like: user, lease, equipment, due\n\n" +
                                      "list - Makes a list of objects currently in the database.\n" +
                                      "Example: list users\n" +
                                      "You can choose from: equipments, leases, dues, users, all\n\n");
                    break;
                case "list":
                    if (args == 1)
                    {
                        if (inputArgs[1] == "equipments")
                        {
                            PrintList(Equipments.GetList());
                        }else if (inputArgs[1] == "leases")
                        {
                            PrintList(Leases.GetList());    
                        }else if (inputArgs[1] == "dues")
                        {
                            PrintList(Dues.GetList());
                        }else if (inputArgs[1] == "users")
                        {
                            PrintList(Users.GetList());
                        }else if (inputArgs[1] == "all")
                        {
                            Console.WriteLine("Users: ");
                            PrintList(Users.GetList());
                            Console.WriteLine("Equipments: ");
                            PrintList(Equipments.GetList());
                            Console.WriteLine("Leases: ");
                            PrintList(Leases.GetList());
                            Console.WriteLine("Dues: ");
                            PrintList(Dues.GetList());
                        }
                    }
                    else
                    {
                        Console.WriteLine("Proper use of the command: list <nameTolist>");
                        Console.WriteLine("Names to list: equipments, leases, dues, users, all");
                    }
                    break;
                case "add":
                    if (args > 1)
                    {
                        if (inputArgs[1] == "equipment")
                        {

                        }else if (inputArgs[1] == "lease")
                        {
                            
                        }else if (inputArgs[1] == "user")
                        {
                            
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
                        Console.WriteLine("Names to add: equipment, lease, due, user");
                        Console.WriteLine("The rest of the command depends on the type you selected.");
                    }

                    break;
                default:
                    Console.WriteLine($"'{input}' is not recognized as an available command");
                    break;
                    
            }
        }
    }

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

}