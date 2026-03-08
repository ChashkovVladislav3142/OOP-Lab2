using Lab2.Domain.Models;

namespace Lab2.Domain.Builders;

public class WeaponBuilder : ItemBuilderBase<WeaponBuilder>
{
    private int _damage;

    public WeaponBuilder SetDamage(int damage) { _damage = damage; return this; }

    public Weapon Build() => new Weapon(Name, Description, Rarity, _damage, Strategy, InitialState);
}
