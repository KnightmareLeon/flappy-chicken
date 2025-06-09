using Godot;

public partial class Game : Node2D
{
    public static State state = State.START;

    public override void _Process(double delta)
    {
        if ((state == State.START | state == State.END) && Input.IsActionJustPressed("start"))
        {
            Chicken chicken = (Chicken) GetNode("Chicken");
            chicken.Position = new Vector2(256, 256);
            chicken.Rotate(chicken.Tilt);
            chicken.Tilt = 0f;
            state = State.PLAY;
        }
        base._Process(delta);
    }

}
