using Godot;

public partial class Pipe : Area2D
{
    StateMachine StateMachine;
    [Export]
    State StoppedState;
    public override void _Ready()
    {
        StateMachine = (StateMachine)GetNode<Node>("StateMachine");
        StateMachine.Initialize(this);

        TileMapLayer lowerPipe = GetNode<TileMapLayer>("LowerPipeTileMap");
        TileMapLayer upperPipe = GetNode<TileMapLayer>("UpperPipeTileMap");

        Vector2I pipeTopLeft = new Vector2I(4, 0);
        Vector2I pipeTopRight = new Vector2I(5, 0);
        Vector2I pipeMiddleLeft = new Vector2I(4, 1);
        Vector2I pipeMiddleRight = new Vector2I(5, 1);

        RandomNumberGenerator rng = new RandomNumberGenerator();
        rng.Randomize();

        int lowerPipeHeight = rng.RandiRange(-16, -3);
        int upperPipeHeight = -23 - lowerPipeHeight + 4;

        lowerPipe.SetCell(new Vector2I(-1, lowerPipeHeight), sourceId: 0, atlasCoords: pipeTopLeft);
        lowerPipe.SetCell(new Vector2I(0, lowerPipeHeight++), sourceId: 0, atlasCoords: pipeTopRight);
        for (int i = lowerPipeHeight; i < -2; i++)
        {
            lowerPipe.SetCell(new Vector2I(-1, i), sourceId: 0, atlasCoords: pipeMiddleLeft);
            lowerPipe.SetCell(new Vector2I(0, i), sourceId: 0, atlasCoords: pipeMiddleRight);
        }

        upperPipe.SetCell(new Vector2I(-1, upperPipeHeight), sourceId: 0, atlasCoords: pipeTopLeft);
        upperPipe.SetCell(new Vector2I(0, upperPipeHeight++), sourceId: 0, atlasCoords: pipeTopRight);
        for (int i = upperPipeHeight; i < -2; i++)
        {
            upperPipe.SetCell(new Vector2I(-1, i), sourceId: 0, atlasCoords: pipeMiddleLeft);
            upperPipe.SetCell(new Vector2I(0, i), sourceId: 0, atlasCoords: pipeMiddleRight);
        }
    }

    public override void _Process(double delta)
    {
        StateMachine.ProcessFrame(delta);
    }

    public override void _UnhandledInput(InputEvent @event)
    {
        StateMachine.ProcessInput(@event);
    }


    public void ChickenEnteredGround(Node2D body)
    {
        StateMachine.ChangeState(StoppedState);
    }
}
