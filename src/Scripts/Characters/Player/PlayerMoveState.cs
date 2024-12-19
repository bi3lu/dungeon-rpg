using Godot;
public partial class PlayerMoveState : Node
{
    private Player _characterNode;

    public override void _Ready()
    {
        _characterNode = GetOwner<Player>();
        SetPhysicsProcess(false);
        SetProcessInput(false);
    }

    public override void _PhysicsProcess(double delta)
    {
        if (_characterNode.GetDirection() == Vector2.Zero)
        {
            _characterNode.GetStateMachineNode().SwithcState<PlayerIdleState>();
            return;
        }

        _characterNode.Velocity = new(_characterNode.GetDirection().X, 0, _characterNode.GetDirection().Y);
        _characterNode.Velocity *= 5;
        _characterNode.MoveAndSlide();
        _characterNode.Flip();
    }

    public override void _Notification(int what)
    {
        base._Notification(what);

        if (what == 5001)
        {
            _characterNode.GetAnimationPlayerNode().Play(GameConstants.ANIM_MOVE);
            SetPhysicsProcess(true);
            SetProcessInput(true);

        }
        else if (what == 5002)
        {
            SetPhysicsProcess(false);
            SetProcessInput(false);

        }
    }

    public override void _Input(InputEvent @event)
    {
        if (Input.IsActionJustPressed(GameConstants.ANIM_DASH))
        {
            _characterNode.GetStateMachineNode().SwithcState<PlayerDashState>();
        }
    }
}
