using Lab2.Domain.Interfaces;
using Lab2.Domain.Models;
using Lab2.Domain.States;
using Lab2.Domain.Strategies;
using Lab2.Domain.Builders;

namespace Lab2.Domain.Factories;

public class StarterKitFactory : IItemFactory
{
    public IItem CreateWeapon() => new ItemBuilder()
        .SetName("Деревянный меч")
        .SetDescription("Простой деревянный меч для новичков.")
        .SetRarity(ItemRarity.Common)
        .SetDamage(5)
        .SetStrategy(new EquipStrategy())
        .BuildWeapon();

    public IItem CreateArmor() => new ItemBuilder()
        .SetName("Тканевая туника")
        .SetDescription("Базовая тканевая туника, обеспечивающая минимальную защиту.")
        .SetRarity(ItemRarity.Common)
        .SetDefense(2)
        .SetStrategy(new EquipStrategy())
        .BuildArmor();

    public IItem CreateUtility() => new ItemBuilder()
        .SetName("Малое зелье лечения")
        .SetDescription("Небольшая склянка, наполненная красной жидкостью.")
        .SetRarity(ItemRarity.Common)
        .SetHealing(10)
        .SetUses(1)
        .SetStrategy(new ConsumeStrategy())
        .BuildPotion();
}

public class LegendaryKitFactory : IItemFactory
{
    public IItem CreateWeapon() => new ItemBuilder()
        .SetName("Экскалибур")
        .SetDescription("Легендарный меч, пропитанный божественной энергией.")
        .SetRarity(ItemRarity.Legendary)
        .SetDamage(100)
        .SetStrategy(new EquipStrategy())
        .BuildWeapon();

    public IItem CreateArmor() => new ItemBuilder()
        .SetName("Доспех из драконьей чешуи")
        .SetDescription("Доспех, выкованный из чешуи древнего дракона.")
        .SetRarity(ItemRarity.Legendary)
        .SetDefense(50)
        .SetStrategy(new EquipStrategy())
        .BuildArmor();

    public IItem CreateUtility() => new ItemBuilder()
        .SetName("Перо феникса")
        .SetDescription("Перо, способное оживить кого угодно.")
        .SetRarity(ItemRarity.Epic)
        .SetHealing(500)
        .SetUses(1)
        .SetStrategy(new ConsumeStrategy())
        .BuildPotion();
}
