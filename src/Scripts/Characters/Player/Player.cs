using Godot;

public partial class Player : CharacterBody3D
{
    [ExportGroup("Required Nodes")]
    [Export] private AnimationPlayer _animationPlayerNode;
    [Export] private Sprite3D _spriteNode;
    [Export] private StateMachine _stateMachineNode;

    private Vector2 _direction = new();

    public AnimationPlayer AnimationPlayerNode { get => _animationPlayerNode; }
    public Sprite3D SprideNode { get => _spriteNode; }
    public StateMachine StateMachineNode { get => _stateMachineNode; }
    public Vector2 Direction { get => _direction; }

    public override void _Input(InputEvent @event)
    {
        _direction = Input.GetVector(GameConstants.INPUT_MOVE_LEFT, GameConstants.INPUT_MOVE_RIGHT,
            GameConstants.INPUT_MOVE_FORWARD, GameConstants.INPUT_MOVE_BACKWARD);
    }

    public void Flip()
    {
        var isNotMovingHorizontally = Velocity.X == 0;

        if (isNotMovingHorizontally)
        {
            return;
        }

        _spriteNode.FlipH = Velocity.X < 0;
    }
}
