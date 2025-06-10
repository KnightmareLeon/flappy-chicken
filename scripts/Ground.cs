using Godot;

public partial class Ground : Area2D
{
    private void OnFloorBodyEntered(PhysicsBody2D body)
    {
        Game.state = State.END;
    }

    public override void _Process(double delta)
    {
        if (Game.state != State.END)
        {
            base._Process(delta);
            Vector2 pos = Position;
            pos.X -= 4;
            if (pos.X < 353)
            {
                pos.X = 448;
            }
            Position = pos;
        }
        

    }

}
