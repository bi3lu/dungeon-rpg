using Godot;

public partial class PlayerDashState : PlayerState
{
    [Export] private Timer _dashTimerNode;
    [Export] private float _speed = 20f;

    public override void _Ready()
    {
        base._Ready();
        _dashTimerNode.Timeout += HandleDashTimeout;
    }

    public override void _PhysicsProcess(double delta)
    {
        _characterNode.MoveAndSlide();
        _characterNode.Flip();
    }

    protected override void EnterState()
    {

        _characterNode.AnimationPlayerNode.Play(GameConstants.ANIM_DASH);
        _characterNode.Velocity = new(_characterNode.Direction.X, 0, _characterNode.Direction.Y);

        if (_characterNode.Velocity == Vector3.Zero)
        {
            _characterNode.Velocity = _characterNode.SprideNode.FlipH ? Vector3.Left : Vector3.Right;
        }

        _characterNode.Velocity *= _speed;
        _dashTimerNode.Start();

    }

    private void HandleDashTimeout()
    {
        _characterNode.Velocity = Vector3.Zero;
        _characterNode.StateMachineNode.SwitchState<PlayerIdleState>();
    }
}
