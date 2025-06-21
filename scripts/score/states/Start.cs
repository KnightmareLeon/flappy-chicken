namespace Godot.Game.FlappyChicken.ScoreStates;

public partial class Start : State
{
    private Score _score;
    [Export]
    private State _tallyingState;
    public override void Enter()
    {
        _score = (Score)Parent;
        _score.Visible = false;
    }

        public override State ProcessInput(InputEvent inputEvent)
    {
        if (Input.IsActionJustPressed("start"))
        {
            return _tallyingState;
        }
        return null;
    }
}
