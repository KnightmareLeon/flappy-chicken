using System.Linq;

namespace Godot.Game;

[GlobalClass]
public partial class StateMachine : Node
{

    [Export]
    protected State StartingState { get; set; }

    protected State CurrentState { get; set; }

    public override void _Ready()
    {
        Node parent = GetParent<Node>();
        foreach (State child in GetChildren().Cast<State>())
        {
            child.Parent = parent;
        }
        ChangeState(StartingState);
    }

    public void ChangeState(State newState)
    {
        CurrentState?.Exit();

        CurrentState = newState ?? CurrentState;
        if (newState != null)
        {
            CurrentState.Enter();
        }

    }

    public void ProcessInput(InputEvent inputEvent)
    {
        State newState = CurrentState.ProcessInput(inputEvent);

        ChangeState(newState);

    }

    public void ProcessPhysics(double delta)
    {
        State newState = CurrentState.ProcessPhysics(delta);

        ChangeState(newState);

    }

    public void ProcessFrame(double delta)
    {
        State newState = CurrentState.ProcessFrame(delta);

        ChangeState(newState);
    }

    public void ProcessSignal(string signalName, params Variant[] args)
    {
        State newState = CurrentState.ProcessSignal(signalName, args);

        ChangeState(newState);
    }

}