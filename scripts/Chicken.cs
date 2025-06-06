using Godot;

public partial class Chicken : CharacterBody2D
{
	[Export]
	public int Speed { get; set; } = 100;
	private Vector2 FallDirection { get; set; } = new Vector2(0,1);
	private Vector2 FlapDirection { get; set; } = new Vector2(0,-1);
	private int FlapTimer = 0;

	public override void _PhysicsProcess(double delta)
	{
		if (Input.IsActionJustPressed("up")){FlapTimer = 10;}

		Velocity = (FlapTimer-- > 0) ? FlapDirection * Speed * 2 : FallDirection * Speed;
		MoveAndSlide();

	}
}
