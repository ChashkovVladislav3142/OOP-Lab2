using Lab2.Domain.Interfaces;
using Lab2.Domain.States;
using Lab2.Domain.Strategies;

namespace Lab2.Domain.Builders;

public abstract class ItemBuilderBase<TBuilder> where TBuilder : ItemBuilderBase<TBuilder>
{
    protected string Name = string.Empty;
    protected string Description = string.Empty;
    protected ItemRarity Rarity = ItemRarity.Common;
    protected IItemState InitialState = new NewState();
    protected IExecutable Strategy = new NoActionStrategy();

    public TBuilder SetName(string name) { Name = name; return (TBuilder)this; }
    public TBuilder SetDescription(string description) { Description = description; return (TBuilder)this; }
    public TBuilder SetRarity(ItemRarity rarity) { Rarity = rarity; return (TBuilder)this; }
    public TBuilder SetStrategy(IExecutable strategy) { Strategy = strategy; return (TBuilder)this; }
    public TBuilder SetInitialState(IItemState state) { InitialState = state; return (TBuilder)this; }
}
