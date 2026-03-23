namespace  Projekt;

public class Program
{
    // Repozytoria
    static IList<User> Users;
    static IList<Due> Dues;
    static IList<Equipment> Equipments;
    static IList<Lease> Leases;
    
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
                                      "You can choose from: equipment, lease, due, user, all\n\n");
                    break;
                case "list":// TODO: Wyświetlenie wyłącznie dostępnych equipment
                    if (args == 1)
                    {
                        if (inputArgs[1] == "equipment")
                        {
                            Console.WriteLine("Equipments: ");
                            PrintList(Equipments);
                        }else if (inputArgs[1] == "lease")
                        {
                            Console.WriteLine("Leases: ");
                            PrintList(Leases);    
                        }else if (inputArgs[1] == "due")
                        {
                            Console.WriteLine("Dues: ");
                            PrintList(Dues);
                        }else if (inputArgs[1] == "user")
                        {
                            Console.WriteLine("Users: ");
                            PrintList(Users);
                        }else if (inputArgs[1] == "all")
                        {
                            Console.WriteLine("Users: ");
                            PrintList(Users);
                            Console.WriteLine("Equipments: ");
                            PrintList(Equipments);
                            Console.WriteLine("Leases: ");
                            PrintList(Leases);
                            Console.WriteLine("Dues: ");
                            PrintList(Dues);
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
                    break;
                case "add":
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
                            if (inputArgs[2].ToLower() == "student")
                            {
                                Users.Add(new Student(inputArgs[3],  inputArgs[4]));
                            }else if (inputArgs[2].ToLower() == "employee")
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
                        Console.WriteLine("Names to add: equipment, lease, due, user");
                        Console.WriteLine("The rest of the command depends on the type you selected.");
                    }

                    break;
                case "remove":
                    if (args > 1)
                    {
                        
                    }
                    else
                    {
                        
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
        
        Users = JsonExtensions.LoadAnyListFromFile<User>(GetPath("users.json"));
        Dues = JsonExtensions.LoadAnyListFromFile<Due>(GetPath("dues.json"));
        Equipments = JsonExtensions.LoadAnyListFromFile<Equipment>(GetPath("equipments.json"));
        Leases = JsonExtensions.LoadAnyListFromFile<Lease>(GetPath("leases.json"));
        
        Console.WriteLine("Database Loaded");
    }
    
    
    
    // Wyświetlanie całej listy (Trzeba dodać do każdej głównej klasy ovveride na String)
    public static void PrintList<T>(IList<T> list)
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