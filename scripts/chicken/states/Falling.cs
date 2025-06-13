using Godot;

public partial class Falling : State
{

    [Export]
    State FlappingState;
    Chicken chicken;
    
    public override void Enter()
    {
        chicken = (Chicken)Parent;
    }

    public override State ProcessInput(InputEvent inputEvent)
    {
        if (Input.IsActionJustPressed("flap"))
        {
            return FlappingState;
        }
        return null;
    }
    public override State ProcessPhysics(double delta)
    {
        chicken.Velocity = Vector2.Down * chicken.Speed;
        if (chicken.Tilt > -1.5708f) // 90 degrees
        {
            chicken.Rotate(Chicken.TILT_DEGREE);
            chicken.Tilt -= Chicken.TILT_DEGREE;
        }
        chicken.MoveAndSlide();
        return null;
    }
}