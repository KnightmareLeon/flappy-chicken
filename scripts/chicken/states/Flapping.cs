using Godot;

public partial class Flapping : State
{

    [Export]
    State FallingState;
    Chicken chicken;
    public override void Enter()
    {
        chicken = (Chicken)Parent;
        chicken.FlapTimer = 10;
    }

    public override State ProcessInput(InputEvent inputEvent)
    {
        if (Input.IsActionJustPressed("flap")) { chicken.FlapTimer = 10; }
        return null;
    }
    public override State ProcessPhysics(double delta)
    {

        if (chicken.FlapTimer-- > 0)
        {
            chicken.Velocity = Vector2.Up * chicken.Speed;
            if (chicken.Tilt < 0.785398f) // 45 degrees
            {
                chicken.Rotate(-Chicken.TILT_DEGREE * 3);
                chicken.Tilt += Chicken.TILT_DEGREE * 3;
            }
            chicken.MoveAndSlide();
        }
        else
        {
            return FallingState;
        }
        return null;
    }
}