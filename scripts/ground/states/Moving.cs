namespace Godot.Game
{
    public partial class Moving : State
    {

        [Export]
        private AreaMovementComponent areaMovementComponent;

        public override State ProcessFrame(double delta)
        {
            Vector2 position = areaMovementComponent.Move();
            if (position.X <= 224)
            {
                Ground parent = (Ground)Parent;
                position.X = 272;
                parent.Position = position;
            }
            return null;
        }
    }
}