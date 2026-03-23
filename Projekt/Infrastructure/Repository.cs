namespace Projekt.Infrastructure;

using System.Text.Json;

public class Repository<T>
{
    public string path { get; }
    private List<T> items;
    
    public Repository(string path)
    {
        this.path = path;
        items = Load(path);
    }
    
    
    // Pobieranie danych

    public IReadOnlyList<T> GetList()
    {
        return items.AsReadOnly();
    }

    // Dodawanie danych

    public void Add(T item)
    {
        items.Add(item);
        Save();
    }

    // Usuwanie danych

    public void Remove(T item)
    {
        items.Remove(item);
        Save();
    }

    // Zapisywanie danych

    public void Save()
    {
        File.WriteAllText(path, JsonSerializer.Serialize(items, new JsonSerializerOptions { WriteIndented = true }));
    }

    // Wczytanie

    private List<T> Load(string path)
    {
        if (!File.Exists(path))
        {
            File.WriteAllText(path, "[]");
            return new List<T>();
        }

        var json = File.ReadAllText(path);
        
        return JsonSerializer.Deserialize<List<T>>(json) ?? new List<T>();// Jak coś pójdzie źle daje pustą listę
    }
    
    // Usuwanie całej listy

    public void Clear()
    {
        items.Clear();
        Save();
    }

}