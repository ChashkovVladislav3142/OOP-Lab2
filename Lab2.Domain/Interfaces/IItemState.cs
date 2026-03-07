namespace Lab2.Domain.Interfaces;

public interface IItemState
{
    string DisplayName { get; }
    float EffectivenessMultiplier { get; }
    void HandleAction(IItem item);
}
