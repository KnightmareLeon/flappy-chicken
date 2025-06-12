using System;
using Godot;

public partial class Start : State
{

    [Export]
    private State PlayingState;

    Game game;
    public override void Enter()
    {
        game = (Game)Parent;
    }
    public override State ProcessInput(InputEvent inputEvent)
    {
        if (Input.IsActionJustPressed("start"))
        {
            return PlayingState;
        }
        return null;
    }


}