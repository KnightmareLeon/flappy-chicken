using Godot;

public partial class Pipe : Area2D
{
    public override void _Process(double delta)
    {
        base._Process(delta);
        Vector2 pos = Position;
        pos.X -= 4;
        Position = pos;
        if (pos.X <= -48)
        {
            QueueFree();
        }

    }
}
