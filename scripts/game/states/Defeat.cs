using Godot;

public partial class Defeat : State
{
    [Export]
    State StartState;
    public override State ProcessInput(InputEvent inputEvent)
    {
        if (Input.IsActionJustPressed("start"))
        {
            return StartState;
        }
        return null;
    }
}