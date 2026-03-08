using Lab2.Domain.Interfaces;

namespace Lab2.Domain.Models;

public class Weapon : BaseItem, IEquippable
{
    public int Damage { get; private set; }
    public bool IsEquipped { get; private set; }

    public Weapon(string name, string description, ItemRarity rarity, int damage, IExecutable strategy, IItemState initialState)
        : base(name, description, rarity, strategy, initialState)
    {
        Damage = damage;
    }

    public void Equip() => IsEquipped = true;
    public void Unequip() => IsEquipped = false;
}
