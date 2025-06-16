namespace Godot.Game
{

    public partial class Game : Node2D
    {
        [Export]
        public int PipeGenerationStart { get; set; } = 300;
        [Export]
        public int PipeGenerationInterval { get; set; } = 80;
        [Export]
        private StateMachine _stateMachine;
        [Export]
        private State defeatState;
        private Chicken chicken;

        private Ground ground;
        public override void _Ready()
        {
            chicken = (Chicken)GetNode<CharacterBody2D>("Chicken");
            ground = (Ground)GetNode<Area2D>("Ground");
            ground.BodyEntered += chicken.OnEnteringGround;
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

            ground.BodyEntered += pipe.ChickenEnteredGround;
            ground.BodyEntered += scorer.ChickenEnteredGround;
            pipe.BodyEntered += chicken.OnEnteringPipe;

            AddChild(pipe);
            AddChild(scorer);
        }

        private void ChickenEnteredGround(Node2D body)
        {
            _stateMachine.ChangeState(defeatState);
        }

    }
}
