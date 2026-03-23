using System.Text.Json;

namespace Projekt.Infrastructure;

using System.Text.Json.Serialization;

public interface IRepository<T>
{
    IReadOnlyList<T> GetList();
    void Add(T item);
    void Remove(T item);
    void Save();
    void Clear();
}