using Godot;

public partial class PlayerIdleState : PlayerState
{
    public override void _PhysicsProcess(double delta)
    {
        if (_characterNode.Direction != Vector2.Zero)
        {
            _characterNode.StateMachineNode.SwitchState<PlayerMoveState>();
        }
    }

    public override void _Input(InputEvent @event)
    {
        if (Input.IsActionJustPressed(GameConstants.INPUT_DASH))
        {
            _characterNode.StateMachineNode.SwitchState<PlayerDashState>();
        }
    }

    protected override void EnterState()
    {
        base.EnterState();
        _characterNode.AnimationPlayerNode.Play(GameConstants.ANIM_IDLE);
    }
}
