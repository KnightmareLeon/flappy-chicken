namespace Godot.Game
{
    public partial class Falling : ChickenState
    {

        [Export]
        private State flappingState;

        public override State ProcessInput(InputEvent inputEvent)
        {
            if (Input.IsActionJustPressed("flap"))
            {
                return flappingState;
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
    }
}