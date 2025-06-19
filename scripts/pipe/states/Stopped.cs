namespace Godot.Game.FlappyChicken.PipeStates;
public partial class Stopped : State
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