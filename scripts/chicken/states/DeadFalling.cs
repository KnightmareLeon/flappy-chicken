namespace Godot.Game.FlappyChicken.ChickenStates
{
    public partial class DeadFalling : ChickenState
    {
        [Export]
        private AnimatedSprite2D _animations;
        [Export]
        private State _deadState;
        public override void Enter()
        {
            base.Enter();
            _animations.Play("dead_falling");
        }

        public override State ProcessPhysics(double delta)
        {
            Chicken.Velocity = Vector2.Down * Chicken.Speed;
            Chicken.Rotate(Chicken.TILT_DEGREE);
            Chicken.Tilt -= Chicken.TILT_DEGREE;
            Chicken.MoveAndSlide();
            return null;
        }

        public override State ProcessSignal(string signalName, params Variant[] args)
        {
            if (signalName == "OnHittingGround")
            {
                return _deadState;
            }
            return null;
        }

    }
}