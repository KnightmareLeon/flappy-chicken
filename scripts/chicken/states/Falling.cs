namespace Godot.Game.FlappyChicken.ChickenStates;
public partial class Falling : ChickenState
{

    [Export]
    private State _flappingState;
    [Export]
    private State _deadState;
    [Export]
    private State _deadFallingState;

    public override State ProcessInput(InputEvent inputEvent)
    {
        if (Input.IsActionJustPressed("flap") && Chicken.Position.Y >= -63)
        {
            Chicken.PlaySoundEffect("res://assets/sounds/flap.wav");
            return _flappingState;
        }
        return null;
    }
    public override State ProcessPhysics(double delta)
    {
        Chicken.Velocity = Vector2.Down * Chicken.Speed;
        if (Chicken.Tilt > -1.5708f) // 90 degrees
        {
            Chicken.Rotate(Chicken.TILT_DEGREE);
            Chicken.Tilt -= Chicken.TILT_DEGREE;
        }
        Chicken.MoveAndSlide();
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