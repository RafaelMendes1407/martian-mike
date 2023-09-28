using Godot;
using MartianMike.scripts;

namespace MartianMike.Scripts.Commons.Baseclass;

public sealed class BaseUi
{
    private PauseScreen _pauseScreen;
    private TimerHud _timerHud;
    private WinScreen _winScreen;
    public Ui Ui { get; private set; }

    public BaseUi(BaseLevel baseLevel, int levelTime)
    {
        this._buildIu(baseLevel, levelTime);
    }

    private void _buildIu(BaseLevel baseLevel, int levelTime)
    {
        this._pauseScreen = (PauseScreen) GD.Load<PackedScene>("res://scenes/pause_screen.tscn").Instantiate();
        this._timerHud = (TimerHud)GD.Load<PackedScene>("res://scenes/timer_hud.tscn").Instantiate();
        this._winScreen = GD.Load<PackedScene>("res://scenes/win_screen.tscn").Instantiate<WinScreen>();
        this.Ui = (Ui) GD.Load<PackedScene>("res://scenes/ui.tscn").Instantiate();
        this._buildUIHud(baseLevel, levelTime);
    }
	
    private void _buildUIHud(BaseLevel baseLevel, int levelTime)
    {
        this.Ui.AddChild(this._pauseScreen);
        this.Ui.AddChild(this._timerHud);
        this.Ui.AddChild(this._winScreen);
        baseLevel.AddChild(this.Ui);
        this._pauseScreen.Visible = false;
        this.Ui.UpdateTimerHud(levelTime);
    }
}