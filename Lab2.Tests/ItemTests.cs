using Lab2.Domain.Builders;
using Lab2.Domain.Factories;
using Lab2.Domain.Interfaces;
using Lab2.Domain.Models;
using Lab2.Domain.Services;
using Lab2.Domain.States;
using Lab2.Domain.Strategies;
using Xunit;

namespace Lab2.Tests;

public class ItemTests
{
    [Fact]
    public void Builder_ShouldCreateWeaponWithCorrectStats()
    {
        var weapon = new WeaponBuilder()
            .SetName("Стальной меч")
            .SetDescription("Острый меч.")
            .SetRarity(ItemRarity.Uncommon)
            .SetDamage(15)
            .SetStrategy(new EquipStrategy())
            .Build();

        Assert.Equal("Стальной меч", weapon.Name);
        Assert.Equal(15, weapon.Damage);
        Assert.Equal(ItemRarity.Uncommon, weapon.Rarity);
        Assert.IsType<NewState>(weapon.State);
    }

    [Fact]
    public void Weapon_PerformAction_ShouldChangeState()
    {
        var weapon = new WeaponBuilder()
            .SetName("Тестовый меч")
            .SetStrategy(new EquipStrategy())
            .Build();

        Assert.IsType<NewState>(weapon.State);
        weapon.PerformAction();

        Assert.IsType<UsedState>(weapon.State);
        weapon.PerformAction();
        Assert.IsType<BrokenState>(weapon.State);
    }

    [Fact]
    public void EquipStrategy_ShouldToggleEquippedStatus()
    {
        var weapon = new WeaponBuilder()
            .SetName("Тестовый меч")
            .SetStrategy(new EquipStrategy())
            .Build();

        weapon.PerformAction();
        Assert.True(weapon.IsEquipped);

        weapon.PerformAction();
        Assert.False(weapon.IsEquipped);
    }

    [Fact]
    public void StarterKitFactory_ShouldCreateCommonItems()
    {
        var factory = new StarterKitFactory();

        var weapon = factory.CreateWeapon();
        var armor = factory.CreateArmor();

        Assert.Equal(ItemRarity.Common, weapon.Rarity);
        Assert.Equal(ItemRarity.Common, armor.Rarity);
    }

    [Fact]
    public void Potion_Consume_ShouldDecreaseUses()
    {
        var potion = new PotionBuilder()
            .SetName("Зелье лечения")
            .SetHealing(20)
            .SetUses(2)
            .SetStrategy(new ConsumeStrategy())
            .Build();

        potion.PerformAction();

        Assert.Equal(1, potion.UsesRemaining);
    }

    [Fact]
    public void ItemEnhancementService_CombineTwoWeapons_ShouldCreateStrongerWeapon()
    {
        var enhancer = new ItemEnhancementService();
        var w1 = new WeaponBuilder().SetName("Меч").SetDamage(10).Build();
        var w2 = new WeaponBuilder().SetName("Меч").SetDamage(10).Build();

        var result = enhancer.Combine(w1, w2) as Weapon;

        Assert.NotNull(result);
        Assert.Equal(12, result.Damage);
        Assert.Equal(ItemRarity.Uncommon, result.Rarity);
    }

    [Fact]
    public void Armor_Equip_ShouldFunctionCorrectly()
    {
        var armor = new ArmorBuilder().SetName("Латный доспех").SetDefense(10).SetStrategy(new EquipStrategy()).Build();

        armor.PerformAction();

        Assert.True(armor.IsEquipped);
    }

    [Fact]
    public void ItemEnhancementService_ImproveBrokenItem_ShouldMakeItNew()
    {
        var enhancer = new ItemEnhancementService();
        var weapon = new WeaponBuilder().SetName("Ржавый меч").SetInitialState(new BrokenState()).Build();

        var result = enhancer.Improve(weapon);

        Assert.IsType<NewState>(result.State);
    }

    [Fact]
    public void LegendaryKitFactory_ShouldCreateLegendaryItems()
    {
        var factory = new LegendaryKitFactory();

        var weapon = factory.CreateWeapon();
        var armor = factory.CreateArmor();

        Assert.Equal(ItemRarity.Legendary, weapon.Rarity);
        Assert.Equal(ItemRarity.Legendary, armor.Rarity);
    }

    [Fact]
    public void QuestItem_PerformAction_ShouldOnlyChangeState()
    {
        var item = new QuestItemBuilder().SetName("Карта").Build();

        item.PerformAction();

        Assert.IsType<UsedState>(item.State);
    }
}
