namespace Projekt.Infrastructure;

using System.Text.Json;

public class Repository<T> : IRepository<T>
{
    public string Path { get; }
    private List<T> _items;
    
    public Repository(string path)
    {
        this.Path = path;
        _items = Load(Path);
    }
    
    
    // Pobieranie danych

    public IReadOnlyList<T> GetList()
    {
        return _items.AsReadOnly();
    }

    // Dodawanie danych

    public void Add(T item)
    {
        _items.Add(item);
        Save();
    }

    // Usuwanie danych

    public void Remove(T item)
    {
        _items.Remove(item);
        Save();
    }

    // Zapisywanie danych

    public void Save()
    {
        try
        {
            File.WriteAllText(Path, JsonSerializer.Serialize(_items, new JsonSerializerOptions { WriteIndented = true }));
        }
        catch (Exception e)
        {
            Console.WriteLine($"Błąd podczas zapisywania do pliku: {e.Message}");
            throw;
        }
    }

    // Wczytanie

    private List<T> Load(string path)
    {
        try
        {
            if (!File.Exists(path))
            {
                File.WriteAllText(path, "[]");
                return new List<T>();
            }

            string json = File.ReadAllText(path);
            return JsonSerializer.Deserialize<List<T>>(json) ?? new List<T>();// Jak coś pójdzie źle daje pustą listę
        }
        catch (Exception e)
        {
            Console.WriteLine($"Błąd podczas wczytywania pliku {path}: {e.Message}");
            return new List<T>();
        }
    }
    
    // Usuwanie całej listy

    public void Clear()
    {
        _items.Clear();
        Save();
    }

}