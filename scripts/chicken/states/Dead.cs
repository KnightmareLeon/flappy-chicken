namespace Godot.Game.FlappyChicken.ChickenStates;
public partial class Dead : ChickenState
{

    [Export]
    private State _defaultState;
    [Export]
    private AnimatedSprite2D _animations;
    public override void Enter()
    {
        base.Enter();
        Chicken.Rotate(Chicken.Tilt);
        Chicken.Tilt = 0f;
        Vector2 position = new(Chicken.Position.X, 708);
        Chicken.Position = position;
        _animations.Play("dying");
    }

    public override State ProcessInput(InputEvent inputEvent)
    {
        if (Input.IsActionJustPressed("start"))
        {
            return _defaultState;
        }
        return null;
    }

}