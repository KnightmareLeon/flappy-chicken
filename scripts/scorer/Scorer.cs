namespace Godot.Game
{

    public partial class Scorer : Area2D
    {
        [Export]
        private StateMachine _stateMachine;
        [Export]
        private State stoppedState;

        public override void _Process(double delta)
        {
            _stateMachine.ProcessFrame(delta);
        }

        public override void _UnhandledInput(InputEvent @event)
        {
            _stateMachine.ProcessInput(@event);
        }


        public void ChickenEnteredGround(Node2D body)
        {
            _stateMachine.ChangeState(stoppedState);
        }

    }
}
