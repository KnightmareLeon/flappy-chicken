namespace Godot.Game
{
    public partial class Dead : ChickenState
    {

        [Export]
        private State defaultState;
        [Export]
        private AnimatedSprite2D animations;
        public override void Enter()
        {
            base.Enter();
            animations.Play("dying");
            Chicken.Rotate(Chicken.Tilt);
            Chicken.Tilt = 0f;
        }

        public override State ProcessInput(InputEvent inputEvent)
        {
            if (Input.IsActionJustPressed("start"))
            {
                return defaultState;
            }
            return null;
        }

    }
}