namespace Godot.Game.FlappyChicken.ScorerStates
{
    public partial class Moving : State
    {
        [Export]
        private Component.AreaMovementComponent _areaMovementComponent;
        [Export]
        private State _stoppedState;
        public override State ProcessFrame(double delta)
        {
            Vector2 position = _areaMovementComponent.Move();
            if (position.X <= -48)
            {
                Parent.QueueFree();
            }
            return null;
        }

        public override State ProcessSignal(string signalName, params Variant[] args)
        {
            if (signalName == "ChickenHitGround")
            {
                return _stoppedState;
            }
            return null;
        }

    }
}
