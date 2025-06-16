using Godot;

public partial class AreaMovementComponent : Node2D
{
    public Vector2 Move()
    {
        Node2D parent = GetParent<Node2D>();
        Vector2 position = parent.Position;
        position.X -= 3;
        parent.Position = position;
        return position;
    }
}
