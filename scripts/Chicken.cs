using Godot;

public partial class Chicken : CharacterBody2D
{
	[Export]
	private int Speed { get; set; } = 300;
	private int FlapTimer = 0;

	public float Tilt { get; set; } = 0f;
	private const float TILT_DEGREE = 0.0872665f;
	
	public override void _PhysicsProcess(double delta)
	{
		if (Game.state == State.PLAY)
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
		

	}
}
