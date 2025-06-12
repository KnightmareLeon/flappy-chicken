using Godot;

public partial class Playing : State
{

    private Game game;

    public override void Enter()
    {
        game = (Game)Parent;
    }

    public override State ProcessFrame(double delta)
    {
        if (--game.pipeGenerationStart <= 0)
        {
            game.GeneratePipe();
            game.pipeGenerationStart = game.pipeGenerationInterval;
        }
        return null;
    }

}