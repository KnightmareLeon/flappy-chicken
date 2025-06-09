using Godot;

public partial class Game : Node2D
{
    public static State state = State.START;

    public override void _Process(double delta)
    {
        if (state == State.START && Input.IsActionJustPressed("start"))
        {
            state = State.PLAY;
        }
        base._Process(delta);
    }

}
