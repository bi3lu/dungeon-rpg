using Godot;
public partial class PlayerDashState : Node
{
    private Player _characterNode;

    [Export] private Timer _dashTimerNode;
    [Export] private float _speed = 20f;

    public override void _Ready()
    {
        _characterNode = GetOwner<Player>();
        _dashTimerNode.Timeout += HandleDashTimeout;
    }

    public override void _PhysicsProcess(double delta)
    {
        _characterNode.MoveAndSlide();
        _characterNode.Flip();
    }

    public override void _Notification(int what)
    {
        base._Notification(what);

        if (what == 5001)
        {
            _characterNode.GetAnimationPlayerNode().Play(GameConstants.ANIM_DASH);
            _characterNode.Velocity = new(_characterNode.GetDirection().X, 0, _characterNode.GetDirection().Y);

            if (_characterNode.Velocity == Vector3.Zero)
            {
                _characterNode.Velocity = _characterNode.GetSpriteNode().FlipH ? Vector3.Left : Vector3.Right;
            }

            _characterNode.Velocity *= _speed;
            _dashTimerNode.Start();
        }
    }

    private void HandleDashTimeout()
    {
        _characterNode.Velocity = Vector3.Zero;
        _characterNode.GetStateMachineNode().SwithcState<PlayerIdleState>();
    }
}
