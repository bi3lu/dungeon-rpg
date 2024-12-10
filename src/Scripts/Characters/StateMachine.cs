using Godot;
public partial class StateMachine : Node
{
    [Export] private Node _currentState;
    [Export] private Node[] _states;

    public override void _Ready()
    {
        _currentState.Notification(5001);
    }

    public void SwithcState<T>()
    {
        Node newState = null;

        foreach (var state in _states)
        {
            if (state is T)
            {
                newState = state;
            }
        }

        if (newState is null)
        {
            return;
        }

        _currentState = newState;
        _currentState.Notification(5001);
    }
}
