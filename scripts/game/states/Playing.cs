
namespace Godot.Game.FlappyChicken
{

    public partial class Playing : State
    {

        private Game game;

        [Export]
        private State _defeatState;

        public override void Enter()
        {
            game = (Game)Parent;
        }

        public override State ProcessFrame(double delta)
        {
            if (--game.PipeGenerationStart <= 0)
            {
                game.GeneratePipe();
                game.PipeGenerationStart = game.PipeGenerationInterval;
            }
            return null;
        }

        public override State ProcessSignal(string signalName, params Variant[] args)
        {
            if (signalName == "ChickenHitGround")
            {
                return _defeatState;
            }
            return null;
        }

    }
}