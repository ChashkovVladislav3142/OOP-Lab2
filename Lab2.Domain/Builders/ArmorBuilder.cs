using Lab2.Domain.Models;

namespace Lab2.Domain.Builders;

public class ArmorBuilder : ItemBuilderBase<ArmorBuilder>
{
    private int _defense;

    public ArmorBuilder SetDefense(int defense) { _defense = defense; return this; }

    public Armor Build() => new Armor(Name, Description, Rarity, _defense, Strategy, InitialState);
}
