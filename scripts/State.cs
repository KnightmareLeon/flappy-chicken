using Godot;

public partial class State : Node
{

    public Node Parent;

    public virtual void Enter()
    {

    }
    public virtual void Exit()
    {

    }

    public virtual State ProcessPhysics(double delta)
    {
        return null;
    }

    public virtual State ProcessInput(InputEvent inputEvent)
    {
        return null;
    }

    public virtual State ProcessFrame(double delta)
    {
        return null;
    }
}