using Godot;

public partial class Stopped : State
{
    [Export]
    private State movingState;
    public override State ProcessInput(InputEvent inputEvent)
    {
        if (Input.IsActionJustPressed("start"))
        {
            return movingState;
        }
        return null;
    }
}