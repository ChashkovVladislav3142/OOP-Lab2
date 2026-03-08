using Lab2.Domain.Interfaces;

namespace Lab2.Domain.Models;

public class Potion : BaseItem, IConsumable
{
    public int HealingAmount { get; private set; }
    public int UsesRemaining { get; private set; }

    public Potion(string name, string description, ItemRarity rarity, int healingAmount, int uses, IExecutable strategy, IItemState initialState)
        : base(name, description, rarity, strategy, initialState)
    {
        HealingAmount = healingAmount;
        UsesRemaining = uses;
    }

    public void Consume()
    {
        if (UsesRemaining > 0)
            UsesRemaining--;
    }
}
