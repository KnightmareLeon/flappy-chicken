using Godot;

public partial class Dead : State
{

    [Export]
    State DefaultState;
    Chicken chicken;
    public override void Enter()
    {
        chicken = (Chicken)Parent;
        chicken.Animations.Play("dying");
        chicken.Rotate(chicken.Tilt);
        chicken.Tilt = 0f;
    }

    public override State ProcessInput(InputEvent inputEvent)
    {
        if (Input.IsActionJustPressed("start"))
        {
            return DefaultState;
        }
        return null;
    }
}