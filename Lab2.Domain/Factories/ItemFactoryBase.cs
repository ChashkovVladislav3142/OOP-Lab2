using Lab2.Domain.Interfaces;

namespace Lab2.Domain.Factories;

public abstract class ItemFactoryBase : IItemFactory
{
    public abstract IItem CreateWeapon();
    public abstract IItem CreateArmor();
    public abstract IItem CreateUtility();
}
