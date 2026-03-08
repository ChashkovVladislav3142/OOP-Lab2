using Lab2.Domain.Interfaces;

namespace Lab2.Domain.States;

public class NewState : IItemState
{
    public string DisplayName => "Новый";
    public float EffectivenessMultiplier => 1.0f;

    public void HandleAction(IItem item)
    {
        item.SetState(new UsedState());
    }
}
