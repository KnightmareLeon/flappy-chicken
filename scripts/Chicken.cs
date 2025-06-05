using Godot;
using System;

public partial class Chicken : CharacterBody2D
{
	[Export]
	public int Speed { get; set; } = 50;
	private Vector2 FallDirection { get; set; } = new Vector2(0,1);
	public void GetInput()
	{

		Vector2 inputDirection = Input.GetVector("left", "right", "up", "down");
		Velocity = inputDirection * Speed * 10;
	}

	public override void _PhysicsProcess(double delta)
	{
		GetInput();
		MoveAndSlide();
		Velocity = FallDirection * Speed;
		MoveAndSlide();
	}
}
