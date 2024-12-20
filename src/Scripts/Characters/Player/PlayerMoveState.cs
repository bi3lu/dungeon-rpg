using Godot;

public partial class PlayerMoveState : PlayerState
{
    public override void _PhysicsProcess(double delta)
    {
        if (_characterNode.Direction == Vector2.Zero)
        {
            _characterNode.StateMachineNode.SwitchState<PlayerIdleState>();
            return;
        }

        _characterNode.Velocity = new(_characterNode.Direction.X, 0, _characterNode.Direction.Y);
        _characterNode.Velocity *= 5;
        _characterNode.MoveAndSlide();
        _characterNode.Flip();
    }

    public override void _Input(InputEvent @event)
    {
        if (Input.IsActionJustPressed(GameConstants.ANIM_DASH))
        {
            _characterNode.StateMachineNode.SwitchState<PlayerDashState>();
        }
    }

    protected override void EnterState()
    {
        base.EnterState();
        _characterNode.AnimationPlayerNode.Play(GameConstants.ANIM_MOVE);
    }
}
