using Lab2.Domain.Interfaces;

namespace Lab2.Domain.Models;

public class Weapon : BaseItem, IEquippable
{
    public int Damage { get; private set; }
    public bool IsEquipped { get; private set; }

    public Weapon(string name, string description, ItemRarity rarity, int damage, IItemActionStrategy strategy, IItemState initialState) 
        : base(name, description, rarity, strategy, initialState)
    {
        Damage = damage;
    }

    public void Equip()
    {
        IsEquipped = true;
    }

    public void Unequip()
    {
        IsEquipped = false;
    }

    public override void PerformAction()
    {
        base.PerformAction();
    }
}

public class Armor : BaseItem, IEquippable
{
    public int Defense { get; private set; }
    public bool IsEquipped { get; private set; }

    public Armor(string name, string description, ItemRarity rarity, int defense, IItemActionStrategy strategy, IItemState initialState) 
        : base(name, description, rarity, strategy, initialState)
    {
        Defense = defense;
    }

    public void Equip() => IsEquipped = true;
    public void Unequip() => IsEquipped = false;
}

public class Potion : BaseItem, IConsumable
{
    public int HealingAmount { get; private set; }
    public int UsesRemaining { get; private set; }

    public Potion(string name, string description, ItemRarity rarity, int healingAmount, int uses, IItemActionStrategy strategy, IItemState initialState) 
        : base(name, description, rarity, strategy, initialState)
    {
        HealingAmount = healingAmount;
        UsesRemaining = uses;
    }

    public void Consume()
    {
        if (UsesRemaining > 0)
        {
            UsesRemaining--;
        }
    }
}

public class QuestItem : BaseItem
{
    public QuestItem(string name, string description, ItemRarity rarity, IItemActionStrategy strategy, IItemState initialState) 
        : base(name, description, rarity, strategy, initialState)
    {
    }
}
