namespace Godot.Game.FlappyChicken;
public partial class Start : State
{

    [Export]
    private State _playingState;
    public override void Enter()
    {
        Game game = (Game) Parent;
        game.ShowStartLabels();
    }
    public override State ProcessInput(InputEvent inputEvent)
    {
        if (Input.IsActionJustPressed("start"))
        {
            return _playingState;
        }
        return null;
    }


}
