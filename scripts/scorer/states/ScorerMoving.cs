namespace Godot.Game
{
    public partial class ScorerMoving : State
    {
        [Export]
        AreaMovementComponent areaMovementComponent;
        public override State ProcessFrame(double delta)
        {
            Vector2 position = areaMovementComponent.Move();
            if (position.X <= -48)
            {
                Parent.QueueFree();
            }
            return null;
        }

    }
}
