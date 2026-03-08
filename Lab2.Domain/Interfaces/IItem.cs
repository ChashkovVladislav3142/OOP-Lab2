namespace Lab2.Domain.Interfaces;

public enum ItemRarity
{
    Common,
    Uncommon,
    Rare,
    Epic,
    Legendary
}

public interface IItem
{
    string Name { get; }
    string Description { get; }
    ItemRarity Rarity { get; }
    IItemState State { get; }
    void SetState(IItemState state);
    void PerformAction();
    void Repair();
}

public interface IEquippable : IItem
{
    bool IsEquipped { get; }
    void Equip();
    void Unequip();
}

public interface IConsumable : IItem
{
    int UsesRemaining { get; }
    void Consume();
}
