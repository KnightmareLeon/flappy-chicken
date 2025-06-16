namespace Godot.Game
{

    public partial class Start : State
    {

        [Export]
        private State playingState;

        Game game;
        public override void Enter()
        {
            game = (Game)Parent;
        }
        public override State ProcessInput(InputEvent inputEvent)
        {
            if (Input.IsActionJustPressed("start"))
            {
                return playingState;
            }
            return null;
        }


    }
}