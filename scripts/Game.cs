using Godot;

public partial class Game : Node2D
{
    public static State state = State.START;
    private int pipeGenerationCD = 300;
    public override void _Process(double delta)
    {
        if ((state == State.START | state == State.END) && Input.IsActionJustPressed("start"))
        {
            Chicken chicken = (Chicken)GetNode("Chicken");

            chicken.Position = new Vector2(384, 384);
            chicken.Rotate(chicken.Tilt);
            chicken.Tilt = 0f;

            pipeGenerationCD = 300;
            state = State.PLAY;
        }

        if (state == State.PLAY)
        {
            if (--pipeGenerationCD == 0)
            {
                GeneratePipe();
                pipeGenerationCD = 80;
            }
        }
        base._Process(delta);
    }

    private void GeneratePipe()
    {
        PackedScene pipeScene = GD.Load<PackedScene>("res://scenes/pipe.tscn");
        Pipe pipe = (Pipe)pipeScene.Instantiate();
        pipe.Position = new Vector2(816, 672);
        pipe.Scale = new Vector2(3, 3);
        AddChild(pipe);
    }

}
