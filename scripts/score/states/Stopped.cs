
namespace Godot.Game.FlappyChicken;
public partial class Stopped : State
{
    public override void Enter()
    {
        Score score = (Score)Parent;
        score.Visible = false;
    }
    public override State ProcessInput(InputEvent inputEvent)
    {
        if (Input.IsActionJustPressed("start"))
        {
            Parent.QueueFree();
        }
        return null;
    }
}
