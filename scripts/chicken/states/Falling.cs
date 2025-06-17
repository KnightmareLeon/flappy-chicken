namespace Godot.Game.FlappyChicken.ChickenStates
{
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
            if (Input.IsActionJustPressed("flap"))
            {
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
                return _deadState;
            }
            if (signalName == "OnHittingPipe")
            {
                return _deadFallingState;
            }
            if (signalName == "OnEnteringScorer")
            {
                Chicken.EmitSignal(nameof(Chicken.ChickenScored));
            }
            return null;
        }
    }
}