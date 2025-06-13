using Godot;

public partial class DeadFalling : State
{

    Chicken chicken;
    public override void Enter()
    {
        chicken = (Chicken)Parent;
        chicken.Animations.Play("dead_falling");
    }

    public override State ProcessPhysics(double delta)
    {
        chicken.Velocity = Vector2.Down * chicken.Speed;
        chicken.Rotate(Chicken.TILT_DEGREE);
        chicken.Tilt -= Chicken.TILT_DEGREE;
        chicken.MoveAndSlide();
        return null;
    }

}