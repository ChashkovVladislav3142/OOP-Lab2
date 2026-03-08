using Lab2.Domain.Interfaces;
using Lab2.Domain.Builders;
using Lab2.Domain.Strategies;

namespace Lab2.Domain.Factories;

public class LegendaryKitFactory : ItemFactoryBase
{
    public override IItem CreateWeapon() =>
        new WeaponBuilder()
            .SetName("Экскалибур")
            .SetDescription("Легендарный меч, пропитанный божественной энергией.")
            .SetRarity(ItemRarity.Legendary)
            .SetDamage(100)
            .SetStrategy(new EquipStrategy())
            .Build();

    public override IItem CreateArmor() =>
        new ArmorBuilder()
            .SetName("Доспех из драконьей чешуи")
            .SetDescription("Доспех, выкованный из чешуи древнего дракона.")
            .SetRarity(ItemRarity.Legendary)
            .SetDefense(50)
            .SetStrategy(new EquipStrategy())
            .Build();

    public override IItem CreateUtility() =>
        new PotionBuilder()
            .SetName("Перо феникса")
            .SetDescription("Перо, способное оживить кого угодно.")
            .SetRarity(ItemRarity.Epic)
            .SetHealing(500)
            .SetUses(1)
            .SetStrategy(new ConsumeStrategy())
            .Build();
}
