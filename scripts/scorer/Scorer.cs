using Godot;

public partial class Scorer : Area2D
{
    public StateMachine StateMachine;
    [Export]
    State StoppedState;
    public override void _Ready()
    {
        StateMachine = (StateMachine)GetNode<Node>("StateMachine");
        StateMachine.Initialize(this);
    }

    public override void _Process(double delta)
    {
        StateMachine.ProcessFrame(delta);
    }

    public override void _UnhandledInput(InputEvent @event)
    {
        StateMachine.ProcessInput(@event);
    }


    public void ChickenEnteredGround(Node2D body)
    {
        StateMachine.ChangeState(StoppedState);
    }
}
