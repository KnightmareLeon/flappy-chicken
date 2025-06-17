namespace Godot.Game.FlappyChicken.GroundStates
{
    public partial class Stopped : State
    {
        [Export]
        private State _movingState;
        public override State ProcessInput(InputEvent inputEvent)
        {
            if (Input.IsActionJustPressed("start"))
            {
                return _movingState;
            }
            return null;
        }
    }
}