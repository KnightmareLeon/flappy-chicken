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

    public override void _UnhandledInput(InputEvent @event)
    {
        StateMachine.ProcessInput(@event);
    }
    public override void _Process(double delta)
    {
        StateMachine.ProcessFrame(delta);
    }

    public void GeneratePipe()
    {
        PackedScene pipeScene = GD.Load<PackedScene>("res://scenes/pipe.tscn");
        PackedScene scorerScene = GD.Load<PackedScene>("res://scenes/scorer.tscn");

        Pipe pipe = (Pipe)pipeScene.Instantiate();
        Scorer scorer = (Scorer)scorerScene.Instantiate();

        Vector2 position = new Vector2(800, 720);
        Vector2 scale = new Vector2(2, 2);

        pipe.Position = position;
        pipe.Scale = scale;

        scorer.Position = position;
        pipe.Scale = scale;

        Ground.BodyEntered += pipe.ChickenEnteredGround;
        Ground.BodyEntered += scorer.ChickenEnteredGround;
        pipe.BodyEntered += Chicken.OnEnteringPipe;

        AddChild(pipe);
        AddChild(scorer);
    }

    private void ChickenEnteredGround(Node2D body)
    {
        StateMachine.ChangeState(DefeatState);
    }

}
