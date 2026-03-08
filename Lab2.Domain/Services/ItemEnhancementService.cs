using Lab2.Domain.Interfaces;
using Lab2.Domain.Models;
using Lab2.Domain.Builders;
using Lab2.Domain.States;
using Lab2.Domain.Strategies;

namespace Lab2.Domain.Services;

public class ItemEnhancementService
{
    public IItem Improve(IItem item)
    {
        if (item.State is BrokenState || item.State is UsedState)
        {
            item.Repair();
            return item;
        }
        
        var nextRarity = item.Rarity < ItemRarity.Legendary ? item.Rarity + 1 : item.Rarity;
        return item;
    }

    public IItem Combine(IItem item1, IItem item2)
    {
        if (item1.Name == item2.Name && item1.GetType() == item2.GetType())
        {
            var nextRarity = item1.Rarity < ItemRarity.Legendary ? item1.Rarity + 1 : item1.Rarity;

            if (item1 is Weapon w1 && item2 is Weapon)
            {
                return new WeaponBuilder()
                    .SetName(item1.Name)
                    .SetDescription(item1.Description)
                    .SetRarity(nextRarity)
                    .SetInitialState(new NewState())
                    .SetDamage(w1.Damage + 2)
                    .SetStrategy(new EquipStrategy())
                    .Build();
            }

            if (item1 is Armor a1 && item2 is Armor)
            {
                return new ArmorBuilder()
                    .SetName(item1.Name)
                    .SetDescription(item1.Description)
                    .SetRarity(nextRarity)
                    .SetInitialState(new NewState())
                    .SetDefense(a1.Defense + 1)
                    .SetStrategy(new EquipStrategy())
                    .Build();
            }

            return new QuestItemBuilder()
                .SetName(item1.Name)
                .SetDescription(item1.Description)
                .SetRarity(nextRarity)
                .SetInitialState(new NewState())
                .Build();
        }

        return item1;
    }
}
