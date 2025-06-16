using Godot;

public partial class Chicken : CharacterBody2D
{
	[Export]
	public int Speed { get; set; } = 320;
	public int FlapTimer = 0;

	public float Tilt { get; set; } = 0f;
	public const float TILT_DEGREE = 0.0872665f;

	[Export]
	private StateMachine _stateMachine;
	[Export]
	private State DeadState;
	[Export]
	private State DeadFallingState;

	public override void _UnhandledInput(InputEvent @event)
	{
		_stateMachine.ProcessInput(@event);
	}

	public override void _PhysicsProcess(double delta)
	{

		_stateMachine.ProcessPhysics(delta);

	}

	public void OnEnteringGround(Node2D body)
	{
		_stateMachine.ChangeState(DeadState);
	}

	public void OnEnteringPipe(Node2D body)
	{
		_stateMachine.ChangeState(DeadFallingState);
	}

}
