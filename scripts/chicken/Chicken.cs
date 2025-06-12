using Godot;

public partial class Chicken : CharacterBody2D
{
	[Export]
	public int Speed { get; set; } = 300;
	public int FlapTimer = 0;

	public float Tilt { get; set; } = 0f;
	public const float TILT_DEGREE = 0.0872665f;

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
		/*
		if (Game.gameState == GameState.PLAY)
		{
			if (Input.IsActionJustPressed("flap")) { FlapTimer = 10; }
			if (FlapTimer-- > 0)
			{
				Velocity = Vector2.Up * Speed * 3;
				if (Tilt < 0.785398f) // 45 degrees
				{
					Rotate(-TILT_DEGREE * 3);
					Tilt += TILT_DEGREE * 3;
				}
			}
			else
			{
				Velocity = Vector2.Down * Speed;
				if (Tilt > -1.5708f) // 90 degrees
				{
					Rotate(TILT_DEGREE);
					Tilt -= TILT_DEGREE;
				}
			}
			MoveAndSlide();
		}
		*/
		StateMachine.ProcessPhysics(delta);

	}

}
