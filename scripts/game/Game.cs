using Godot;

public partial class Game : Node2D
{
    [Export]
    public int pipeGenerationStart = 300;
    [Export]
    public int pipeGenerationInterval = 80;
    public StateMachine StateMachine;
    public Chicken Chicken;
	public override void _Ready()
    {
        StateMachine = (StateMachine)GetNode<Node>("StateMachine");
        Chicken = (Chicken)GetNode<CharacterBody2D>("Chicken");
        StateMachine.Initialize(this);
    }
    public override void _Process(double delta)
    {
        /*
        if ((gameState == GameState.START | gameState == GameState.END) && Input.IsActionJustPressed("start"))
        {
            Chicken chicken = (Chicken)GetNode("Chicken");

            chicken.Position = new Vector2(384, 384);
            chicken.Rotate(chicken.Tilt);
            chicken.Tilt = 0f;

            pipeGenerationCD = 300;
            gameState = GameState.PLAY;
        }

        if (gameState == GameState.PLAY)
        {
            if (--pipeGenerationCD == 0)
            {
                GeneratePipe();
                pipeGenerationCD = 80;
            }
        }
        base._Process(delta);
        */
        StateMachine.ProcessFrame(delta);
    }

    public override void _UnhandledInput(InputEvent @event)
    {
        StateMachine.ProcessInput(@event);
    }


    public void GeneratePipe()
    {
        PackedScene pipeScene = GD.Load<PackedScene>("res://scenes/pipe.tscn");
        Pipe pipe = (Pipe)pipeScene.Instantiate();
        pipe.Position = new Vector2(816, 672);
        pipe.Scale = new Vector2(3, 3);
        AddChild(pipe);
    }

}
