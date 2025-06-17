namespace Godot.Game.FlappyChicken
{

    public partial class Game : Node2D
    {
        [Export]
        public int PipeGenerationStart { get; set; } = 300;
        [Export]
        public int PipeGenerationInterval { get; set; } = 80;
        [Export]
        private StateMachine _stateMachine;
        private Chicken _chicken;

        private Ground _ground;
        public override void _Ready()
        {
            _chicken = (Chicken)GetNode<CharacterBody2D>("Chicken");
            _ground = (Ground)GetNode<Area2D>("Ground");
            _ground.BodyEntered += _chicken.OnHittingGround;
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

            _ground.BodyEntered += pipe.ChickenHitGround;
            _ground.BodyEntered += scorer.ChickenHitGround;
            pipe.BodyEntered += _chicken.OnHittingPipe;

            AddChild(pipe);
            AddChild(scorer);
        }

        private void ChickenHitGround(Node2D body)
        {
            _stateMachine.ProcessSignal("ChickenHitGround", body);
        }

    }
}
