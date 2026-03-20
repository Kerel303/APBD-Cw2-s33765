namespace  Projekt;

using System.Text.Json;

public class Program
{
    // Repozytoria
    static Repository<User> Users;
    static Repository<Due> Dues;
    static Repository<Equipment> Equipments;
    static Repository<Lease> Leases;
    
    static void Main(String[] args)
    {
        string basePath = AppDomain.CurrentDomain.BaseDirectory;
        
        Users = new Repository<User>(GetPath("users.json"));
        Dues = new Repository<Due>(GetPath("dues.json"));
        Equipments = new Repository<Equipment>(GetPath("equipments.json"));
        Leases = new Repository<Lease>(GetPath("leases.json"));
        
        Console.WriteLine("Database Loaded");
        
    }


    
    
    // Wyświetlanie całej listy (Trzeba dodać do każdej głównej klasy ovveride na String)
    public static void printList<T>(List<T> list)
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