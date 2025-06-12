using Godot;

public partial class Ground : Area2D
{
    public StateMachine StateMachine;

    private void OnGroundBodyEntered(PhysicsBody2D body)
    {
        /*
        Game.gameState = GameState.END;
        */
    }

    public override void _Ready()
    {
        StateMachine = (StateMachine)GetNode<Node>("StateMachine");
        StateMachine.Initialize(this);
    }

    public override void _Process(double delta)
    {
        StateMachine.ProcessFrame(delta);
    }

}
