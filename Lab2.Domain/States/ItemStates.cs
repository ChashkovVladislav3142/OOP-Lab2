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

public class UsedState : IItemState
{
    public string DisplayName => "Б/У";
    public float EffectivenessMultiplier => 0.8f;

    public void HandleAction(IItem item)
    {
        item.SetState(new BrokenState());
    }
}

public class BrokenState : IItemState
{
    public string DisplayName => "Сломан";
    public float EffectivenessMultiplier => 0.2f;

    public void HandleAction(IItem item)
    {
        
    }
}
