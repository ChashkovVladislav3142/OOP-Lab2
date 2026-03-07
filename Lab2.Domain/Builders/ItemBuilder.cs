using Lab2.Domain.Interfaces;
using Lab2.Domain.Models;
using Lab2.Domain.States;
using Lab2.Domain.Strategies;

namespace Lab2.Domain.Builders;

public class ItemBuilder
{
    private string _name = string.Empty;
    private string _description = string.Empty;
    private ItemRarity _rarity = ItemRarity.Common;
    private IItemState _initialState = new NewState();
    private IItemActionStrategy _strategy = new NoActionStrategy();
    private int _damage;
    private int _defense;
    private int _healing;
    private int _uses;

    public ItemBuilder SetName(string name) { _name = name; return this; }
    public ItemBuilder SetDescription(string description) { _description = description; return this; }
    public ItemBuilder SetRarity(ItemRarity rarity) { _rarity = rarity; return this; }
    public ItemBuilder SetStrategy(IItemActionStrategy strategy) { _strategy = strategy; return this; }
    public ItemBuilder SetInitialState(IItemState state) { _initialState = state; return this; }
    
    public ItemBuilder SetDamage(int damage) { _damage = damage; return this; }
    public ItemBuilder SetDefense(int defense) { _defense = defense; return this; }
    public ItemBuilder SetHealing(int healing) { _healing = healing; return this; }
    public ItemBuilder SetUses(int uses) { _uses = uses; return this; }

    public Weapon BuildWeapon() => new Weapon(_name, _description, _rarity, _damage, _strategy, _initialState);
    public Armor BuildArmor() => new Armor(_name, _description, _rarity, _defense, _strategy, _initialState);
    public Potion BuildPotion() => new Potion(_name, _description, _rarity, _healing, _uses, _strategy, _initialState);
    public QuestItem BuildQuestItem() => new QuestItem(_name, _description, _rarity, _strategy, _initialState);
}
