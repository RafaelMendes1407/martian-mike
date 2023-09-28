using MartianMike.Scripts.Commons.Baseclass;

namespace MartianMike.Scripts;

public partial class Level2 : BaseLevel
{
    public override void _Ready()
    {
        base._Ready();
        this.IsFinalLevel = true;
    }
}