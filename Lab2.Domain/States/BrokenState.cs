using Lab2.Domain.Interfaces;

namespace Lab2.Domain.States;

public class BrokenState : IItemState
{
    public string DisplayName => "Сломан";
    public float EffectivenessMultiplier => 0.2f;

    public void HandleAction(IItem item) { }
}
