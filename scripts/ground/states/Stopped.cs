using Godot;

public partial class Stopped : State
{
    [Export]
    State MovingState;
    public override State ProcessInput(InputEvent inputEvent)
    {
        if (Input.IsActionJustPressed("start"))
        {
            return MovingState;
        }
        return null;
    }
}