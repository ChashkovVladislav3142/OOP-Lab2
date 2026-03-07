using Lab2.Domain.Interfaces;
using Lab2.Domain.Models;
using Lab2.Domain.Factories;
using Lab2.Domain.Services;
using Lab2.Domain.Builders;
using Lab2.Domain.Strategies;

namespace Lab2;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Демонстрация системы инвентаря РПГ ===\n");

        var inventory = new InventoryManager();
        var enhancer = new ItemEnhancer();

        Console.WriteLine("[1] Создание стартового набора через абстрактную фабрику...");
        IItemFactory starterFactory = new StarterKitFactory();
        var woodSword = starterFactory.CreateWeapon();
        var tunic = starterFactory.CreateArmor();
        var minorPotion = starterFactory.CreateUtility();

        inventory.AddItem(woodSword);
        inventory.AddItem(tunic);
        inventory.AddItem(minorPotion);

        Console.WriteLine("[2] Создание кастомного предмета через Builder...");
        var customBow = new ItemBuilder()
            .SetName("Рекурсивный лук")
            .SetDescription("Прекрасно сработанный эльфийский лук.")
            .SetRarity(ItemRarity.Rare)
            .SetDamage(25)
            .SetStrategy(new EquipStrategy())
            .BuildWeapon();
        
        inventory.AddItem(customBow);

        inventory.ShowInventory();

        Console.WriteLine("\n[3] Взаимодействие с предметами (Паттерны Strategy и State)...");
        Console.WriteLine($"Действие с {woodSword.Name}: Состояние было {woodSword.State.DisplayName}");
        woodSword.PerformAction(); 
        Console.WriteLine($"Текущее состояние: {woodSword.State.DisplayName}, Экипировано: {(woodSword as IEquippable)?.IsEquipped}");
        
        woodSword.PerformAction(); 
        Console.WriteLine($"Текущее состояние: {woodSword.State.DisplayName}, Экипировано: {(woodSword as IEquippable)?.IsEquipped}");

        Console.WriteLine("\n[4] Починка сломанного предмета...");
        enhancer.Improve(woodSword);
        Console.WriteLine($"После улучшения: {woodSword.ToString()}");

        Console.WriteLine("\n[5] Комбинирование предметов...");
        var sword1 = new ItemBuilder().SetName("Короткий меч").SetDescription("Старый пехотный меч.").SetDamage(8).BuildWeapon();
        var sword2 = new ItemBuilder().SetName("Короткий меч").SetDescription("Старый пехотный меч.").SetDamage(8).BuildWeapon();
        
        var legacySword = enhancer.Combine(sword1, sword2);
        inventory.AddItem(legacySword);
        Console.WriteLine($"Результат объединения {sword1.Name} + {sword2.Name} = {legacySword.ToString()}");

        Console.WriteLine("\n[6] Создание легендарного снаряжения...");
        IItemFactory epicFactory = new LegendaryKitFactory();
        inventory.AddItem(epicFactory.CreateWeapon());
        inventory.AddItem(epicFactory.CreateArmor());

        Console.WriteLine();
        inventory.ShowInventory();

        Console.WriteLine("\nДемонстрация завершена. Нажмите любую клавишу для выхода.");
    }
}
