namespace Godot.Game
{

    public partial class Default : ChickenState
    {
        [Export]
        private State fallingState;
        [Export]
        private AnimatedSprite2D animations;
        public override void Enter()
        {
            base.Enter();
            animations.Play("default");
            Chicken.Position = new Vector2(256, 384);

        }
        public override State ProcessInput(InputEvent inputEvent)
        {
            if (Input.IsActionJustPressed("start"))
            {
                return fallingState;
            }
            return null;
        }

    }
}