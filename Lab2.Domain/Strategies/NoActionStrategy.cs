using Lab2.Domain.Interfaces;

namespace Lab2.Domain.Strategies;

public class NoActionStrategy : IExecutable
{
    public void Execute(IItem item) { }
}
