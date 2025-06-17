namespace Godot.Game.FlappyChicken.ChickenStates
{
    public partial class Dead : ChickenState
    {

        [Export]
        private State _defaultState;
        [Export]
        private AnimatedSprite2D _animations;
        public override void Enter()
        {
            base.Enter();
            _animations.Play("dying");
            Chicken.Rotate(Chicken.Tilt);
            Chicken.Tilt = 0f;
        }

        public override State ProcessInput(InputEvent inputEvent)
        {
            if (Input.IsActionJustPressed("start"))
            {
                return _defaultState;
            }
            return null;
        }

    }
}