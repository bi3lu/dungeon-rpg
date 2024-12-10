using Godot;
public partial class PlayerIdleState : Node
{
    private Player _characterNode;

    public override void _Ready()
    {
        _characterNode = GetOwner<Player>();
    }

    public override void _PhysicsProcess(double delta)
    {
        if (_characterNode.GetDirection() != Vector2.Zero)
        {
            _characterNode.GetStateMachineNode().SwithcState<PlayerMoveState>();
        }
    }

    public override void _Notification(int what)
    {
        base._Notification(what);

        if (what == 5001)
        {
            _characterNode.GetAnimationPlayerNode().Play(GameConstants.ANIM_IDLE);
        }
    }
}
