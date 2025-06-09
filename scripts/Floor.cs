using Godot;

public partial class Floor : Area2D
{
    private void OnFloorBodyEntered(PhysicsBody2D body)
    {
        Game.state = State.END;
    }
}
