using Lab2.Domain.Models;

namespace Lab2.Domain.Builders;

public class PotionBuilder : ItemBuilderBase<PotionBuilder>
{
    private int _healing;
    private int _uses;

    public PotionBuilder SetHealing(int healing) { _healing = healing; return this; }
    public PotionBuilder SetUses(int uses) { _uses = uses; return this; }

    public Potion Build() => new Potion(Name, Description, Rarity, _healing, _uses, Strategy, InitialState);
}
