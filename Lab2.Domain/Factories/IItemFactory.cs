using Lab2.Domain.Interfaces;

namespace Lab2.Domain.Factories;

public interface IItemFactory
{
    IItem CreateWeapon();
    IItem CreateArmor();
    IItem CreateUtility();
}
