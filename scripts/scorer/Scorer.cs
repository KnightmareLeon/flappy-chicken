namespace Godot.Game.FlappyChicken
{

    public partial class Scorer : Area2D
    {
        [Export]
        private StateMachine _stateMachine;

        public override void _Process(double delta)
        {
            _stateMachine.ProcessFrame(delta);
        }

        public override void _UnhandledInput(InputEvent @event)
        {
            _stateMachine.ProcessInput(@event);
        }


        public void ChickenHitGround(Node2D body)
        {
            _stateMachine.ProcessSignal("ChickenHitGround", body);
        }

    }
}
