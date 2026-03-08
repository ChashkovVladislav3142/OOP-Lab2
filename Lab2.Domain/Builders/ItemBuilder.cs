using Lab2.Domain.Interfaces;
using Lab2.Domain.Models;
using Lab2.Domain.States;
using Lab2.Domain.Strategies;

namespace Lab2.Domain.Builders;


[Obsolete("Use specialised builders: WeaponBuilder, ArmorBuilder, PotionBuilder, QuestItemBuilder.")]
public class ItemBuilder
{
    private string _name = string.Empty;
    private string _description = string.Empty;
    private ItemRarity _rarity = ItemRarity.Common;
    private IItemState _initialState = new NewState();
    private IExecutable _strategy = new NoActionStrategy();
    private int _damage;
    private int _defense;
    private int _healing;
    private int _uses;

    public ItemBuilder SetName(string name) { _name = name; return this; }
    public ItemBuilder SetDescription(string description) { _description = description; return this; }
    public ItemBuilder SetRarity(ItemRarity rarity) { _rarity = rarity; return this; }
    public ItemBuilder SetStrategy(IExecutable strategy) { _strategy = strategy; return this; }
    public ItemBuilder SetInitialState(IItemState state) { _initialState = state; return this; }
    public ItemBuilder SetDamage(int damage) { _damage = damage; return this; }
    public ItemBuilder SetDefense(int defense) { _defense = defense; return this; }
    public ItemBuilder SetHealing(int healing) { _healing = healing; return this; }
    public ItemBuilder SetUses(int uses) { _uses = uses; return this; }

    public Weapon BuildWeapon() =>
        new WeaponBuilder().SetName(_name).SetDescription(_description).SetRarity(_rarity)
            .SetStrategy(_strategy).SetInitialState(_initialState).SetDamage(_damage).Build();

    public Armor BuildArmor() =>
        new ArmorBuilder().SetName(_name).SetDescription(_description).SetRarity(_rarity)
            .SetStrategy(_strategy).SetInitialState(_initialState).SetDefense(_defense).Build();

    public Potion BuildPotion() =>
        new PotionBuilder().SetName(_name).SetDescription(_description).SetRarity(_rarity)
            .SetStrategy(_strategy).SetInitialState(_initialState).SetHealing(_healing).SetUses(_uses).Build();

    public QuestItem BuildQuestItem() =>
        new QuestItemBuilder().SetName(_name).SetDescription(_description).SetRarity(_rarity)
            .SetStrategy(_strategy).SetInitialState(_initialState).Build();
}
