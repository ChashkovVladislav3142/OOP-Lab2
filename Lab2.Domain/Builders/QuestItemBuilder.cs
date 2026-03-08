using Lab2.Domain.Models;

namespace Lab2.Domain.Builders;

public class QuestItemBuilder : ItemBuilderBase<QuestItemBuilder>
{
    public QuestItem Build() => new QuestItem(Name, Description, Rarity, Strategy, InitialState);
}
