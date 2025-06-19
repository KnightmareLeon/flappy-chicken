
namespace Godot.Game.FlappyChicken.ScoreStates;
public partial class Tallying : State
{
    private Score _score;
    [Export]
    private State _stoppedState;
    public override void Enter()
    {
        _score = (Score)Parent;
    }

    public override State ProcessSignal(string signalName, params Variant[] args)
    {
        if (signalName == "OnUpdateScore")
        {
            _score.Text = args[0].ToString();
        }
        if (signalName == "ChickenHitGround")
        {
            return _stoppedState;
        }
        return null;
    }

}
