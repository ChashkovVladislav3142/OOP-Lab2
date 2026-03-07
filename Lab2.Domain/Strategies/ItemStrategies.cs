using Lab2.Domain.Interfaces;
using Lab2.Domain.Models;

namespace Lab2.Domain.Strategies;

public class EquipStrategy : IItemActionStrategy
{
    public void Execute(IItem item)
    {
        if (item is IEquippable equippable)
        {
            if (equippable.IsEquipped)
                equippable.Unequip();
            else
                equippable.Equip();
        }
    }
}

public class ConsumeStrategy : IItemActionStrategy
{
    public void Execute(IItem item)
    {
        if (item is IConsumable consumable)
        {
            consumable.Consume();
        }
    }
}

public class NoActionStrategy : IItemActionStrategy
{
    public void Execute(IItem item) { }
}
