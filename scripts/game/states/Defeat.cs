namespace Godot.Game
{
    public partial class Defeat : State
    {
        [Export]
        private State startState;
        public override State ProcessInput(InputEvent inputEvent)
        {
            if (Input.IsActionJustPressed("start"))
            {
                return startState;
            }
            return null;
        }
    }
}