namespace Godot.Game.FlappyChicken;

public partial class DefeatWindow : PanelContainer
{
    [Export]
    private Label _score;
    [Export]
    private Label _bestScoreLabel;
    [Export]
    private DefeatWindowAnimationPlayer _animationPlayer;
    private BestScore _bestScoreResource;

    public override void _Ready()
    {
        _bestScoreResource = (BestScore)ResourceLoader.Load("res://resources/best_score.tres");
    }

    public override void _UnhandledInput(InputEvent @event)
    {
        if (Input.IsActionJustPressed("start"))
        {
            Visible = false;
        }
    }

    public void GetScore(int score)
    {
        _score.Text = score.ToString();
        if (_score.Text.ToInt() > _bestScoreResource.SavedBestScore)
        {
            _bestScoreResource.SavedBestScore = _score.Text.ToInt();
            ResourceSaver.Save(_bestScoreResource, "res://resources/best_score.tres");
        }
        _bestScoreLabel.Text = _bestScoreResource.SavedBestScore.ToString();

    }

    public void Enter()
    {
        _animationPlayer.DefeatPanelEnter();
    }

}
