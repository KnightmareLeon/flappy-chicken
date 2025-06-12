using Godot;

public partial class Chicken : CharacterBody2D
{
	[Export]
	public int Speed { get; set; } = 300;
	public int FlapTimer = 0;

	public float Tilt { get; set; } = 0f;
	public const float TILT_DEGREE = 0.0872665f;

	[Export]
	private State DeadState;
	public AnimatedSprite2D Animations;
	public StateMachine StateMachine;
	public override void _Ready()
	{
		Animations = GetNode<AnimatedSprite2D>("Animations");
		StateMachine = (StateMachine)GetNode<Node>("StateMachine");
		StateMachine.Initialize(this);
	}

	public override void _UnhandledInput(InputEvent @event)
	{
		StateMachine.ProcessInput(@event);
	}

	public override void _PhysicsProcess(double delta)
	{

		StateMachine.ProcessPhysics(delta);

	}

	public void OnEnteringGround(Node2D body)
	{
		StateMachine.ChangeState(DeadState);
	}

}
