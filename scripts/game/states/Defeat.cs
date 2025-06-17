namespace Godot.Game.FlappyChicken
{
    public partial class Defeat : State
    {
        [Export]
        private State _startState;
        public override State ProcessInput(InputEvent inputEvent)
        {
            if (Input.IsActionJustPressed("start"))
            {
                return _startState;
            }
            return null;
        }
    }
}