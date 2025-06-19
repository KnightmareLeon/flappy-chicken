namespace Godot.Game.FlappyChicken.ChickenStates;
public partial class Default : ChickenState
{
    [Export]
    private State _fallingState;
    [Export]
    private AnimatedSprite2D _animations;
    public override void Enter()
    {
        base.Enter();
        _animations.Play("default");
        Chicken.Position = new Vector2(256, 384);

    }
    public override State ProcessInput(InputEvent inputEvent)
    {
        if (Input.IsActionJustPressed("start"))
        {
            return _fallingState;
        }
        return null;
    }

}