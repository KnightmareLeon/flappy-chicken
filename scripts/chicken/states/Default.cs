using Godot;

public partial class Default : State
{
    [Export]
    State FallingState;
    public override void Enter()
    {
        Chicken parent = (Chicken)Parent;
        parent.Animations.Play("default");
        parent.Position = new Vector2(384, 384);

    }
    public override State ProcessInput(InputEvent inputEvent)
    {
        if (Input.IsActionJustPressed("start"))
        {
            return FallingState;
        }
        return null;
    }
}