using Godot;

public partial class Moving : State
{

    Ground ground;
    public override void Enter()
    {
        ground = (Ground)Parent;
    }
    public override State ProcessFrame(double delta)
    {
        Vector2 pos = ground.Position;
        pos.X -= 4;
        if (pos.X < 353)
        {
            pos.X = 448;
        }
        ground.Position = pos;
        return null;
    }
}