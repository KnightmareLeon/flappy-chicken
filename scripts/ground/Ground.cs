namespace Godot.Game
{
    public partial class Ground : Area2D
    {
        [Export]
        private StateMachine _stateMachine;

        [Export]
        private State stoppedState;

        private void OnBodyEntered(Node2D body)
        {
            _stateMachine.ChangeState(stoppedState);
        }

        public override void _UnhandledInput(InputEvent @event)
        {
            _stateMachine.ProcessInput(@event);
        }

        public override void _Process(double delta)
        {
            _stateMachine.ProcessFrame(delta);
        }

    }
}