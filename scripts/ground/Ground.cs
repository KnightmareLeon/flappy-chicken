namespace Godot.Game.FlappyChicken
{
    public partial class Ground : Area2D
    {
        [Export]
        private StateMachine _stateMachine;

        public override void _UnhandledInput(InputEvent @event)
        {
            _stateMachine.ProcessInput(@event);
        }

        public override void _Process(double delta)
        {
            _stateMachine.ProcessFrame(delta);
        }

        private void OnBodyEntered(Node2D body)
        {
            _stateMachine.ProcessSignal("OnBodyEntered", body);
        }
    }
}