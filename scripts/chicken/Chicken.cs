namespace Godot.Game.FlappyChicken;
public partial class Chicken : CharacterBody2D
{
	[Export]
	public int Speed { get; set; } = 320;
	public int FlapTimer { get; set; } = 0;

	public float Tilt { get; set; } = 0f;
	public const float TILT_DEGREE = 0.0872665f;
	[Signal]
	public delegate void ChickenScoredEventHandler();
	[Export]
	private StateMachine _stateMachine;
	[Export]
	private AudioStreamPlayer _soundEffectPlayer;
	[Export]
	private AudioStreamPlayer _pointSoundEffectPlayer; 

	public override void _UnhandledInput(InputEvent @event)
	{
		_stateMachine.ProcessInput(@event);
	}

	public override void _PhysicsProcess(double delta)
	{

		_stateMachine.ProcessPhysics(delta);

	}

	public void PlaySoundEffect(string path)
	{
		AudioStream soundEffect = GD.Load<AudioStream>(path);

		_soundEffectPlayer.Stream = soundEffect;
		_soundEffectPlayer.Play();
	}

	public void PlayPointSoundEffect()
	{
		_pointSoundEffectPlayer.Play();
	}

	public void OnHittingGround(Node2D body)
	{
		_stateMachine.ProcessSignal("OnHittingGround", body);
	}

	public void OnHittingPipe(Node2D body)
	{
		_stateMachine.ProcessSignal("OnHittingPipe", body);
	}

	public void OnEnteringScorer(Node2D body)
	{
		_stateMachine.ProcessSignal("OnEnteringScorer", body);
	}

}
