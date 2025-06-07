using Godot;

public partial class Chicken : CharacterBody2D
{
	[Export]
	public int Speed { get; set; } = 100;
	private Vector2 FallDirection { get; set; } = new Vector2(0,1);
	private Vector2 FlapDirection { get; set; } = new Vector2(0,-1);
	private int FlapTimer = 0;
	private float Tilt = 0f;
	private const float TiltDegree = 0.0872665f;
	public override void _PhysicsProcess(double delta)
	{
		if (Input.IsActionJustPressed("up")) { FlapTimer = 10; }
		if (FlapTimer-- > 0)
		{
			Velocity = FlapDirection * Speed * 2;
			if (Tilt < 0.785398f) // 45 degrees
			{
				Rotate(-TiltDegree * 2);
				Tilt += TiltDegree * 2;
			}
		}
		else
		{
			Velocity = FallDirection * Speed;
			if (Tilt > -1.5708f) // 90 degrees
			{
				Rotate(TiltDegree);
				Tilt -= TiltDegree;
			}
		}
		MoveAndSlide();

	}
}
