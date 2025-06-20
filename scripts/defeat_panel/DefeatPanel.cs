namespace Godot.Game.FlappyChicken;

public partial class DefeatPanel : PanelContainer
{
    [Export]
    private Label _score;

    public override void _UnhandledInput(InputEvent @event)
    {
        if (Input.IsActionJustPressed("start"))
        {
            QueueFree();
        }
    }

    public void GetScore(int score)
    {
        _score.Text = score.ToString();
    }

}
