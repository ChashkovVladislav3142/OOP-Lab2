using Lab2.Domain.Interfaces;

namespace Lab2.Domain.Models;

public class Armor : BaseItem, IEquippable
{
    public int Defense { get; private set; }
    public bool IsEquipped { get; private set; }

    public Armor(string name, string description, ItemRarity rarity, int defense, IExecutable strategy, IItemState initialState)
        : base(name, description, rarity, strategy, initialState)
    {
        Defense = defense;
    }

    public void Equip() => IsEquipped = true;
    public void Unequip() => IsEquipped = false;
}
