namespace Godot.Game
{
    public partial class PipeStopped : State
    {

        public override State ProcessInput(InputEvent inputEvent)
        {
            if (Input.IsActionJustPressed("start"))
            {
                Parent.QueueFree();
            }
            return null;
        }
    }
}