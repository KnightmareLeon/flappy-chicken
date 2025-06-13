using Godot;

public partial class Game : Node2D
{
    [Export]
    public int pipeGenerationStart = 300;
    [Export]
    public int pipeGenerationInterval = 80;
    [Export]
    private State DefeatState; 
    public StateMachine StateMachine;
    public Chicken Chicken;

    private Ground Ground;
    public override void _Ready()
    {
        StateMachine = (StateMachine)GetNode<Node>("StateMachine");
        Chicken = (Chicken)GetNode<CharacterBody2D>("Chicken");
        Ground = (Ground)GetNode<Area2D>("Ground");
        StateMachine.Initialize(this);

        Ground.BodyEntered += Chicken.OnEnteringGround;
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
        pipe.Position = new Vector2(800, 720);
        pipe.Scale = new Vector2(2, 2);
        Ground.BodyEntered += pipe.ChickenEnteredGround;
        AddChild(pipe);
    }

    private void ChickenEnteredGround(Node2D body)
    {
        StateMachine.ChangeState(DefeatState);
    }

}
