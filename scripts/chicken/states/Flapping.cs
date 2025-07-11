namespace Godot.Game.FlappyChicken.ChickenStates;
public partial class Flapping : ChickenState
{

    [Export]
    private State _fallingState;
    [Export]
    private State _deadState;
    [Export]
    private State _deadFallingState;
    public override void Enter()
    {
        base.Enter();
        Chicken.FlapTimer = 10;
    }

    public override State ProcessInput(InputEvent inputEvent)
    {
        if (Input.IsActionJustPressed("flap") && Chicken.Position.Y >= -63)
        {
            Chicken.PlaySoundEffect("res://assets/sounds/flap.wav");
            Chicken.FlapTimer = 10;
        }
        return null;
    }
    public override State ProcessPhysics(double delta)
    {

        if (Chicken.FlapTimer-- > 0)
        {
            Chicken.Velocity = Vector2.Up * Chicken.Speed;
            if (Chicken.Tilt < 0.785398f) // 45 degrees
            {
                Chicken.Rotate(-Chicken.TILT_DEGREE * 3);
                Chicken.Tilt += Chicken.TILT_DEGREE * 3;
            }
            Chicken.MoveAndSlide();
        }
        else
        {
            return _fallingState;
        }
        return null;
    }
    public override State ProcessSignal(string signalName, params Variant[] args)
    {
        if (signalName == "OnHittingGround")
        {
            Chicken.PlaySoundEffect("res://assets/sounds/die.wav");
            return _deadState;
        }
        if (signalName == "OnHittingPipe")
        {
            Chicken.PlaySoundEffect("res://assets/sounds/hit.wav");
            return _deadFallingState;
        }
        if (signalName == "OnEnteringScorer")
        {
            Chicken.PlayPointSoundEffect();
            Chicken.EmitSignal(nameof(Chicken.ChickenScored));
        }
        return null;
    }
}
