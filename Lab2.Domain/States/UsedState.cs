using Lab2.Domain.Interfaces;

namespace Lab2.Domain.States;

public class UsedState : IItemState
{
    public string DisplayName => "Б/У";
    public float EffectivenessMultiplier => 0.8f;

    public void HandleAction(IItem item)
    {
        item.SetState(new BrokenState());
    }
}
