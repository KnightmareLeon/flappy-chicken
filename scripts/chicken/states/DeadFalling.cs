namespace Godot.Game
{
    public partial class DeadFalling : ChickenState
    {
        [Export]
        private AnimatedSprite2D animations;
        public override void Enter()
        {
            base.Enter();
            animations.Play("dead_falling");
        }

        public override State ProcessPhysics(double delta)
        {
            Chicken.Velocity = Vector2.Down * Chicken.Speed;
            Chicken.Rotate(Chicken.TILT_DEGREE);
            Chicken.Tilt -= Chicken.TILT_DEGREE;
            Chicken.MoveAndSlide();
            return null;
        }

    }
}