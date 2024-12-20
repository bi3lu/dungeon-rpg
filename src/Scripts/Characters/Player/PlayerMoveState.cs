using Godot;

public partial class PlayerMoveState : PlayerState
{
    [Export(PropertyHint.Range, "0,15,0.1")] private float _speed = 5f;

    public override void _PhysicsProcess(double delta)
    {
        if (_characterNode.Direction == Vector2.Zero)
        {
            _characterNode.StateMachineNode.SwitchState<PlayerIdleState>();
            return;
        }

        _characterNode.Velocity = new(_characterNode.Direction.X, 0, _characterNode.Direction.Y);
        _characterNode.Velocity *= _speed;
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
