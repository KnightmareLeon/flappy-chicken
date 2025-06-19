namespace Godot.Game.FlappyChicken;
public partial class Start : State
{

    [Export]
    private State _playingState;
    public override State ProcessInput(InputEvent inputEvent)
    {
        if (Input.IsActionJustPressed("start"))
        {
            return _playingState;
        }
        return null;
    }


}
