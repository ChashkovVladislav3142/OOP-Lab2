using Lab2.Domain.Interfaces;

namespace Lab2.Domain.Strategies;

public class EquipStrategy : IExecutable
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
