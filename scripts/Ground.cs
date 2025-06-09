using Godot;

public partial class Ground : Area2D
{
    private void OnFloorBodyEntered(PhysicsBody2D body)
    {
        Game.state = State.END;
    }

    public override void _Process(double delta)
    {
        base._Process(delta);
    }

}
