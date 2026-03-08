using Lab2.Domain.Interfaces;

namespace Lab2.Domain.Strategies;

public class ConsumeStrategy : IExecutable
{
    public void Execute(IItem item)
    {
        if (item is IConsumable consumable)
        {
            consumable.Consume();
        }
    }
}
