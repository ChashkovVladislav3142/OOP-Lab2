using Lab2.Domain.Interfaces;

namespace Lab2.Domain.Models;

public abstract class BaseItem : IItem
{
    public string Name { get; protected set; }
    public string Description { get; protected set; }
    public ItemRarity Rarity { get; protected set; }
    public IItemState State { get; private set; }
    
    protected readonly IItemActionStrategy ActionStrategy;

    protected BaseItem(string name, string description, ItemRarity rarity, IItemActionStrategy actionStrategy, IItemState initialState)
    {
        Name = name;
        Description = description;
        Rarity = rarity;
        ActionStrategy = actionStrategy;
        State = initialState;
    }

    public void SetState(IItemState state)
    {
        State = state;
    }

    public virtual void PerformAction()
    {
        State.HandleAction(this);
        ActionStrategy.Execute(this);
    }

    public override string ToString() => $"[{Rarity}] {Name} ({State.DisplayName}) - {Description}";
}
