using System.Text.Json;

namespace Projekt.Extensions;

public static class JsonExtensions
{
    /// <summary>
    /// tutaj ładuję coś z jsona, oczywiście pamiętam że ten obiekt musi się dać zdeserializować
    /// jeśli będzie błąd to zwrócona zostanie wartość def
    /// </summary>
    /// <param name="path">ścieżka do pliku</param>
    /// <param name="def">obiekt który zostanie zwrócony w razie problemu</param>
    /// <typeparam name="T">typ np. List</typeparam>
    /// <returns>zdeserializowany obiekt albo wartość parametru def</returns>
    public static T? LoadAnythingFromFile<T>(string path, T? def = default)
    {
        if (!File.Exists(path))
        {
            File.WriteAllText(path, "[]");
            return def;
        }

        try
        {
            var json = File.ReadAllText(path);

            return JsonSerializer.Deserialize<T>(json) ?? def; // Jak coś pójdzie źle daje pustą listę
        }
        catch (JsonException)
        {
            return def;
        }
    }

    /// <summary>
    /// tutaj ładuję listę jakiegoś czegoś ale to coś musi się dać zdeserializować
    /// </summary>
    /// <param name="path">tu plik w sensie ściezka</param>
    /// <typeparam name="T">tu to coś czego liste mamy</typeparam>
    /// <returns>lista od coś</returns>
    public static List<T> LoadAnyListFromFile<T>(string path)
    {
        return LoadAnythingFromFile(path, new List<T>()) ?? [];
    }

    /// <summary>
    /// zapisz cokolwiek co się lubi z jsonem do pliku pod ścieżką <paramref name="path"/>
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="path"></param>
    /// <typeparam name="T"></typeparam>
    public static void WriteAnythingToFile<T>(this T obj, string path)
    {
        File.WriteAllText(path, JsonSerializer.Serialize(obj, new JsonSerializerOptions { WriteIndented = true }));
    }
}