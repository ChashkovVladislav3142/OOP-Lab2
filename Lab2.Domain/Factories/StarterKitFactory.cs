using Lab2.Domain.Interfaces;
using Lab2.Domain.Builders;
using Lab2.Domain.Strategies;

namespace Lab2.Domain.Factories;

public class StarterKitFactory : ItemFactoryBase
{
    public override IItem CreateWeapon() =>
        new WeaponBuilder()
            .SetName("Деревянный меч")
            .SetDescription("Простой деревянный меч для новичков.")
            .SetRarity(ItemRarity.Common)
            .SetDamage(5)
            .SetStrategy(new EquipStrategy())
            .Build();

    public override IItem CreateArmor() =>
        new ArmorBuilder()
            .SetName("Тканевая туника")
            .SetDescription("Базовая тканевая туника, обеспечивающая минимальную защиту.")
            .SetRarity(ItemRarity.Common)
            .SetDefense(2)
            .SetStrategy(new EquipStrategy())
            .Build();

    public override IItem CreateUtility() =>
        new PotionBuilder()
            .SetName("Малое зелье лечения")
            .SetDescription("Небольшая склянка, наполненная красной жидкостью.")
            .SetRarity(ItemRarity.Common)
            .SetHealing(10)
            .SetUses(1)
            .SetStrategy(new ConsumeStrategy())
            .Build();
}
