using Godot;

[GlobalClass]
public partial class StateMachine : Node
{

    [Export]
    protected State StartingState;

    protected State CurrentState;

    public void Initialize(Node parent)
    {
        foreach (Node child in GetChildren())
        {
            State state = (State)child;
            state.Parent = parent;
        }

        ChangeState(StartingState);
    }

    public void ChangeState(State newState)
    {
        CurrentState?.Exit();

        CurrentState = newState;
        CurrentState.Enter();
    }

    public void ProcessInput(InputEvent inputEvent)
    {
        State newState = CurrentState.ProcessInput(inputEvent);

        if (newState != null)
        {
            ChangeState(newState);
        }

    }

    public void ProcessPhysics(double delta)
    {
        State newState = CurrentState.ProcessPhysics(delta);

        if (newState != null)
        {
            ChangeState(newState);
        }

    }

    public void ProcessFrame(double delta)
    {
        State newState = CurrentState.ProcessFrame(delta);

        if (newState != null)
        {
            ChangeState(newState);
        }
    }

}