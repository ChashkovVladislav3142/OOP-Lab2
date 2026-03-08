using Lab2.Domain.Interfaces;

namespace Lab2.Domain.Services;

public class InventoryService
{
    private readonly List<IItem> _items = new();

    public void AddItem(IItem item)
    {
        _items.Add(item);
    }

    public void RemoveItem(IItem item)
    {
        _items.Remove(item);
    }

    public IReadOnlyCollection<IItem> GetItems() => _items.AsReadOnly();

    public void ShowInventory()
    {
        Console.WriteLine("--- Состояние инвентаря ---");
        if (!_items.Any()) Console.WriteLine("Пусто.");
        foreach (var item in _items)
        {
            Console.WriteLine(item.ToString());
        }
        Console.WriteLine("-------------------------");
    }
}
