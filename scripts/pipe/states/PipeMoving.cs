using Godot;

public partial class PipeMoving : State
{

    Pipe pipe;
    public override void Enter()
    {
        pipe = (Pipe)Parent;
    }
    public override State ProcessFrame(double delta)
    {
        Vector2 pos = pipe.Position;
        pos.X -= 4;
        pipe.Position = pos;
        if (pos.X <= -48)
        {
            pipe.QueueFree();
        }
        return null;
    }
}