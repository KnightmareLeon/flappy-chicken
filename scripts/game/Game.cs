namespace Godot.Game.FlappyChicken;
public partial class Game : Node2D
{
    [Export]
    public int PipeGenerationStart { get; set; } = 300;
    [Export]
    public int PipeGenerationInterval { get; set; } = 80;

    public int Score { get; set; } = 0;
    [Export]
    private StateMachine _stateMachine;
    [Export]
    private Chicken _chicken;
    [Export]
    private Ground _ground;
    [Export]
    private DefeatWindow _defeatWindow;

    [Signal]
    public delegate void UpdateScoreEventHandler(int score);
    [Signal]
    public delegate void SendScoreEventHandler(int score);

    public override void _Ready()
    {
        _defeatWindow.Visible = false;
    }

    public override void _UnhandledInput(InputEvent @event)
    {
        _stateMachine.ProcessInput(@event);
    }
    public override void _Process(double delta)
    {
        _stateMachine.ProcessFrame(delta);
    }

    public void GeneratePipe()
    {
        PackedScene pipeScene = GD.Load<PackedScene>("res://scenes/pipe.tscn");
        PackedScene scorerScene = GD.Load<PackedScene>("res://scenes/scorer.tscn");

        Pipe pipe = (Pipe)pipeScene.Instantiate();
        Scorer scorer = (Scorer)scorerScene.Instantiate();

        Vector2 position = new(800, 720);
        Vector2 scale = new(2, 2);

        pipe.Position = position;
        pipe.Scale = scale;

        scorer.Position = position;
        pipe.Scale = scale;

        _ground.Connect("body_entered", new Callable(pipe, nameof(pipe.ChickenHitGround)));
        _ground.Connect("body_entered", new Callable(scorer, nameof(scorer.ChickenHitGround)));
        pipe.Connect("body_entered", new Callable(_chicken, nameof(_chicken.OnHittingPipe)));
        scorer.Connect("body_entered", new Callable(_chicken, nameof(_chicken.OnEnteringScorer)));

        AddChild(pipe);
        MoveChild(pipe, 1);
        AddChild(scorer);
        MoveChild(scorer, 1);
    }

    public void ShowDefeatPanel()
    {
        _defeatWindow.Visible = true;
        _defeatWindow.Enter();
    }

    private void ChickenHitGround(Node2D body)
    {
        _stateMachine.ProcessSignal("ChickenHitGround", body);
    }

    private void OnChickenScoring()
    {
        _stateMachine.ProcessSignal("OnChickenScoring");
    }
}