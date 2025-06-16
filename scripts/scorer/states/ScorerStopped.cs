using Godot;

public partial class ScorerStopped : State
{
    public override State ProcessInput(InputEvent inputEvent)
    {
        if (Input.IsActionJustPressed("start"))
        {
            Parent.QueueFree();
        }
        return null;
    }
}
