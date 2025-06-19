namespace Godot.Game.FlappyChicken;
public partial class Score : Label
{

    [Export]
    StateMachine _stateMachine;

    public override void _UnhandledInput(InputEvent @event)
    {
        _stateMachine.ProcessInput(@event);
    }

    public void OnUpdateScore(int score)
    {
        _stateMachine.ProcessSignal("OnUpdateScore", score);
    }

    public void ChickenHitGround(Node2D body)
    {
        _stateMachine.ProcessSignal("ChickenHitGround", body);
    }
}
