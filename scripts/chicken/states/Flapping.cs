namespace Godot.Game
{
    public partial class Flapping : ChickenState
    {

        [Export]
        private State fallingState;
        public override void Enter()
        {
            base.Enter();
            Chicken.FlapTimer = 10;
        }

        public override State ProcessInput(InputEvent inputEvent)
        {
            if (Input.IsActionJustPressed("flap"))
            {
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
                return fallingState;
            }
            return null;
        }
    }
}