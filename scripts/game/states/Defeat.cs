namespace Godot.Game.FlappyChicken
{
    public partial class Defeat : State
    {
        [Export]
        private State _startState;
        private Game game;

        public override void Enter()
        {
            game = (Game)Parent;
            game.LoadDefeatPanel();
        }
        public override State ProcessInput(InputEvent inputEvent)
        {
            if (Input.IsActionJustPressed("start"))
            {
                return _startState;
            }
            return null;
        }

        public override void Exit()
        {
            game.Score = 0;
        }
    }
}