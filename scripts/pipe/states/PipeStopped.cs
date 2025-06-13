using Godot;

public partial class PipeStopped : State
{

    Pipe pipe;

    public override void Enter()
    {
        pipe = (Pipe)Parent;
    }
    public override State ProcessInput(InputEvent inputEvent)
    {
        if (Input.IsActionJustPressed("start"))
        {
            pipe.QueueFree();
        }
        return null;
    }
}