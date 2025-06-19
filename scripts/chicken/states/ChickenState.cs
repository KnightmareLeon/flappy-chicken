namespace Godot.Game.FlappyChicken.ChickenStates;
[GlobalClass]
public partial class ChickenState : State
{
    public Chicken Chicken { get; private set; }
    public override void Enter()
    {
        Chicken = (Chicken)Parent;
    }
}