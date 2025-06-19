namespace Godot.Game.FlappyChicken;

public partial class DefeatPanel : PanelContainer
{
    public override void _UnhandledInput(InputEvent @event)
    {
        if (Input.IsActionJustPressed("start"))
        {
            QueueFree();
        }
    }

}
