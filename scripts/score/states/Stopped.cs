namespace Godot.Game.FlappyChicken;

public partial class Stopped : State
{
    private Score _score;
    [Export]
    private State _startState;
    public override void Enter()
    {
        _score = (Score)Parent;
        _score.Visible = false;
        _score.Text = "0";
    }
    public override State ProcessInput(InputEvent inputEvent)
    {
        if (Input.IsActionJustPressed("start"))
        {
            return _startState; 
        }
        return null;
    }
}
