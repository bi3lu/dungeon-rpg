using Godot;
public partial class Player : CharacterBody3D
{
    [ExportGroup("Required Nodes")]
    [Export] private AnimationPlayer _animationPlayerNode;
    [Export] private Sprite3D _spriteNode;
    [Export] private StateMachine _stateMachineNode;

    private Vector2 _direction = new();

    public override void _PhysicsProcess(double delta)
    {
        Velocity = new(_direction.X, 0, _direction.Y);
        Velocity *= 5;
        MoveAndSlide();
        Flip();
    }

    public override void _Input(InputEvent @event)
    {
        _direction = Input.GetVector(GameConstants.INPUT_MOVE_LEFT, GameConstants.INPUT_MOVE_RIGHT,
            GameConstants.INPUT_MOVE_FORWARD, GameConstants.INPUT_MOVE_BACKWARD);
    }

    public AnimationPlayer GetAnimationPlayerNode()
        => _animationPlayerNode;

    public Sprite3D GetSpriteNode()
        => _spriteNode;

    public Vector2 GetDirection()
        => _direction;

    public StateMachine GetStateMachineNode()
        => _stateMachineNode;

    private void Flip()
    {
        var isNotMovingHorizontally = Velocity.X == 0;

        if (isNotMovingHorizontally)
        {
            return;
        }

        _spriteNode.FlipH = Velocity.X < 0;
    }
}
