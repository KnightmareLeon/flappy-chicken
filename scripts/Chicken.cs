using Godot;

public partial class Chicken : CharacterBody2D
{
	[Export]
	public int Speed { get; set; } = 200;
	private int FlapTimer = 0;

	private float Tilt = 0f;
	private const float TILT_DEGREE = 0.0872665f;
	
	private Vector2 FallDirection { get; set; } = new Vector2(0, 1);
	private Vector2 FlapDirection { get; set; } = new Vector2(0,-1);
	
	public override void _PhysicsProcess(double delta)
	{
		if (Input.IsActionJustPressed("up")) { FlapTimer = 10; }
		if (FlapTimer-- > 0)
		{
			Velocity = FlapDirection * Speed * 3;
			if (Tilt < 0.785398f) // 45 degrees
			{
				Rotate(-TILT_DEGREE * 3);
				Tilt += TILT_DEGREE * 3;
			}
		}
		else
		{
			Velocity = FallDirection * Speed;
			if (Tilt > -1.5708f) // 90 degrees
			{
				Rotate(TILT_DEGREE);
				Tilt -= TILT_DEGREE;
			}
		}
		MoveAndSlide();

	}
}
