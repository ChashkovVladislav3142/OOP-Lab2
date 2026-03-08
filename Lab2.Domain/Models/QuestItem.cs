using Lab2.Domain.Interfaces;

namespace Lab2.Domain.Models;

public class QuestItem : BaseItem
{
    public QuestItem(string name, string description, ItemRarity rarity, IExecutable strategy, IItemState initialState)
        : base(name, description, rarity, strategy, initialState)
    {
    }
}
