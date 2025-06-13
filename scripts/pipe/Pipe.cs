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

        CollisionShape2D lowerPipeColBox = GetNode<CollisionShape2D>("LowerCollisionArea");
        CollisionShape2D upperPipeColBox = GetNode<CollisionShape2D>("UpperCollisionArea");

        Vector2I pipeTopLeft = new Vector2I(4, 0);
        Vector2I pipeTopRight = new Vector2I(5, 0);
        Vector2I pipeMiddleLeft = new Vector2I(4, 1);
        Vector2I pipeMiddleRight = new Vector2I(5, 1);

        RandomNumberGenerator rng = new RandomNumberGenerator();
        rng.Randomize();

        int lowerPipeHeight = rng.RandiRange(-16, -3);
        int upperPipeHeight = -23 - lowerPipeHeight + 4;

        Vector2 newLowerPipeColPos = new Vector2(lowerPipeColBox.Position.X, lowerPipeHeight * 16 / 2);
        Vector2 newUpperPipeColPos = new Vector2(upperPipeColBox.Position.X, (upperPipeHeight * 16 / 2) + ((lowerPipeHeight - 4) * 16));

        lowerPipeColBox.Position = newLowerPipeColPos;
        upperPipeColBox.Position = newUpperPipeColPos;

        RectangleShape2D newLowerPipeColBox = new RectangleShape2D();
        RectangleShape2D newUpperPipeColBox = new RectangleShape2D();

        newLowerPipeColBox.Size = new Vector2(32, -lowerPipeHeight * 16);
        newUpperPipeColBox.Size = new Vector2(32, (-upperPipeHeight + 1)* 16);

        lowerPipeColBox.Shape = newLowerPipeColBox;
        upperPipeColBox.Shape = newUpperPipeColBox;

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
