namespace Godot.Game.FlappyChicken.GroundStates;
public partial class Moving : State
{

    [Export]
    private Component.AreaMovementComponent _areaMovementComponent;
    [Export]
    private State _stoppedState;

    public override State ProcessFrame(double delta)
    {
        Vector2 position = _areaMovementComponent.Move();
        if (position.X <= 224)
        {
            Ground parent = (Ground)Parent;
            position.X = 272;
            parent.Position = position;
        }
        return null;
    }

    public override State ProcessSignal(string signalName, params Variant[] args)
    {
        if (signalName == "OnBodyEntered")
        {
            return _stoppedState;
        }
        return null;
    }
}